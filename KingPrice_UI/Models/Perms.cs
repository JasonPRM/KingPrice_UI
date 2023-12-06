using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KingPrice_UI.Models
{
    //Permissions
    public class Perms
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Permission Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateUpdated { get; set; }
    }
}