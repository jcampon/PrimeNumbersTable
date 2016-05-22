using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeNumbersTable.Web.Models
{
    public class PrimeNumbersTableDisplayModel
    {
        public PrimeNumbersTableDisplayModel(int totalOfPrimeNumbers)
        {
            this.TotalOfPrimeNumbers = totalOfPrimeNumbers;
            this.ListOfPrimeNumbers = new int[totalOfPrimeNumbers];
        }

        public int TotalOfPrimeNumbers { get; private set; }
        public int[] ListOfPrimeNumbers { get; private set; }
    }
}