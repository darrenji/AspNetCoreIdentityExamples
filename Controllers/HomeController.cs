using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentityExamples.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreIdentityExamples.Controllers
{
    public class HomeController : Controller
    {
       

        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            return View(new Dictionary<string, object> {
                ["Placeholder"] = "Placeholder"
            });
        }
    }
}
