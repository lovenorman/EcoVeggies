using EcoVeggies.Models;
using System;
using System.Collections.Generic;

namespace EcoVeggies.DataAccess
{
    public interface IOrder
    {
        IEnumerable<Order> GetAll();
        Order GetById(Guid Id);
        void SaveOrder(Order order);

    }
}
