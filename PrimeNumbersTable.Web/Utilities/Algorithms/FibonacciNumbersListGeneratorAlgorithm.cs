namespace PrimeNumbersTable.Web.Utilities.Algorithms
{
    public interface IFibonacciNumbersListGeneratorAlgorithm
    {
        int[] GetListOfFirstNFibonacciNumbers(int totalOfNumbersExpected);
    }

    public class FibonacciNumbersListGeneratorAlgorithm : IFibonacciNumbersListGeneratorAlgorithm
    {
        private int[] _listOfFibonacciNumbers;

        public int[] GetListOfFirstNFibonacciNumbers(int totalOfNumbersExpected)
        {
            InitializeListOfFibonacciNumbers(totalOfNumbersExpected);

            for (var positionOnTheList = 2; positionOnTheList < totalOfNumbersExpected; positionOnTheList++)
            {
                CalculateValueFor(positionOnTheList);
            }

            return _listOfFibonacciNumbers;
        }

        private void CalculateValueFor(int positionOnTheList)
        {
            _listOfFibonacciNumbers[positionOnTheList] =
                _listOfFibonacciNumbers[positionOnTheList - 1] + _listOfFibonacciNumbers[positionOnTheList - 2];
        }

        private void InitializeListOfFibonacciNumbers(int totalOfNumbersExpected)
        {
            _listOfFibonacciNumbers = new int[totalOfNumbersExpected];

            _listOfFibonacciNumbers[0] = 1;

            if (totalOfNumbersExpected >= 2)
                _listOfFibonacciNumbers[1] = 1;
        }

    }
}