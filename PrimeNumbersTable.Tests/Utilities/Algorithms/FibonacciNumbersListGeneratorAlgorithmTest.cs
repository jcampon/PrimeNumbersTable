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
    }

    public interface IFibonacciNumbersListGeneratorAlgorithm
    {

    }

    public class FibonacciNumbersListGeneratorAlgorithm
    {

    }

}
