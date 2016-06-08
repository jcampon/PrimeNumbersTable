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
        [Required(ErrorMessage = "You must provide an valid whole number between 1 and 500" )]
        [DisplayName("Numbers to display")]
        [Range(1, 500)]
        public int TotalOfNumbers { get; set; }
    }
}