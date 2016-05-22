using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeNumbersTable.Web.Domain.Services;
using PrimeNumbersTable.Web.Models;

namespace PrimeNumbersTable.Web.Controllers
{
    public class PrimeNumbersTableController : Controller
    {
        private readonly IPrimeNumbersService _primeNumbersService;

        public PrimeNumbersTableController(IPrimeNumbersService primeNumbersService)
        {
            this._primeNumbersService = primeNumbersService;
        }

        // GET: PrimeNumbersTable/Generate/5
        public ActionResult Generate(int totalOfPrimeNumbers)
        {
            var primeNumbersTableDisplayModel = new PrimeNumbersTableDisplayModel(totalOfPrimeNumbers)
            {
                ListOfPrimeNumbers = this._primeNumbersService.GetListOfPrimeNumbers(totalOfPrimeNumbers)
            };

            return View(primeNumbersTableDisplayModel);
        }
    }
}
