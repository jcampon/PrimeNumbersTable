using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrimeNumbersTable.Web.Utilities;
using PrimeNumbersTable.Web.Utilities.Algorithms;

namespace PrimeNumbersTable.Web.Domain.Services
{
    public interface IPrimeNumbersService
    {
        int[] GetListOfPrimeNumbers(int totalOfPrimeNumbers);
    }

    public class PrimeNumbersService : IPrimeNumbersService
    {
        private readonly IPrimeNumbersListGeneratorAlgorithm _algorithm;

        public PrimeNumbersService(IPrimeNumbersListGeneratorAlgorithm algorithm)
        {
            //TODO: if we ever have more than one algorithm available then we could implement a factory to return the specific algorithm that we want
            this._algorithm = algorithm;
        }

        public int[] GetListOfPrimeNumbers(int totalOfPrimeNumbers)
        {
            return this._algorithm.GetListOfFirstNPrimeNumbers(totalOfPrimeNumbers);
        }
    }
}