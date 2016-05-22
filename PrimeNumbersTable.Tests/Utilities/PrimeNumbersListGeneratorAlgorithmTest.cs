using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PrimeNumbersTable.Web;
using PrimeNumbersTable.Web.Domain.Services;
using PrimeNumbersTable.Web.Utilities;

namespace PrimeNumbersTable.Tests.Utilities
{
    [TestFixture]
    public class when_working_with_the_basic_prime_numbers_list_generator_algorithm
    {
        protected IPrimeNumbersListGeneratorAlgorithm _basicAlgorithmStub;

        [SetUp]
        public void Setup()
        {
            _basicAlgorithmStub = new BasicPrimeNumbersListGeneratorAlgorithm();
        }
    }

    [TestFixture]
    public class and_request_a_list_of_the_n_first_prime_numbers : when_working_with_the_basic_prime_numbers_list_generator_algorithm
    {
        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void then_the_list_we_get_must_contain_n_numbers(int totalOfNumbersExpected)
        {
            // Act
            var listOfNumbersGenerated = base._basicAlgorithmStub.GetListOfFirstNPrimeNumbers(totalOfNumbersExpected);

            // Assert
            Assert.That(listOfNumbersGenerated, Is.Not.Null);
            Assert.That(listOfNumbersGenerated.Length, Is.EqualTo(totalOfNumbersExpected));
        }
    }
}
