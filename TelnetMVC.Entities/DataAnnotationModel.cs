using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TelnetMVC.Entities
{
    public class DataAnnotationModel
    {
        [Display(Name="姓名")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name="邮箱")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\s*([A-Za-z0-9_-]+(\.\w+)*@([\w-]+\.)+\w{2,3})\s*$", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
    }
}
