﻿using System;
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




namespace CsvProject
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
