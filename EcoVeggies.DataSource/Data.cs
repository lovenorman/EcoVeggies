using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EcoVeggies.DataSource
{
    public class Data
    {
        public string GetData()
        {
            var path = @"C:\Users\love_\source\repos\EcoVeggies\EcoVeggies.DataSource\JSONDataSource\Products.json";
            var jsonResponse = File.ReadAllText(path);
            return jsonResponse;
        }

    }
}
