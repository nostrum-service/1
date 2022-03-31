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
        public Partners()
        {
        }
       
        public string NameOfPartner { get; set; }
        public string PartnerID { get; set; }
        //public ExampleForReader DocumentIDOfPartner { get; set; }

        public Partners(string a, string b)
        {
            NameOfPartner = a;
            PartnerID = b;
            
        }

        //public Partners this[int index] { get; set; }
    }
}
