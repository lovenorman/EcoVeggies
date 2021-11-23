using EcoVeggies.DataAccess;
using EcoVeggies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoVeggies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProduct _product;
        
        public List<Item> Products { get; set; }
        public List<Item> FoundItem { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        //Constructor
        public IndexModel(IProduct product)
        {
            _product = product;
            Products = _product.GetAll().ToList();
        }
        public void OnPost()
        {
           
        }

        public IActionResult OnGetAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                RedirectToPage("/index");
            }
            else
            {
                //FoundItem = Products
                //    .Where(a => a.Name.Contains(searchString))
                //    .FirstOrDefault();

                Products = Products.Where(p => p.Name.ToLower().Contains(searchString.ToLower())).ToList();
                
            }
            return Page();

        }
    }
}
