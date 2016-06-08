using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeNumbersTable.Web.Models
{
    public class NumbersTableDisplayModel
    {
        public NumbersTableDisplayModel(int totalOfNumbers)
        {
            this.TotalOfNumbers = totalOfNumbers;
            this.ListOfNumbers = new int[totalOfNumbers];
        }

        public int TotalOfNumbers { get; private set; }
        public int[] ListOfNumbers { get; set; }
    }
}