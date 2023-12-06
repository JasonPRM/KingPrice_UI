using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KingPrice_UI.Models
{
    public class Users
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Firstname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please Enter Surname")]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateUpdated { get; set; }
    }
}