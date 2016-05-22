using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace PrimeNumbersTable.Web.Domain.Repositories
{
    public interface IPrimeNumbersRepository
    {
        int[] GetListOfPrimeNumbers(int totalOfPrimeNumbers);
    }

    public class PrimeNumbersRepository
    {
        public int[] GetListOfPrimeNumbers(int totalOfPrimeNumbers)
        {
            // Here's where we're going to instantiate our prime numbers generation algorithm and make use of it
            throw new NotImplementedException();
        }
    }
}