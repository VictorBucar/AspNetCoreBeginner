using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mywebapp.Infra.Data.Context;
using mywebapp.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mywebapp.Pages.Customer
{
    public class CreateModel : PageModel
    {

        private readonly MyWebAppContext _myAppContext;


        public CreateModel(MyWebAppContext myAppContext)
        {
            _myAppContext = myAppContext;
        }

        [BindProperty]
        public Application.Models.Customer Customer { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _myAppContext.Customers.Add(Customer);
            await _myAppContext.SaveChangesAsync();
            return RedirectToPage("/Index");
        }


        public void OnGet()
        {

        }
    }
}