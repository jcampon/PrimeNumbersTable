using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbersTable.Web.Utilities
{
    public interface IPrimeNumbersListGeneratorAlgorithm
    {
        int[] GetListOfFirstNPrimeNumbers(int numberOfPrimeNumbers);
    }
}