using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace Auth.Model
{
    public class CustomAccount
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string password { get; set; }
        public string[] Roles { get; set; }

    }

}
