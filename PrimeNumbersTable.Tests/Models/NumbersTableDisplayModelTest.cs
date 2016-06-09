using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PrimeNumbersTable.Web.Models;

namespace PrimeNumbersTable.Tests.Models
{
    class when_working_with_the_NumbersTableDisplayModel
    {
        [Test]
        public void test_that_the_GetValueToRenderInTableCell_returns_a_product_of_two_numbers()
        {
            // Arrange
            var viewModel = new NumbersTableDisplayModel(5);
            viewModel.ListOfNumbers = new int[] {1, 2, 3, 4, 5};

            // Act
            actualProductOfNumbers = viewModel.GetValueToRenderInTableCell(1, 4); 

            // Assert
            Assert.That(actualProductOfNumbers, Is.EqualTo(10)); // We should get 2 * 5 = 10
        }
    }
}
