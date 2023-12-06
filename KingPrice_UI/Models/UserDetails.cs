using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KingPrice_UI.Models
{
    public class UserDetails
    {
        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string GroupName { get; set; }

        public string PermissionName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateUpdated { get; set; }
    }
}