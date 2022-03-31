using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAttribute;


namespace Reader
{
    public class ExampleForReader
    {
        public ExampleForReader()
        {
        }
        public override string ToString()
        {
            return $"Содержание строки {Number}, {Document}, {Organization}, {DateDay}, {Department}, {Initiator}, {Chapter}, {Quantity}";
        }

        [Name("№ п/п")]
        public string Number { get; set; }


        [Name("Документ")]
        public string Document { get; set; }


        [Name("Организация")]
        public string Organization { get; set; }


        [Name("Дата замечания")]
        public DateTime? DateDay { get; set; }


        [Name("Подразделение инициатора")]
        public string Department { get; set; }


        [Name("Инициатор (ФИО)")]
        public string Initiator { get; set; }


        [Name("№ и название раздела")]
        public string Chapter { get; set; }


        [Name("Количество")]
        public int? Quantity { get; set; }


        //public ExampleForReader(string a, string b, string c, DateTime? d, string e, string f, string g, int? h)
        //{
        //    Number = a;
        //    Document = b;
        //    Organization = c;
        //    DateDay = d;
        //    Department = e;
        //    Initiator = f;
        //    Chapter = g;
        //    Quantity = h;

        //}

    }
}
