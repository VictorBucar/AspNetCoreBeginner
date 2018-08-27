using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mywebapp.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace mywebapp.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly MyWebAppContext _myAppContext;

        public IndexModel(MyWebAppContext myAppContext)
        {
            _myAppContext = myAppContext;
        }

        public IList<Application.Models.Customer> Customers { get; private set; }

        public async Task OnGetAsync()
        {
            Customers = await _myAppContext.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await _myAppContext.Customers.FindAsync(id);

            if (contact != null)
            {
                _myAppContext.Customers.Remove(contact);
                await _myAppContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}