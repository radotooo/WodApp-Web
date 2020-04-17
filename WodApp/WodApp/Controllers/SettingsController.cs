using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WodApp.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Test"] = "http://res.cloudinary.com/radotooo/image/upload/v1587114349/Test.png";
            return View();
        }
    }
}