using EcoVeggies.DataSource;
using EcoVeggies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.DataAccess
{
    public class DesOrder : IOrder
    {
        private readonly DataOrder datasource;

        public DesOrder(DataOrder datasource)
        {
            this.datasource = datasource;
        }

        //Gets a list of all orders, saves in jsonResponse
        public IEnumerable<Order> GetAll()
        {
            var jsonResponse = datasource.GetData();
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(jsonResponse);
        }

        public Order GetById(Guid orderId)
        {
            var allOrders = GetAll().ToList();
            //Finds id that matches id in list "allItems"
            //If there ís a problem with "==" use "Equals()"
            var matchedItem = allOrders.Find(order => order.OrderId == orderId);//Dubbelkolla ID
            return matchedItem;
        }

        public void SaveOrder(Order order)
        {
            var jsonResponse = datasource.GetData();
            var desOrder = JsonConvert.DeserializeObject<IEnumerable<Order>>(jsonResponse).ToList();

            //Adds order to the created list 
            desOrder.Add(order);

            //DesItems serializes and is saved in "serializedItems"
            var serializedItems = JsonConvert.SerializeObject(desOrder);
            //Calls method in "DataCArt" for saving item, sends "serializedItems"
            datasource.Save(serializedItems);
        }
        
    }
}
