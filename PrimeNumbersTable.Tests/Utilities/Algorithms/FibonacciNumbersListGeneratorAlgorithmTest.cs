using NUnit.Framework;
using PrimeNumbersTable.Web.Utilities.Algorithms;

namespace PrimeNumbersTable.Tests.Utilities.Algorithms
{
    [TestFixture]
    public class when_working_with_the_fibonacci_numbers_list_generator_algorithm
    {
        [Test]
        public void test_that_the_algorithm_instance_implements_the_IFibonacciNumbersListGeneratorAlgorithm_interface()
        {
            // Arrange
            var algorithm = new FibonacciNumbersListGeneratorAlgorithm();

            // Assert
            Assert.IsInstanceOf<IFibonacciNumbersListGeneratorAlgorithm>(algorithm);
        }

        [Test]
        public void test_that_the_GetListOfFirstNFibonacciNumbers_method_returns_an_array_of_int()
        {
            
            // Assert
            Assert.That(fibonacciNumbers, Is.InstanceOf(typeof(int[])));
        }
    }

    public interface IFibonacciNumbersListGeneratorAlgorithm
    {

    }

    public class FibonacciNumbersListGeneratorAlgorithm : IFibonacciNumbersListGeneratorAlgorithm
    {

    }

}
