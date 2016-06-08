using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrimeNumbersTable.Web.Utilities;
using PrimeNumbersTable.Web.Utilities.Algorithms;

namespace PrimeNumbersTable.Web.Domain.Services
{
    public interface IFibonacciNumbersService
    {
        int[] GetListOfFibonacciNumbers(int totalOfFibonacciNumbers);
    }

    class FibonacciNumbersService : IFibonacciNumbersService
    {
        private readonly IFibonacciNumbersListGeneratorAlgorithm _algorithm;

        public FibonacciNumbersService(IFibonacciNumbersListGeneratorAlgorithm algorithm)
        {
            this._algorithm = algorithm;
        }

        public int[] GetListOfFibonacciNumbers(int totalOfFibonacciNumbers)
        {
            return this._algorithm.GetListOfFirstNFibonacciNumbers(totalOfFibonacciNumbers);
        }
    }
}