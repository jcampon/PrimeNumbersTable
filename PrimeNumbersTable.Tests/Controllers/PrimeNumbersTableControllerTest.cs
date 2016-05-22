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

        private const int ValidNumberOfPrimes = 5;

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

        public void the_generate_action_returns_a_view_result_with_a_valid_view_model()
        {
            // Act
            var result = ReturnViewResultForTheGenerateActionMethod();

            // Assert
            Assert.That(result.Model, Is.InstanceOf(typeof(PrimeNumbersTableDisplayModel)));
        }



        #region private helper methods

        private ViewResult ReturnViewResultForTheGenerateActionMethod()
        {
            return this._controller.Generate(ValidNumberOfPrimes) as ViewResult;
        }

        #endregion
    }
}
