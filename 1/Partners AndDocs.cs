using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reader;
using Newtonsoft.Json;

namespace PartnersAndDocs
{
    public class PartnersDocsClass
    {

        public override string ToString()
        {
            return $"Содержание строки {ParForDocs}, {Documents}";
        }
        public List<PartnersForDocs> ParForDocs { get; set; }
        public List<Docs> Documents { get; set; }
        public class PartnersForDocs
        {
            public string NameOfPartner { get; set; }
            public int PartnerID { get; set; }

            public PartnersForDocs(string a, int b)
            {
                NameOfPartner = a;
                PartnerID = b;

            }
        }
        public class Docs
        {

            [JsonProperty("NumberFS")]
            public string Number { get; set; }

            [JsonProperty("DocumentFS")]
            public string Document { get; set; }

            [JsonProperty("PartnerID")]
            public PartnersDocsClass PartnerID { get; set; }

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


            public Docs(string a, string b, PartnersDocsClass c, string d, DateTime e, string f, string g, string h, string i)
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
}
