using System;

namespace PrimeNumbersTable.Web.Utilities
{
    public class BasicPrimeNumbersListGeneratorAlgorithm : IPrimeNumbersListGeneratorAlgorithm
    {
        public int[] GetListOfFirstNPrimeNumbers(int numberOfPrimeNumbers)
        {
            return new int[numberOfPrimeNumbers];
        }
    }
}