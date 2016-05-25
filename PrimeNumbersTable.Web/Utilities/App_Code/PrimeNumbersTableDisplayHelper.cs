using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using PrimeNumbersTable.Web.Models;

namespace PrimeNumbersTable.Web.Utilities.App_Code
{
    public interface IPrimeNumbersTableDisplayHelper
    {
        HelperResult RenderPrimeNumbersTable(PrimeNumbersTableDisplayModel model);
    }

    public class PrimeNumbersTableDisplayHelper : IPrimeNumbersTableDisplayHelper
    {
        public HelperResult RenderPrimeNumbersTable(PrimeNumbersTableDisplayModel model)
        {
            throw new NotImplementedException();
        }
    }
}