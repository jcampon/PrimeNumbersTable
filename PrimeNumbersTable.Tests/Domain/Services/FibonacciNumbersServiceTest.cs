using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PrimeNumbersTable.Web;
using PrimeNumbersTable.Web.Domain.Services;

namespace PrimeNumbersTable.Tests.Domain.Services
{
    [TestFixture]
    public class when_working_with_the_FibonacciNumbersService
    {
        protected Mock<IFibonacciNumbersService> ServiceMock;

        [SetUp]
        protected void SetUpService()
        {
            this.ServiceMock = new Mock<IFibonacciNumbersService>();
        }
    }

    [TestFixture]
    public class and_getting_a_list_of_fibonacci_numbers : when_working_with_the_FibonacciNumbersService
    {
        [Test]
        public void then_the_list_returned_contains_the_expected_number_of_elements()
        {
            // Arrange
            var totalOfNumbersExpected = 7;
            SetUpGetListOfFibonacciNumbersMethod(totalOfNumbersExpected);

            // Act
            var listOfNumbersGenerated = base.ServiceMock.Object.GetListOfFibonacciNumbers(totalOfNumbersExpected);

            // Assert
            Assert.That(listOfNumbersGenerated, Is.Not.Null);
            Assert.That(listOfNumbersGenerated.Length, Is.EqualTo(totalOfNumbersExpected));
        }

        private void SetUpGetListOfFibonacciNumbersMethod(int totalOfNumbers)
        {
            var listOfNumbers = new int[totalOfNumbers];

            ServiceMock.Setup(x => x.GetListOfFibonacciNumbers(totalOfNumbers)).Returns(listOfNumbers);
        }
    }

}
