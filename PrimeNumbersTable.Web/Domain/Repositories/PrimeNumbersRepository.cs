using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using PrimeNumbersTable.Web.Utilities;

namespace PrimeNumbersTable.Web.Domain.Repositories
{
    public interface IPrimeNumbersRepository
    {
        int[] GetListOfPrimeNumbers(int totalOfPrimeNumbers);
    }

    public class PrimeNumbersRepository : IPrimeNumbersRepository
    {
        private IPrimeNumbersListGeneratorAlgorithm _algorithm;

        public PrimeNumbersRepository(IPrimeNumbersListGeneratorAlgorithm algorithm)
        {
            this._algorithm = algorithm;
        }

        public int[] GetListOfPrimeNumbers(int totalOfPrimeNumbers)
        {
            // Here's where we're going to instantiate our prime numbers generation algorithm and make use of it

            var listOfPrimeNumbers = this._algorithm.GetListOfFirstNPrimeNumbers(totalOfPrimeNumbers);

            return listOfPrimeNumbers;
        }
    }
}