﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using NLog;
using PrimeNumbersTable.Web.Domain.Services;
using PrimeNumbersTable.Web.Models;
using StructureMap;

namespace PrimeNumbersTable.Web.Controllers
{
    public partial class PrimeNumbersTableController : Controller
    {
        private readonly IFibonacciNumbersService _numbersService;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private int BiggestInputNumberAllowed = GetBiggestInputNumberAllowed();

        public PrimeNumbersTableController(IFibonacciNumbersService numbersService)
        {
            this._numbersService = numbersService;
        }

        [OutputCache(Duration = 30, VaryByParam = "totalOfNumbers")]
        public virtual ActionResult Generate(int totalOfNumbers)
        {
            ValidateInput(totalOfNumbers);

            if (ModelState.IsValid)
            {
                _logger.Debug("Creating the PrimeNumbersTableDisplayModel in the controller");
                var primeNumbersTableDisplayModel = new NumbersTableDisplayModel(totalOfNumbers)
                {
                    ListOfNumbers = this._numbersService.GetListOfFibonacciNumbers(totalOfNumbers)
                };

                _logger.Debug("Returning the Generate view");
                return View(primeNumbersTableDisplayModel);
            }

            return RedirectToAction("Index", "Home");
        }

        private void ValidateInput(int totalOfPrimeNumbers)
        {
            if (totalOfPrimeNumbers <= 0 || totalOfPrimeNumbers > BiggestInputNumberAllowed)
            {
                ModelState.AddModelError("totalOfPrimeNumbers", 
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
