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
        [TestCase(1, 1)]
        [TestCase(5, 5)]
        public void test_that_the_returned_array_length_is_equal_to_the_total_of_numbers_expected(int inputProvided, int lengthExpected)
        {
            // Act
            var fibonacciNumbers = _algorithm.GetListOfFirstNFibonacciNumbers(inputProvided);

            // Assert
            Assert.That(fibonacciNumbers.Length, Is.EqualTo(lengthExpected));
        }

        [Test]
        public void test_that_the_first_two_elements_of_the_list_are_equal_to_one()
        {
            // Act
            var fibonacciNumbers = _algorithm.GetListOfFirstNFibonacciNumbers(5);

            // Assert
            Assert.That(fibonacciNumbers[0], Is.EqualTo(1));
            Assert.That(fibonacciNumbers[1], Is.EqualTo(1));
        }

        [Test]
        [TestCase(20, 2)]
        [TestCase(20, 10)]
        [TestCase(20, 19)]
        public void test_that_a_given_element_of_the_list_greater_than_the_second_is_the_sum_of_the_previous_two_elements(int lengthOfList, int arrayItemToValidate)
        {
            // Act
            var fibonacciNumbers = _algorithm.GetListOfFirstNFibonacciNumbers(lengthOfList);

            // Assert
            Assert.That(fibonacciNumbers[arrayItemToValidate], Is.GreaterThan(0));
            Assert.That(fibonacciNumbers[arrayItemToValidate], Is.EqualTo(fibonacciNumbers[arrayItemToValidate - 1] + 
                                                                          fibonacciNumbers[arrayItemToValidate - 2]));
        }
    }
}
