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
            for (int d = 0; d <= dates.Length; d++)
                tekdate = dates[rand.Next(0, dates.Length)];

            //при успешной попытке разбора даты из строки, переменная datevalue содержит значение распознаной даты. повторно разбирать не требуется
            if (DateTime.TryParse(tekdate, out datevalue))
                norm_dates.Add(datevalue);
            //if (DateTime.TryParse(tekdate, out datevalue))
            //    norm_dates.Add(DateTime.Parse(tekdate));
            else
            {
                Console.WriteLine($"Невозможно преобразовать строку в тип Дата {tekdate}");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
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

            // так проще, а есть еще foreach(var word in words)
            for (int c = 0; c < words.Length; c++)
            //for (int c = 0; c <= words.Length - 1; c++)
            {
                //такая инициализация нагляднее
                var test = new ExampleForReader {
                    Number = rand.Next().ToString(),
                    Document = words[rand.Next(0, words.Length)]
                    //и т.д.
                };

                writeList.Add(new ExampleForReader(rand.Next().ToString(),
                    words[rand.Next(0, words.Length)],
                    PartnerList[4],
                    words[rand.Next(0, words.Length)],
                    //JsonConvert.SerializeObject(dates[rand.Next(0, dates.Length)]),
                    norm_dates[rand.Next(0, norm_dates.Count() - 1)],
                    words[rand.Next(0, words.Length)],
                    words[rand.Next(0, words.Length)],
                    words[rand.Next(0, words.Length)],
                    words[rand.Next(0, words.Length)]));
                //и в бд

                //блок using (var db = new LiteDatabase(baseParametre)) лучше перенести выше цикла for. т.к. операция открытия БД все-таки ресурсоемкая
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
            //System.IO.File.WriteAllText(@"C:\Users\sonja\OneDrive\Рабочий стол\cb\03-01-1\path300322-.json", serialized);
            System.IO.File.WriteAllText(@"path300322-.json", serialized);

            ////из бд
            //using (var db = new LiteDatabase(baseParametre))
            //{
            //    // Получаем коллекцию
            //    var coldoc = db.GetCollection<ExampleForReader>("Docs");
            //    var results = coldoc.Find(x => x.PartnerID);
            //}
            //десериализуем
            //string data = File.ReadAllText(@"C:\Users\sonja\OneDrive\Рабочий стол\cb\03-01-1\path300322-.json");
            string data = File.ReadAllText(@"path300322-.json");

            List<ExampleForReader> writeList1 = new List<ExampleForReader>();
            List<Partners> PartnerList1 = new List<Partners>();
            var jsonSettings1 = new JsonSerializerSettings();
            jsonSettings1.DateFormatString = "yyyy-MM-ddThh:mm:ss";

            var f = JsonConvert.DeserializeObject<dynamic>(data, jsonSettings1);
            foreach (var x in f.PartnerList)
            {
                //PartnerList1.Add(new Partners(x.NameOfPartner.ToString(), Convert.ToInt32(x.PartnerID)));
                PartnerList1.Add(new Partners((string)x.NameOfPartner, (int)x.PartnerID));
                Console.WriteLine(x.NameOfPartner);

            }


            foreach (var m in f.writeList)
            {
                writeList1.Add(new ExampleForReader(m.NumberFS.ToString(), m.DocumentFS.ToString(), PartnerList1[Convert.ToInt32(m.PartnerID["$ref"])], m.OrganizationFS.ToString(), DateTime.Parse(m.DateDayFS.ToString()),
                    m.DepartmentFS.ToString(), m.InitiatorFS.ToString(), string.Empty, m.QuantityFS.ToString()));

            }
            foreach (var t in writeList1)
            {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


            //List<PartnersDocsClass> PartnersDocsClass = new List<PartnersDocsClass>();
            PartnersDocsClass other = JsonConvert.DeserializeObject<PartnersDocsClass>(data, jsonSettings1);

            //var lst = other.Documents.ToArray();
            //foreach (var n in lst)
            //{
            //    Console.WriteLine(n.PartnerID);
            //}

            //var lst_ = other.ParForDocs.ToList();
            //foreach (var n in lst_)
            //{
            //    Console.WriteLine(n.NameOfPartner);
            //}

            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
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
