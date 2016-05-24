using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeNumbersTable.Web.Models;

namespace PrimeNumbersTable.Web.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            var model = new UserInputDisplayModel() { NumberOfPrimes = 10 };

            return View(model);
        }
    }
}