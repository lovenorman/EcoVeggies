using EcoVeggies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.DataAccess
{
    public interface IProduct
    {
        IEnumerable<Item> GetAll();

        Item GetByName(string Name);

        Item GetById(int Id);
    }
}
