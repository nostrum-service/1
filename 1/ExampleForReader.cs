using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAttribute;
using Newtonsoft.Json;

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
        [JsonProperty("NumberFS")]
        [Name("№ п/п")]
        public string Number { get; set; }

        [JsonProperty("DocumentFS")]
        [Name("Документ")]
        public string Document { get; set; }

        [JsonProperty("OrganizationFS")]
        [Name("Организация")]
        public string Organization { get; set; }

        [JsonProperty("DateDayFS")]
        [Name("Дата замечания")]
        public string DateDay { get; set; }

        [JsonProperty("DepartmentFS")]
        [Name("Подразделение инициатора")]
        public string Department { get; set; }

        [JsonProperty("InitiatorFS")]
        [Name("Инициатор (ФИО)")]
        public string Initiator { get; set; }

        [JsonIgnore]
        [Name("№ и название раздела")]
        public string Chapter { get; set; }

        [JsonProperty("QuantityFS")]
        [Name("Количество")]
        public string Quantity { get; set; }


        public ExampleForReader(string a, string b, string c, string d, string e, string f, string g, string h)
        {
            Number = a;
            Document = b;
            Organization = c;
            DateDay = d;
            Department = e;
            Initiator = f;
            Chapter = g;
            Quantity = h;

        }

    }
}
