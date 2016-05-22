using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeNumbersTable.Web.Models
{
    public class PrimeNumbersTableDisplayModel
    {
        public int[] ListOfPrimeNumbers { get; set; }
    }
}