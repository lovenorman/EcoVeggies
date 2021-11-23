using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoVeggies.DataAccess;
using EcoVeggies.DataSource;
using EcoVeggies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoVeggies.Pages
{
    public class PaymentModel : PageModel
    {
       
        private readonly ICustomer _customerDataAccess;
        private readonly ICart _cartDataAccess;
        private readonly IOrder orderDataAccess;


        //public Customer Customer;//Instance for properties

        public Order order { get; set; }
        public String Feedback { get; set; }//Sätt feedback
        public PaymentModel(ICustomer customerDataAccess, ICart cartDataAccess, IOrder orderDataAccess)
        {
            _customerDataAccess = customerDataAccess;
            _cartDataAccess = cartDataAccess;
            this.orderDataAccess = orderDataAccess;
        }
        public void OnGet(int id)//CustomerId from cart page
        {
            var customer = _customerDataAccess.GetById(id);//Gets Customer by id
            var items = _cartDataAccess.GetAll().ToList();//Gets all items in cart
            if (customer != null)//If there is a customer
            {
                //Create an order with CustomerId, items and sets an unique id
                order = new Order() {  CustomerId = id, ListCartItems = items, OrderId = Guid.NewGuid() };
               
                orderDataAccess.SaveOrder(order);//Via instance of IDesCart, call save cartItem
            }
        }
        //
        public IActionResult OnPostPayment()
        {
            Feedback = "";
            return Page();
        }
    }
}
