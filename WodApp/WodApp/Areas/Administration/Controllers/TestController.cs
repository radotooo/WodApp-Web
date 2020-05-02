using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WodApp.Areas.Administration.Controllers
{

    [Area("Administration")]
    public class TestController : Controller
    {
        
        [Authorize(Policy = "AdminOnly")]

        public IActionResult Index()
        {
            return View();
        }
    }
}