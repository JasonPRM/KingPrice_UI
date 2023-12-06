using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KingPrice_UI.Models
{
    public class GroupPermissions
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please select a group")]
        public int GroupID { get; set; }

        [Required(ErrorMessage = "Please select a permission")]
        public int PermissionID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateUpdated { get; set; }
    }
}