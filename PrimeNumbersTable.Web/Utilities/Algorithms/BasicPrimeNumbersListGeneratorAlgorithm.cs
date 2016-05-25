namespace PrimeNumbersTable.Web.Utilities.Algorithms
{
    public class BasicPrimeNumbersListGeneratorAlgorithm : IPrimeNumbersListGeneratorAlgorithm
    {
        public int[] GetListOfFirstNPrimeNumbers(int firsNPrimeNumbers)
        {
            var listOfFirstNPrimeNumbers = new int[firsNPrimeNumbers];

            // Special handling for the integer 2 which is the first prime
            var countOfPrimesFoundAlready = 0;
            listOfFirstNPrimeNumbers[countOfPrimesFoundAlready++] = 2;

            // Looping from 3, to the limit
            for (var number = 3; countOfPrimesFoundAlready < firsNPrimeNumbers; number++)
            {
                var isPrime = true;

                for (var i = 0; (number / listOfFirstNPrimeNumbers[i]) >= listOfFirstNPrimeNumbers[i]; i++)
                {
                    if (number % listOfFirstNPrimeNumbers[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                // Store the prime number and increment the count
                if (isPrime)
                {
                    listOfFirstNPrimeNumbers[countOfPrimesFoundAlready++] = number;
                }
            }

            return listOfFirstNPrimeNumbers;
        }
    }
}