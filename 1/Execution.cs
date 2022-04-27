using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
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
using PartnersAndDocs;
using LiteDB;


namespace Execution
{
    public class ProgramExecution
    {
        public void MainExec()
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var rand = new Random();
            string tekdate = string.Empty;

            string[] words = { "Контрагент1", "Контрагент8", "Контрагент2", "Контрагент3", "Контрагент4", "Контрагент5", "Контрагент6", "Контрагент7" };
            string[] dates = { "30.11.2021", "01.05.1990", "15.06.2000", "8.01.1981" };

            //массив дат можно сразу определить
            DateTime[] dates1 = { new DateTime(2021, 1, 1), new DateTime(2020, 2, 4) };

            List<DateTime> norm_dates = new List<DateTime>();
            DateTime datevalue;

            //а что ты тут хотела сделать?
            //++s.e. - хотела создать массив случайных дат
            //ты в цикле dates.Length раз присваивала переменной tekdate значение случайной даты... я не понял :)
            for (int d = 0; d <= dates.Length; d++)
            {
                tekdate = dates[rand.Next(0, dates.Length)];

                //при успешной попытке разбора даты из строки, переменная datevalue
                //содержит значение распознаной даты. повторно разбирать не требуется
                //++s.e. - поняла
                if (DateTime.TryParse(tekdate, out datevalue))
                    norm_dates.Add(datevalue);
                else
                {
                    Console.WriteLine($"Невозможно преобразовать строку в тип Дата {tekdate}");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    return;
                }
            }

            List<ExampleForReader> writeList = new List<ExampleForReader>();
            List<Partners> PartnerList = new List<Partners>();
            //и в бд
            string baseParametre = ConfigurationManager.AppSettings["database"];

            for (int d = 0; d <= words.Length - 1; d++)
            {
                PartnerList.Add(new Partners(words[d], d));

                using (var db = new LiteDatabase(baseParametre))
                {
                    // Получаем коллекцию
                    var col = db.GetCollection<Partners>("PartnersDB");
                    var part = new Partners(words[d], d);
                    // Добавляем компанию в коллекцию
                    col.Insert(part);
                }
            }
            using (var db = new LiteDatabase(baseParametre))
            {
                // Получаем коллекцию
                var coldoc = db.GetCollection<ExampleForReader>("Docs");
                var doc = new ExampleForReader(rand.Next().ToString(),
                words[rand.Next(0, words.Length)],
                PartnerList[4],
                words[rand.Next(0, words.Length)],
                norm_dates[rand.Next(0, norm_dates.Count() - 1)],
                words[rand.Next(0, words.Length)],
                words[rand.Next(0, words.Length)],
                words[rand.Next(0, words.Length)],
                words[rand.Next(0, words.Length)]);
                coldoc.Insert(doc);

            }
            // так проще, а есть еще foreach(var word in words)
            //++s.e. - поняла
            for (int c = 0; c < words.Length; c++)
            {
                //такая инициализация нагляднее
                //++s.e.- поняла
                var test = new ExampleForReader
                {
                    Number = rand.Next().ToString(),
                    Document = words[rand.Next(0, words.Length)],
                    PartnerID = PartnerList[c],
                    Organization = words[rand.Next(0, words.Length)],
                    DateDay = norm_dates[rand.Next(0, norm_dates.Count() - 1)],
                    Department = words[rand.Next(0, words.Length)],
                    Initiator = words[rand.Next(0, words.Length)],
                    Chapter = words[rand.Next(0, words.Length)],
                    Quantity = words[rand.Next(0, words.Length)]
                };

                writeList.Add(test);

            }

            #region туда, сюда удобно
            var opt = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                DateFormatString = "yyyy-MM-ddThh:mm:ss"
            };
            var ctx = new DbContextOne { PartnerList = PartnerList, WriteList = writeList };
            string sr = JsonConvert.SerializeObject(ctx, opt);

            DbContextOne restored = JsonConvert.DeserializeObject<DbContextOne>(sr, opt);



            //foreach (int el in ctx.PartnerList)
            //var enumerator = collection.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    var current = enumerator.Current;
            //    // обработать элемент current 
            //}
            var selectedDocs = from part in ctx.PartnerList
                               join doc in ctx.WriteList on part.PartnerID equals doc.PartnerID.PartnerID
                               group doc by doc.PartnerID into g
                               select new
                               {
                                   Partner = g.Key,
                                   Count_ = g.Count(),
                                   exampleDocs = g
                               };

            //select new
            //{
            //    Partner = g.Key, все правильно. получила контрагента и кол-во документов по нему. 
            //    Count_ = g.Count(),
            //
            //а вот это это что? 
            //    exampleDocs = from p in g 
            //                  group p by p.PartnerID into m
            //                  select new { Partner_ = m.Key.NameOfPartner, CountD = m.Count() }
            //};

            foreach (var seldoc in selectedDocs)
            {
                Console.WriteLine($"{seldoc.Partner} : {seldoc.Count_}");

                Console.WriteLine(seldoc.exampleDocs.Select(c => $"{c.Document} : {c.Number}\r\n"));
                //foreach (var c in seldoc.exampleDocs)
                //{
                //    Console.WriteLine($"{c.Document} : {c.Number}");
                //}

            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            #endregion


            //сериализуем
            //неудобно
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "yyyy-MM-ddThh:mm:ss";
            string serialized = JsonConvert.SerializeObject(new { PartnerList, writeList }, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                DateFormatString = jsonSettings.DateFormatString
            });
            System.IO.File.WriteAllText(@"path300322-.json", serialized);

            //десериализуем
            string data = File.ReadAllText(@"path300322-.json");

            List<ExampleForReader> writeList1 = new List<ExampleForReader>();
            List<Partners> PartnerList1 = new List<Partners>();
            var jsonSettings1 = new JsonSerializerSettings();
            jsonSettings1.DateFormatString = "yyyy-MM-ddThh:mm:ss";

            var f = JsonConvert.DeserializeObject<dynamic>(data, jsonSettings1);
            //foreach (var x in f.PartnerList)
            //{
            //    PartnerList1.Add(new Partners((string)x.NameOfPartner, (int)x.PartnerID));
            //   // Console.WriteLine(x.NameOfPartner);

            //}


            //foreach (var m in f.writeList)
            //{
            //    writeList1.Add(new ExampleForReader(m.NumberFS.ToString(), m.DocumentFS.ToString(), PartnerList1[Convert.ToInt32(m.PartnerID["$ref"])], m.OrganizationFS.ToString(), DateTime.Parse(m.DateDayFS.ToString()),
            //            m.DepartmentFS.ToString(), m.InitiatorFS.ToString(), string.Empty, m.QuantityFS.ToString()));
            //}
            //foreach (var t in writeList1)
            //{
            //    Console.WriteLine(t.ToString());
            //}
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
            PartnersDocsClass other = JsonConvert.DeserializeObject<PartnersDocsClass>(data, jsonSettings1);
        }



        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка {(e.ExceptionObject as Exception)?.Message}");
        }

    }

    public class DbContextOne
    {
        public IEnumerable<Partners> PartnerList { get; set; }
        public IEnumerable<ExampleForReader> WriteList { get; set; }


    }

}
