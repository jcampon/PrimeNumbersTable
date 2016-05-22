using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using PrimeNumbersTable.Web;
using PrimeNumbersTable.Web.Controllers;

namespace PrimeNumbersTable.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void when_the_controller_runs_the_index_action_then_it_returns_a_view_result()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
