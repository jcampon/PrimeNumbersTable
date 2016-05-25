using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using NUnit.Framework.Constraints;
using PrimeNumbersTable.Web.Models;
using PrimeNumbersTable.Web.Utilities.App_Code;

namespace PrimeNumbersTable.Tests.Utilities.App_Code
{
    [TestFixture]
    public class when_using_the_prime_numbers_table_display_helper
    {
        private PrimeNumbersTableDisplayHelper _displayHelper;

        [SetUp]
        public void SetUpTests()
        {
            this._displayHelper = new PrimeNumbersTableDisplayHelper();
        }

        [Test]
        [TestCase(10)]
        public void and_calling_the_render_prime_numbers_table_we_get_a_helper_result(int totalOfPrimeNumbers)
        {
            // Arrange
            var viewModel = GetViewModel(totalOfPrimeNumbers);

            // Act
            var helperResult = this._displayHelper.RenderPrimeNumbersTable(viewModel);

            // Assert
            Assert.That(helperResult, Is.Not.Null);
            Assert.That(helperResult, Is.InstanceOf(typeof(HelperResult)));
        }

        [Test]
        [TestCase(3)]
        [TestCase(10)]
        public void the_helper_result_renders_an_html_table_of_multiplied_numbers(int totalOfPrimeNumbers)
        {
            // Arrange
            var viewModel = GetViewModel(totalOfPrimeNumbers);
            viewModel.ListOfPrimeNumbers = FillUpListOfPrimeNumbers(totalOfPrimeNumbers);

            // Act
            var helperResult = this._displayHelper.RenderPrimeNumbersTable(viewModel);

            // Assert
            Assert.That(RenderedResultContainsTheExpectedRowOfNumbers(helperResult, totalOfPrimeNumbers), Is.True);
            Assert.That(RenderedResultContainsTheExpectedTableOfMultipliedNumbers(helperResult, totalOfPrimeNumbers), Is.True);
        }

        private bool RenderedResultContainsTheExpectedRowOfNumbers(HelperResult helperResult, int totalOfPrimeNumbers)
        {
            for (var i = 0; i < totalOfPrimeNumbers; i++)
            {
                if(!helperResult.ToHtmlString().Contains($"<td>{i}</td>"))
                    return false;
            }

            return true;
        }

        private bool RenderedResultContainsTheExpectedTableOfMultipliedNumbers(HelperResult helperResult, int totalOfPrimeNumbers)
        {
            for (var i = 0; i < totalOfPrimeNumbers; i++)
            {
                for (var j = 0; j < totalOfPrimeNumbers; j++)
                {
                    if (!helperResult.ToHtmlString().Contains($"<td>{i * j}</td>"))
                        return false;
                }
            }

            return true;
        }

        private PrimeNumbersTableDisplayModel GetViewModel(int totalOfPrimeNumbers)
        {
            var viewModel = new PrimeNumbersTableDisplayModel(totalOfPrimeNumbers)
            {
                ListOfPrimeNumbers = new int[totalOfPrimeNumbers]
            };

            return viewModel;
        }

        private int[] FillUpListOfPrimeNumbers(int totalOfPrimeNumbers)
        {
            var arrayOfNumbers = new int[totalOfPrimeNumbers];

            for(var i = 0; i < totalOfPrimeNumbers; i++)
            {
                arrayOfNumbers[i] = i;
            }

            return arrayOfNumbers;
        }

    }
}
