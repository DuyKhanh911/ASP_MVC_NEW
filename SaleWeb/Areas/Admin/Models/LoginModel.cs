using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaleWeb.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Phai nhap user name")]
        [DisplayName("User")]
        public string UserName { set; get; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Phai nhap Passss")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}