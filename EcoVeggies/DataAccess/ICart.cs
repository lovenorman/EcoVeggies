using EcoVeggies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.DataAccess
{
    public interface ICart
    {
        IEnumerable<Item> GetAll();
        Item GetById(int Id);
        void SaveItem(Item cartItem);

    }
}
