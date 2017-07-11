using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.Shop.UI.Models
{
    public class ProfileVM
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }
        
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
    }
}