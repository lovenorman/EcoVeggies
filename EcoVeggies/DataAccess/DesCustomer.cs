using EcoVeggies.DataSource;
using EcoVeggies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.DataAccess
{
    public class DesCustomer : ICustomer
    {
        private readonly DataCustomer datasource;

        public DesCustomer(DataCustomer datasource)
        {
            this.datasource = datasource;
        }

        //Gets a list of all customers, saves in jsonResponse
        public IEnumerable<Customer> GetAll()
        {
            var jsonResponse = datasource.GetData();
            return JsonConvert.DeserializeObject<IEnumerable<Customer>>(jsonResponse);
        }
        public Customer GetById(int Id)
        {
            var customer = GetAll().ToList();
            var matchedItem = customer.Find(customer => customer.Id == Id);//Letar efter id som matchar i listan "customer" vi skapat
            return matchedItem;
        }

    }
}
