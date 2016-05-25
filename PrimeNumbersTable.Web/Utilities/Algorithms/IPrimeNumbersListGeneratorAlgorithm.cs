namespace PrimeNumbersTable.Web.Utilities.Algorithms
{
    public interface IPrimeNumbersListGeneratorAlgorithm
    {
        int[] GetListOfFirstNPrimeNumbers(int numberOfPrimeNumbers);
    }
}