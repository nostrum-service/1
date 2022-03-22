using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Укажите в параметрах запуска имя файла");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            string FileName = args[0];

            if (!File.Exists(FileName))
            {
                Console.WriteLine($"Файл {FileName} не существует");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                return;
            }

            var src = File.ReadAllLines(FileName, Encoding.UTF8)
                .Select(c => c.DeserializeToExample()).OrderBy(c => c.example_name);

            foreach (var k in src)
                Console.WriteLine(k);


            var examples = File.ReadAllLines(FileName, Encoding.UTF8);
            List<Example> examples_list = new List<Example>();
            foreach (string s in examples)
            {
                //examples_list.Add(new Example(ex[0], Convert.ToInt32(ex[1])));
                examples_list.Add(s.DeserializeToExample());
            }

            var final_examples_list = examples_list.OrderBy(a => a.example_name);

            foreach (var k in final_examples_list)
                Console.WriteLine(k.example_name, k.weight);

            Console.WriteLine("Press any key to exit.");
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
                return $"Наименование {example_name}, {weight}";
            }

            public static Example DeserializeCsv(string srcString)
            {
                try
                {
                    return new Example(srcString);
                }
                catch
                {
                    return null;
                }
            }

            public string example_name { get; set; }
            public int weight { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sourceString"></param>
            public Example(string sourceString)
            {
                string[] ex = sourceString.Split(';');

                if (int.TryParse(ex[0], out int v1))
                {
                    //
                }
                else
                {
                    //--
                }
            }

            public Example(string a, int b)
            {
                example_name = a;
                weight = b;

            }
        }
    }

    public static class StrExt
    {
        public static Program.Example DeserializeToExample(this string src)
        {
            try
            {
                return new Program.Example(src);
            }
            catch
            {
                return null;
            }
        }
    }


}
