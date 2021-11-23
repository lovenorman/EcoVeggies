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
    public class MoreInfoModel : PageModel
    {
        public readonly IProduct _product;
        public Item Item { get; set; }

        public MoreInfoModel(IProduct product)
        {
            _product = product; 
        }
        
        public void OnGet(string name)
        {
            Item = _product.GetByName(name);
        }
    }
}
