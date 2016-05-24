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
            var model = new UserInputDisplayModel() { TotalOfPrimeNumbers = 10 }; // 10 prime numbers by default

            return View(model);
        }
    }
}