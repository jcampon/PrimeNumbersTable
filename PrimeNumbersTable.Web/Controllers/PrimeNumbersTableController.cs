﻿using System;
using System.Collections.Generic;
using System.Configuration;
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

        private int BiggestInputNumberAllowed = GetBiggestInputNumberAllowed();

        public PrimeNumbersTableController(IPrimeNumbersService primeNumbersService)
        {
            this._primeNumbersService = primeNumbersService;
        }

        [OutputCache(Duration = 30, VaryByParam = "totalOfPrimeNumbers")]
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

        private static int GetBiggestInputNumberAllowed()
        {
            var biggestInputValue = 1;

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["BiggestInputNumberAllowed"]))
            {
                if(!int.TryParse(ConfigurationManager.AppSettings["BiggestInputNumberAllowed"], out biggestInputValue))
                    throw new ConfigurationErrorsException("The default value for 'BiggestInputNumberAllowed' is missing or incorrect on web.config");
            }

            return biggestInputValue;
        }
    }
}
