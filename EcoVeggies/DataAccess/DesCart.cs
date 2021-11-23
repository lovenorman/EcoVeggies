using EcoVeggies.DataSource;
using EcoVeggies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.DataAccess
{
    public class DesCart : ICart
    {
        private readonly DataCart datasource;

        public DesCart(DataCart datasource)
        {
            this.datasource = datasource;
        }

        //Gets a list of all products, saves in jsonResponse
        public IEnumerable<Item> GetAll()
        {
            var jsonResponse = datasource.GetData();
            return JsonConvert.DeserializeObject<IEnumerable<Item>>(jsonResponse);
        }

        public Item GetById(int Id)
        {
            var allItems = GetAll().ToList();
            //Finds id that matches id in list "allItems"
            var matchedItem = allItems.Find(item => item.Id == Id);
            return matchedItem;
        }

        public void SaveItem(Item cartItem)
        {
            var jsonResponse = datasource.GetData();
            var desItems = JsonConvert.DeserializeObject<IEnumerable<Item>>(jsonResponse).ToList();

            //Adds cartItem to the created list 
            desItems.Add(cartItem);

            //DesItems serializes and is saved in "serializedItems"
            var serializedItems = JsonConvert.SerializeObject(desItems);
            //Calls method in "DataCArt" for saving item, sends "serializedItems"
            datasource.Save(serializedItems);
        }
    }
}
