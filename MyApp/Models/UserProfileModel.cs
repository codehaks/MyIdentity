using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.Models
{
    public class UserProfileModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        [MaxLength(20)]
        [Display(Name ="نام")]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "کد ملی")]
        [MaxLength(10)]
        public string NationalCode { get; set; }
    }
}
