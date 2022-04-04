using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAttribute;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Reflection;
using TableOfPartners;

namespace Reader
{
    public class ExampleForReader
    {
       
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

        //[JsonConverter(typeof(UnixTimeToDatetimeConverter))]
       // [JsonProperty("DateDayFS", ItemConverterType = typeof(JavaScriptDateTimeConverter))]
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

        
        public ExampleForReader(string a, string b, Partners c, string d, DateTime e, string f, string g, string h, string i)
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

        //class UnixTimeToDatetimeConverter : DateTimeConverterBase
        //{
        //    private static readonly DateTime _epoch =
        //        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);


        //    public override void WriteJson(JsonWriter writer, object value,
        //        JsonSerializer serializer)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public override object ReadJson(JsonReader reader, Type objectType,
        //        object existingValue, JsonSerializer serializer)
        //    {
        //        if (reader.Value == null)
        //        {
        //            return null;
        //        }

        //        return _epoch.AddSeconds(Convert.ToDouble(reader.Value)).ToLocalTime();
        //    }
        //}

    }
}
