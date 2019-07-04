using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WorldClient
{
    [DataContract(Name="City")]
    public class CityParser
    {
        [DataMember(Name = "id")]
        public int Id;
        [DataMember(Name = "name")]
        public string Name;
        [DataMember(Name = "countryCode")]
        public string CountryCode;
        [DataMember(Name = "district")]
        public string District;
        [DataMember(Name = "population")]
        public int Population;
    }
}
