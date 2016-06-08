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
}
