using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using NLog;

namespace PrimeNumbersTable.Web.Utilities.Algorithms
{
    public class BasicPrimeNumbersListGeneratorAlgorithm : IPrimeNumbersListGeneratorAlgorithm
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private static int _countOfPrimeNumbersAlreadyStored = 5;
        private static int[] _listOfFirstNPrimeNumbersAlreadyStored;
        public static int[] ListOfFirstNPrimeNumbersAlreadyStored
        {
            get {
                return _listOfFirstNPrimeNumbersAlreadyStored ??
                       (_listOfFirstNPrimeNumbersAlreadyStored = new int[] {2, 3, 5, 7, 11});
            }
        }

        public int[] GetListOfFirstNPrimeNumbers(int firsNPrimeNumbersToFind)
        {
            var initialCountOfPrimeNumbersAlreadyStored = _countOfPrimeNumbersAlreadyStored;
            _logger.Debug("Started generating the requested first {0} prime numbers", firsNPrimeNumbersToFind);

            if (firsNPrimeNumbersToFind <= _countOfPrimeNumbersAlreadyStored)
            {
                _logger.Debug("Nothing recalculated. Returned cached data");
                return ListOfFirstNPrimeNumbersAlreadyStored.Take(firsNPrimeNumbersToFind).ToArray();
            }

            var lastSavedPrime = ListOfFirstNPrimeNumbersAlreadyStored.Last();
            ResizeListOfFirstNPrimeNumbers(firsNPrimeNumbersToFind);

            SearchForPrimeNumbers(firsNPrimeNumbersToFind, lastSavedPrime);

            _logger.Debug("Finished generating the next {0} prime numbers after {1}", 
                        firsNPrimeNumbersToFind - initialCountOfPrimeNumbersAlreadyStored, 
                        lastSavedPrime);
            return ListOfFirstNPrimeNumbersAlreadyStored;
        }

        private void ResizeListOfFirstNPrimeNumbers(int firsNPrimeNumbersToFind)
        {
            if (firsNPrimeNumbersToFind > ListOfFirstNPrimeNumbersAlreadyStored.Length)
            {
                Array.Resize(ref _listOfFirstNPrimeNumbersAlreadyStored, firsNPrimeNumbersToFind);
            }
        }

        private void SearchForPrimeNumbers(int firsNPrimeNumbersToFind, int lastSavedPrime)
        {
            for (var number = lastSavedPrime + 1; _countOfPrimeNumbersAlreadyStored < firsNPrimeNumbersToFind; number++)
            {
                var isPrime = true;

                for (var i = 0; (number/ListOfFirstNPrimeNumbersAlreadyStored[i]) >= ListOfFirstNPrimeNumbersAlreadyStored[i]; i++)
                {
                    if (number % ListOfFirstNPrimeNumbersAlreadyStored[i] != 0) continue;
                    isPrime = false;
                    break;
                }

                StoreNumberInArrayIfPrime(number, isPrime);
            }
        }

        private void StoreNumberInArrayIfPrime(int primeNumber, bool isPrime)
        {
            if (isPrime)
            {
                ListOfFirstNPrimeNumbersAlreadyStored[_countOfPrimeNumbersAlreadyStored++] = primeNumber;
            }
        }
    }

}