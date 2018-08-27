using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mywebapp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mywebapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDateTimeAppService _dateTime;

        public string Time { get; private set; } = "Page Model in C#";

        public IndexModel(IDateTimeAppService dateTime)
        {
            _dateTime = dateTime;

        }

        public IActionResult OnGet()
        {
            var serverTime = _dateTime.Now;
            ViewData["Data"] = serverTime;

            ViewData["IP"] = HttpContext.Connection.LocalIpAddress.ToString();
            HttpContext.Session.SetString("TestText", "Hi, this is a test from your code behind at " + DateTime.Now.ToString());


            Time += $"Server time from {DateTime.Now}";
            return Page();
        }
    }
}