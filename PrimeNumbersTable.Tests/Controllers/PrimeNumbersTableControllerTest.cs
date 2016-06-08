using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using PrimeNumbersTable.Web;
using PrimeNumbersTable.Web.Controllers;
using PrimeNumbersTable.Web.Domain.Services;
using PrimeNumbersTable.Web.Models;

namespace PrimeNumbersTable.Tests.Controllers
{
    [TestFixture]
    public class PrimeNumbersTableControllerTest
    {
        private Mock<IFibonacciNumbersService> _numbersServiceMock;
        private PrimeNumbersTableController _controller;

        private const int ValidProvidedNumberOfPrimes = 5;
        private const int MinimumRequiredNumberOfPrimes = 1;

        [SetUp]
        public void SetUpTestFixture()
        {
            this._numbersServiceMock = new Mock<IFibonacciNumbersService>();
            SetUpGetListOfPrimeNumbersMethodForServiceMock(ValidProvidedNumberOfPrimes);

            this._controller = new PrimeNumbersTableController(this._numbersServiceMock.Object);
        }

        [Test]
        public void when_the_controller_receives_a_valid_number_then_the_generate_action_returns_a_view_result()
        {
            // Act
            var result = ReturnViewResultForTheGenerateActionMethod();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void the_generate_action_returns_a_view_result_with_a_valid_view_model()
        {
            // Act
            var result = ReturnViewResultForTheGenerateActionMethod();

            // Assert
            Assert.That(result.Model, Is.InstanceOf(typeof(NumbersTableDisplayModel)));
            Assert.That((result.Model as NumbersTableDisplayModel).ListOfNumbers, Is.Not.Null);
            Assert.That((result.Model as NumbersTableDisplayModel).ListOfNumbers.Any, Is.True);
            Assert.That((result.Model as NumbersTableDisplayModel).TotalOfNumbers, Is.GreaterThanOrEqualTo(MinimumRequiredNumberOfPrimes));
        }

        #region private helper methods

        private void SetUpGetListOfPrimeNumbersMethodForServiceMock(int totalOfNumbers)
        {
            var listOfNumbers = new int[totalOfNumbers];

            this._numbersServiceMock.Setup(x => x.GetListOfFibonacciNumbers(totalOfNumbers)).Returns(listOfNumbers);
        }

        private ViewResult ReturnViewResultForTheGenerateActionMethod()
        {
            return this._controller.Generate(ValidProvidedNumberOfPrimes) as ViewResult;
        }

        #endregion
    }
}
