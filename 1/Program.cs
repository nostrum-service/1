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
using Base;
using BaseMap;
using Reader;
using ReaderMap;
using Newtonsoft.Json;



namespace _1
{
    public class Program
    {
        static void Main(string[] args)
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

            string FileName = args[0];

            var config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                DetectDelimiter = true,
                Encoding = Encoding.GetEncoding("UTF-8"),
            };

            
            List<ExampleForReader> records = new List<ExampleForReader>();

            if (File.Exists(FileName))
            {
                var reader = File.OpenText(FileName); 
                var csvRead = new CsvHelper.CsvReader(reader, config);
                csvRead.Context.RegisterClassMap<ExampleForReaderMap>();
                records = csvRead.GetRecords<ExampleForReader>().ToList();
                reader.Close();

                foreach (ExampleForReader el in records)
                {
                    Console.WriteLine(el);
                    logger.Info("info message");
                }

                
                //сериализуем
                string serialized = JsonConvert.SerializeObject(records);
                System.IO.File.WriteAllText(@"C:\Users\sonja\OneDrive\Рабочий стол\cb\03-01-1\path.txt", serialized);

                //десериализуем
                //List<Example> TestJson = new List<Example>();
                //var serializer = new JsonSerializer();
                //using (StreamReader fs = new StreamReader(@"C:\Users\sonja\OneDrive\Рабочий стол\cb\03-01-1\path1.json")) ;
                
                var TestJson  = JsonConvert.DeserializeObject<List<ExampleForReader>>(File.ReadAllText(@"C:\Users\sonja\OneDrive\Рабочий стол\cb\03-01-1\path1.json"));
                //using (StreamReader file = File.OpenText(@"C:\Users\sonja\OneDrive\Рабочий стол\cb\03-01-1\path1.json"))
                //{
                //    JsonSerializer ser = new JsonSerializer();
                //    Example TestJson = (Example)serializer.Deserialize(file, typeof(Example));

                //}
                //string fileNamejson = "C:\Users\sonja\OneDrive\Рабочий стол\cb\03 - 01 - 1\path1.json";
                //string jsonString = File.ReadAllText(fileNamejson);
                //{
                //    using (var jsonTextWriter = new JsonTextWriter(fs))
                //    {
                //        serializer.Serialize(fs, TestJson);
                foreach (ExampleForReader el in TestJson)
                {
                    Console.WriteLine(el);

                }
                //    }
                //}

            }

            if (records.Count == 0)
            {
                var csvTextWriter = new StreamWriter(FileName, true, Encoding.UTF8);
                var csvWrite = new CsvHelper.CsvWriter(csvTextWriter, CultureInfo.InvariantCulture);
                var rand = new Random();
                string tekdate = string.Empty;

                string[] words = { "Документ7", "Документ2", "Документ3", "Документ5" };
                string[] dates = { "30.11.2021", "01.05.1990", "15.06.2000", "8.01.1981" };

                List<DateTime> norm_dates = new List<DateTime>();
                DateTime datevalue;
                for (int d = 0; d <= dates.Length; d++)
                    tekdate = dates[rand.Next(0, dates.Length)];
                if (DateTime.TryParse(tekdate, out datevalue))
                    norm_dates.Add(DateTime.Parse(tekdate));
                else
                    Console.WriteLine($"Невозможно преобразовать строку в тип Дата {tekdate}");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;


                List<Example> writeList = new List<Example>();
                for (int c = 0; c <= words.Length; c++)
                    writeList.Add(new Example(rand.Next().ToString(), words[rand.Next(0, words.Length)], words[rand.Next(0, words.Length)], norm_dates[rand.Next(0, words.Length)], words[rand.Next(0, words.Length)], words[rand.Next(0, words.Length)], words[rand.Next(0, words.Length)]));

                csvWrite.WriteRecords(writeList);
                csvWrite.Flush();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }


        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка {(e.ExceptionObject as Exception)?.Message}");
        }

    }



}
