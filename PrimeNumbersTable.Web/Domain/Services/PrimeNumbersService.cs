using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbersTable.Web.Domain.Services
{
    public interface IPrimeNumbersService
    {
        int[] GetListOfPrimeNumbers(int totalOfPrimeNumbers);
    }

    public class PrimeNumbersService
    {
        public int[] GetListOfPrimeNumbers(int totalOfPrimeNumbers)
        {
            return new int[totalOfPrimeNumbers];
        }
    }
}