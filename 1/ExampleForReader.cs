using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAttribute;
using Newtonsoft.Json;
using TableOfPartners;

namespace Reader
{
    public class ExampleForReader
    {
        public ExampleForReader()
        {
        }
        public override string ToString()
        {
            return $"Содержание строки {Number}, {Document}, {PartnerID}, {Organization}, {DateDay}, {Department}, {Initiator}, {Chapter}, {Quantity}";
        }
        [JsonProperty("NumberFS")]
        public string Number { get; set; }

        [JsonProperty("DocumentFS")]
        public string Document { get; set; }

        [JsonProperty("PartnerID")]
        public Partners PartnerID { get; set; }

        [JsonProperty("OrganizationFS")]
        public string Organization { get; set; }

        [JsonProperty("DateDayFS")]
        public DateTime DateDay { get; set; }

        [JsonProperty("DepartmentFS")]
        public string Department { get; set; }

        [JsonProperty("InitiatorFS")]
        public string Initiator { get; set; }

        [JsonIgnore]
        public string Chapter { get; set; }

        [JsonProperty("QuantityFS")]
        public string Quantity { get; set; }

        public List<Partners> Partners; 


        public ExampleForReader(string a, string b, string c, string d, DateTime e, string f, string g, string h, string i)
        {
            Number = a;
            Document = b;
            PartnerID = c;
            Organization = d;
            DateDay = e;
            Department = f;
            Initiator = g;
            Chapter = h;
            Quantity = i;

        }

    }
}
