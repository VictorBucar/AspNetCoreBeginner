using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mywebapp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mywebapp.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        //private readonly IDateTimeAppService _dateTime;
        

        //public HomeController(IDateTimeAppService dateTime)
        //{
        //    _dateTime = dateTime;
        //}
        public IActionResult Index()
        {

            return View();
        }
    }
}