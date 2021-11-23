using EcoVeggies.DataSource;
using EcoVeggies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.DataAccess
{
    public class DesProducts : IProduct
    {
        private readonly Data datasource;

        public DesProducts(Data datasource)
        {
            this.datasource = datasource;
        }
        
        //Gets a list of all products, saved in jsonResponse
        public IEnumerable<Item> GetAll()
        {
            var jsonResponse = datasource.GetData();
            return JsonConvert.DeserializeObject<IEnumerable<Item>>(jsonResponse);
        }

        public Item GetByName(string Name)
        {
            
            var items = GetAll().ToList();
            //Letar efter name som matchar i listan "items" vi skapat
            var matchedItem = items.Find(item => item.Name == Name);
            return matchedItem;
        }

        public Item GetById(int Id)
        {
            var items = GetAll().ToList();
            //Letar efter id som matchar i listan "items" vi skapat
            var matchedItem = items.Find(item => item.Id == Id);
            return matchedItem;
        }
    }
}
