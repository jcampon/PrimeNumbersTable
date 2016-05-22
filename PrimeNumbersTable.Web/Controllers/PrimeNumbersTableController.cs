using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeNumbersTable.Web.Models;

namespace PrimeNumbersTable.Web.Controllers
{
    public class PrimeNumbersTableController : Controller
    {

        // GET: PrimeNumbersTable/Generate/5
        public ActionResult Generate(int totalOfPrimeNumbers)
        {
            var primeNumbersTableDisplayModel = new PrimeNumbersTableDisplayModel(totalOfPrimeNumbers);

            return View(primeNumbersTableDisplayModel);
        }
    }
}
