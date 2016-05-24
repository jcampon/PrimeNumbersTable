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
    public class HomeControllerTest
    {
        private HomeController _controller;

        [SetUp]
        public void SetUpTestFixture()
        {
            this._controller = new HomeController();
        }

        [Test]
        public void when_the_controller_runs_the_index_action_then_it_returns_a_view_result()
        {
            // Act
            var result = this._controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void the_index_action_returns_a_view_result_with_a_valid_view_model()
        {
            // Act
            var result = ReturnViewResultForTheIndexActionMethod();

            // Assert
            Assert.That(result.Model, Is.Not.Null);
            Assert.That(result.Model, Is.InstanceOf(typeof(UserInputDisplayModel)));
            Assert.That((result.Model as UserInputDisplayModel).NumberOfPrimes, Is.EqualTo(10));
        }

        #region private helper methods

        private ViewResult ReturnViewResultForTheIndexActionMethod()
        {
            return this._controller.Index() as ViewResult;
        }

        #endregion
    }
}
