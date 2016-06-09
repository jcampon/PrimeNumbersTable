using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PrimeNumbersTable.Tests.Models
{
    class when_working_with_the_NumbersTableDisplayModel
    {
        [Test]
        public void test_that_the_GetValueToRenderInTableCell_returns_a_product_of_two_numbers()
        {
            // Assert
            Assert.That(numberOne * numberTwo, Is.EqualTo(expectedProductOfNumbers));
        }
    }
}
