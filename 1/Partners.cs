using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reader;
using Newtonsoft.Json;

namespace TableOfPartners
{
    public class Partners
    {
             
        public string NameOfPartner { get; set; }
        public int PartnerID { get; set; }
        //public ExampleForReader DocumentIDOfPartner { get; set; }
        //public List<ExampleForReader> ExamplesForReader { get; set; }

        //public Partners()
        //{
           
        //}

        //public virtual void AddDocuments(ExampleForReader ExampleForReader)
        //{
        //    ExampleForReader.PartnerID = this;
        //    ExamplesForReader.Add(ExampleForReader);
        //}
        public Partners(string a, int b)
        {
            NameOfPartner = a;
            PartnerID = b;
            
        }

        //public class ExampleForReader
        //{

        //   [JsonProperty("NumberFS")]
        //    public string Number { get; set; }

        //    [JsonProperty("DocumentFS")]
        //    public string Document { get; set; }

        //    [JsonProperty("PartnerID")]
        //    public Partners PartnerID { get; set; }

        //    [JsonProperty("OrganizationFS")]
        //    public string Organization { get; set; }

        //    [JsonProperty("DateDayFS")]
        //    public DateTime DateDay { get; set; }

        //    [JsonProperty("DepartmentFS")]
        //    public string Department { get; set; }

        //    [JsonProperty("InitiatorFS")]
        //    public string Initiator { get; set; }

        //    [JsonIgnore]
        //    public string Chapter { get; set; }

        //    [JsonProperty("QuantityFS")]
        //    public string Quantity { get; set; }


        //    public ExampleForReader(string a, string b, Partners c, string d, DateTime e, string f, string g, string h, string i)
        //    {
        //        Number = a;
        //        Document = b;
        //        PartnerID = c;
        //        Organization = d;
        //        DateDay = e;
        //        Department = f;
        //        Initiator = g;
        //        Chapter = h;
        //        Quantity = i;

        //    }

        //}
    
    }
}
