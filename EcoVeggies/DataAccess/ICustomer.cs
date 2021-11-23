using EcoVeggies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.DataAccess
{
    public interface ICustomer
    {
        public IEnumerable<Customer> GetAll();

        public Customer GetById(int id);
    }
}
