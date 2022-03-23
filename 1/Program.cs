using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ServiceStack.Text;
//using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using NLog;

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
                DetectDelimiter = true
            };

            List<Example> records = new List<Example>();

            if (File.Exists(FileName))
            {
                var reader = File.OpenText(FileName);
                var csvRead = new CsvHelper.CsvReader(reader, config);

                records = csvRead.GetRecords<Example>().ToList();
                reader.Close();

                foreach (Example el in records)
                {
                    Console.WriteLine(el);
                    logger.Info("info message");
                }
            }


            if (records.Count == 0)
            {
                var csvTextWriter = new StreamWriter(FileName, true, Encoding.UTF8);
                var csvWrite = new CsvHelper.CsvWriter(csvTextWriter, CultureInfo.InvariantCulture);
                var rand = new Random();
                string[] words = { "Документ7", "Документ2", "Документ3", "Документ5" };

                List<Example> writeList = new List<Example>();
                for (int c = 0; c <= words.Length; c++)
                    writeList.Add(new Example(rand.Next().ToString(), words[rand.Next(0, words.Length)], words[rand.Next(0, words.Length)], words[rand.Next(0, words.Length)], words[rand.Next(0, words.Length)], words[rand.Next(0, words.Length)], words[rand.Next(0, words.Length)]));

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


        public class Example
        {
            public override string ToString()
            {
                return $"Содержание строки {Number}, {Document}, {Organization}, {DateDay}, {Department}, {Initiator}, {Chapter}";
            }

            //public static Example DeserializeCsv(string srcString)
            //{
            //    try
            //    {
            //        return new Example(srcString);
            //    }
            //    catch
            //    {
            //        return null;
            //    }
            //}

            public string Number { get; set; }
            public string Document { get; set; }
            public string Organization { get; set; }
            public string DateDay { get; set; }
            public string Department { get; set; }
            public string Initiator { get; set; }
            public string Chapter { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sourceString"></param>
            //public Example(string sourceString)
            //{
            //    string[] ex = sourceString.Split(';');

            //    if (int.TryParse(ex[0], out int v1))
            //    {
            //        //
            //    }
            //    else
            //    {
            //        //--
            //    }
            //}

            public Example()
            {
            }

            public Example(string a, string b, string c, string d, string e, string f, string g)
            {
                Number          = a;
                Document        = b;
                Organization    = c;
                DateDay         = d;
                Department      = e;
                Initiator       = f;
                Chapter         = g;
            }
        
         }
    }

    //public static class StrExt
    //{
    //    public static Program.Example DeserializeToExample(this string src)
    //    {
    //        try
    //        {
    //            return new Program.Example(src);
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }
    //}


}
