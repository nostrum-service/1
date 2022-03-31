using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using NLog;
using System.Reflection;
using Reader;
using Newtonsoft.Json;
using TableOfPartners;

namespace Execution
{
    public class ProgramExecution
    {
        public void MainExec(string[] args)
        {

            Logger logger = LogManager.GetCurrentClassLogger();

            if (args.Length != 1)
            {
                Console.WriteLine("Укажите в параметрах запуска имя файла");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            //string FileName = args[0];

            //var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            //{
            //    HasHeaderRecord = true,
            //    DetectDelimiter = true,
            //    Encoding = Encoding.GetEncoding("UTF-8"),
            //};

            var rand = new Random();
            string tekdate = string.Empty;

            string[] words = { "Контрагент1", "Контрагент8", "Контрагент2", "Контрагент3", "Контрагент4", "Контрагент5", "Контрагент6", "Контрагент7" };
            string[] dates = { "30.11.2021", "01.05.1990", "15.06.2000", "8.01.1981" };

            List<DateTime> norm_dates = new List<DateTime>();
            DateTime datevalue;
            for (int d = 0; d <= dates.Length; d++)
                tekdate = dates[rand.Next(0, dates.Length)];
            if (DateTime.TryParse(tekdate, out datevalue))
                norm_dates.Add(DateTime.Parse(tekdate));
            else
            {
                Console.WriteLine($"Невозможно преобразовать строку в тип Дата {tekdate}");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            List<ExampleForReader> writeList = new List<ExampleForReader>();
            List<Partners> PartnerList = new List<Partners>();

            for (int d = 0; d <= words.Length-1; d++)
                PartnerList.Add(new Partners(words[d], d.ToString()));

            for (int c = 0; c <= words.Length; c++)
                writeList.Add(new ExampleForReader(rand.Next().ToString(), 
                    words[rand.Next(0, words.Length)],
                    PartnerList[c],
                    words[rand.Next(0, words.Length)], 
                    norm_dates[rand.Next(0, dates.Length)], 
                    words[rand.Next(0, words.Length)], 
                    words[rand.Next(0, words.Length)], 
                    words[rand.Next(0, words.Length)],
                    words[rand.Next(0, words.Length)]));

            //List<ExampleForReader> records = new List<ExampleForReader>();

            //if (File.Exists(FileName))
            //{
                //var reader = File.OpenText(FileName);
                //var csvRead = new CsvHelper.CsvReader(reader, config);
                //csvRead.Context.RegisterClassMap<ExampleForReaderMap>();
                //records = csvRead.GetRecords<ExampleForReader>().ToList();
                //reader.Close();

                //сериализуем
                string serialized = JsonConvert.SerializeObject(writeList, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                System.IO.File.WriteAllText(@"C:\Users\sonja\OneDrive\Рабочий стол\cb\03-01-1\path300322.txt", serialized);
            //    //десериализуем
            //    var TestJson = JsonConvert.DeserializeObject<List<ExampleForReader>>(File.ReadAllText(@"C:\Users\sonja\OneDrive\Рабочий стол\cb\03-01-1\path1.json"));

            //    foreach (ExampleForReader el in TestJson)
            //    {
            //        Console.WriteLine(el);
            //    }

            ////}

            //Console.WriteLine("Press any key to exit");
            //Console.ReadKey();
        }


        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка {(e.ExceptionObject as Exception)?.Message}");
        }

    }



}
