using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeNumbersTable.Web.Models
{
    public class UserInputDisplayModel
    {
        [Required(ErrorMessage = "You must provide an valid whole number greater or equal than 1.")]
        [DisplayName("Number of Prime Numbers to display")]
        public int NumberOfPrimes { get; set; }
    }
}