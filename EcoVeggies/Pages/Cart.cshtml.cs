using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoVeggies.DataAccess;
using EcoVeggies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoVeggies.Pages
{
    public class CartModel : PageModel
    {
        private readonly ICart cartDataAccess;
        private readonly IProduct productDataAccess;
        
        [BindProperty]
        public int OrderId { get; set; }

        [BindProperty]
        public int CustomerId { get; set; }

        public List<Item> ListCartItems { get; set; }
        public CartModel(ICart cartDataAccess, IProduct productDataAccess)
        {
            ListCartItems = new List<Item>();
            this.cartDataAccess = cartDataAccess;
            this.productDataAccess = productDataAccess;
        }
        public void OnGet(int Id)//Takes in id from button
        {
            var items = this.cartDataAccess.GetAll().ToList();//Gets all data from json and converts to list

            if (items.Count != 0) //If there is a list
            {
                ListCartItems.AddRange(items); //Adds items to the list
            }

            if (Id != 0)//If id is everything but 0
            {
                var cartItem = productDataAccess.GetById(Id);//saves the item "id" in var "cartItem"
                ListCartItems.Add(cartItem);//Add cartItem to the list "CartItems"
                cartDataAccess.SaveItem(cartItem);//Via instance of IDesCart, call save cartItem
            }
        }

        public IActionResult OnPostPlaceOrder()
        {
            return RedirectToPage("/Payment", new { id = CustomerId });//Saves CustomerId in "id" and sends to /Payment, OnGet()
        }
    }
}
