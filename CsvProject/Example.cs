using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAttribute;


namespace Base
{
    public class Example
    {
        public Example()
        { 
        }
        public override string ToString()
        {
            return $"Содержание строки {Number}, {Document}, {Organization}, {DateDay.ToString("d")}, {Department}, {Initiator}, {Chapter}, {Quantity}";
        }

        
        [Name("№ п/п")]
        public string Number { get; set; }

        
        [Name("Документ")]
        public string Document { get; set; }

   
        [Name("Организация")]
        public string Organization { get; set; }

 
        [Name("Дата замечания")]
        public DateTime DateDay { get; set; }

 
        [Name("Подразделение инициатора")]
        public string Department { get; set; }


        [Name("Инициатор (ФИО)")]
        public string Initiator { get; set; }


        [Name("№ и название раздела")]
        public string Chapter { get; set; }


        [Name("Количество")]
        public int Quantity { get; set; }



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

        public Example(string a, string b, string c, DateTime d, string e, string f, string g)
        {
            Number = a;
            Document = b;
            Organization = c;
            DateDay = d;
            Department = e;
            Initiator = f;
            Chapter = g;
        }

    }
}
