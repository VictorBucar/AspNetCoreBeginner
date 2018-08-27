using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mywebapp.Infra.Data.Context;
using System;

namespace mywebapp.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly MyWebAppContext _myWebAppContext;

        public EditModel(MyWebAppContext myWebAppContext)
        {
            _myWebAppContext = myWebAppContext;
        }


        public Application.Models.Customer Customer { get; set; }

        public IActionResult OnGet(int id)
        {
            Customer =  _myWebAppContext.Customers.Find(id);

            if (Customer == null)
            {
                return Redirect("/Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _myWebAppContext.Attach(Customer).State = EntityState.Modified;

            try
            {
                _myWebAppContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            { 
                throw new Exception($"Customer {Customer.Id} not found. Exception error {e.Message}");
            }

            Redirect("/Index").Permanent = false;

            return Redirect("/Index");
        }
    }
}