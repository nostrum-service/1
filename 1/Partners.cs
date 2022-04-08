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
        
        public Partners(string a, int b)
        {
            NameOfPartner = a;
            PartnerID = b;
            
        }
    
    }
}
