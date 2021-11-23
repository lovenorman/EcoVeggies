using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.Models
{
    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imgsrc")]
        public string ImageSrc { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

    }
}
