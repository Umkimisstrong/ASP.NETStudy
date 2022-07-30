using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLayoutTest.Models
{
    public class Member
    {
        [Required(ErrorMessage = "Enter Id..")]
        [Display(Name = "ID")]
        public string user_id { get; set; }

        [Required(ErrorMessage = "Enter Pwd..")]
        [StringLength(100, MinimumLength =6)]
        [Display(Name = "Password")]
        public string user_pwd { get; set; }
    }
}