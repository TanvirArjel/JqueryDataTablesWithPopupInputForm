using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JqueryDataTablesWithPopupInputForm.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide first name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide last name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}