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
    public class when_working_with_the_PrimeNumbersService
    {
        protected Mock<IPrimeNumbersService> ServiceMock;

        [SetUp]
        protected void SetUpService()
        {
            this.ServiceMock = new Mock<IPrimeNumbersService>();
        }
    }

    [TestFixture]
    public class and_getting_a_list_of_prime_numbers: when_working_with_the_PrimeNumbersService
    {
        private void SetUpGetListOfPrimeNumbersMethod(int totalOfNumbers)
        {
            var listOfNumbers = new int[totalOfNumbers];

            base.ServiceMock.Setup(x => x.GetListOfPrimeNumbers(totalOfNumbers)).Returns(listOfNumbers);
        }

        [Test]
        public void then_a_list_of_numbers_is_returned()
        {
            // Arrange
            var totalOfNumbersExpected = 5;
            SetUpGetListOfPrimeNumbersMethod(totalOfNumbersExpected);

            // Act
            var listOfNumbersGenerated = base.ServiceMock.Object.GetListOfPrimeNumbers(totalOfNumbersExpected);

            // Assert
            Assert.That(listOfNumbersGenerated, Is.Not.Null);
            Assert.That(listOfNumbersGenerated.Length, Is.EqualTo(totalOfNumbersExpected));
        }
    }

}
