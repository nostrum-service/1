using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reader;

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
        //    ExamplesForReader = new List<ExampleForReader>();
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

        //public Partners this[int index] { get; set; }
    }
}
