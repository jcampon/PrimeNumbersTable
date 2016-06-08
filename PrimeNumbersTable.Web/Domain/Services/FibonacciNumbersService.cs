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
        int[] GetListOfFibonacciNumbers(int totalOfPrimeNumbers);
    }

    class FibonacciNumbersService : IFibonacciNumbersService
    {
        public int[] GetListOfFibonacciNumbers(int totalOfPrimeNumbers)
        { 
            return new int[totalOfPrimeNumbers];
        }
    }
}