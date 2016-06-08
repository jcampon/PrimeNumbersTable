using NUnit.Framework;
using PrimeNumbersTable.Web.Utilities.Algorithms;

namespace PrimeNumbersTable.Tests.Utilities.Algorithms
{
    [TestFixture]
    public class when_working_with_the_fibonacci_numbers_list_generator_algorithm
    {
        private IFibonacciNumbersListGeneratorAlgorithm _algorithm;

        [SetUp]
        public void SetUp()
        {
            _algorithm = new FibonacciNumbersListGeneratorAlgorithm();
        }

        [Test]
        public void test_that_the_algorithm_instance_implements_the_IFibonacciNumbersListGeneratorAlgorithm_interface()
        {
            // Assert
            Assert.IsInstanceOf<IFibonacciNumbersListGeneratorAlgorithm>(_algorithm);
        }

        [Test]
        public void test_that_the_GetListOfFirstNFibonacciNumbers_method_returns_an_array_of_int()
        {
            // Act
            var fibonacciNumbers = _algorithm.GetListOfFirstNFibonacciNumbers(5);

            // Assert
            Assert.That(fibonacciNumbers, Is.InstanceOf(typeof(int[])));
        }

        [Test]
        public void test_that_the_returned_array_length_is_equal_to_the_total_of_numbers_expected()
        {
            // Act
            var fibonacciNumbers = _algorithm.GetListOfFirstNFibonacciNumbers(5);

            // Assert
            Assert.That(fibonacciNumbers.Length, Is.EqualTo(5));
        }
    }

    public interface IFibonacciNumbersListGeneratorAlgorithm
    {
        int[] GetListOfFirstNFibonacciNumbers(int totalOfNumbersExpected);
    }

    public class FibonacciNumbersListGeneratorAlgorithm : IFibonacciNumbersListGeneratorAlgorithm
    {
        public int[] GetListOfFirstNFibonacciNumbers(int totalOfNumbersExpected)
        {
            return new int[totalOfNumbersExpected]; 
        }
    }

}
