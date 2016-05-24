using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PrimeNumbersTable.Web.Domain.Services;
using PrimeNumbersTable.Web.Models;
using StructureMap;

namespace PrimeNumbersTable.Web.Controllers
{
    public partial class PrimeNumbersTableController : Controller
    {
        private readonly IPrimeNumbersService _primeNumbersService;
        
        private const int BiggestInputNumberAllowed = 500; //TODO: set this value up in web.config and read it from there

        public PrimeNumbersTableController(IPrimeNumbersService primeNumbersService)
        {
            this._primeNumbersService = primeNumbersService;
        }

        //[AcceptVerbs("Get", "Post")]
        public virtual ActionResult Generate(int totalOfPrimeNumbers)
        {
            ValidateInput(totalOfPrimeNumbers);

            if (ModelState.IsValid)
            {
                var primeNumbersTableDisplayModel = new PrimeNumbersTableDisplayModel(totalOfPrimeNumbers)
                {
                    ListOfPrimeNumbers = this._primeNumbersService.GetListOfPrimeNumbers(totalOfPrimeNumbers)
                };

                return View(primeNumbersTableDisplayModel);
            }

            return RedirectToAction(MVC.Home.Index());
        }

        private void ValidateInput(int totalOfPrimeNumbers)
        {
            if (totalOfPrimeNumbers <= 0 || totalOfPrimeNumbers > BiggestInputNumberAllowed)
            {
                ModelState.AddModelError(MVC.PrimeNumbersTable.GenerateParams.totalOfPrimeNumbers, 
                                         "Error: the value provided must be a number between 1 and " + BiggestInputNumberAllowed);
            }
        }
    }
}
