using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using PrimeNumbersTable.Web;
using PrimeNumbersTable.Web.Controllers;
using PrimeNumbersTable.Web.Models;

namespace PrimeNumbersTable.Tests.Controllers
{
    [TestFixture]
    public class PrimeNumbersTableControllerTest
    {
        private PrimeNumbersTableController _controller;

        private const int ValidProvidedNumberOfPrimes = 5;
        private const int MinimumRequiredNumberOfPrimes = 1;

        [SetUp]
        public void SetUpTextFixture()
        {
            this._controller = new PrimeNumbersTableController();
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
            Assert.That(result.Model, Is.InstanceOf(typeof(PrimeNumbersTableDisplayModel)));
            Assert.That((result.Model as PrimeNumbersTableDisplayModel).ListOfPrimeNumbers, Is.Not.Null);
            Assert.That((result.Model as PrimeNumbersTableDisplayModel).ListOfPrimeNumbers.Any, Is.True);
            Assert.That((result.Model as PrimeNumbersTableDisplayModel).TotalOfPrimeNumbers, Is.GreaterThanOrEqualTo(MinimumRequiredNumberOfPrimes));
        }



        #region private helper methods

        private ViewResult ReturnViewResultForTheGenerateActionMethod()
        {
            return this._controller.Generate(ValidProvidedNumberOfPrimes) as ViewResult;
        }

        #endregion
    }
}
