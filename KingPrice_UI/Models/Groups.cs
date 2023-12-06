using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KingPrice_UI.Models
{
    public class Groups
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Group Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateUpdated { get; set; }
    }
}