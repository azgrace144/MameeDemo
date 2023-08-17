using System;
using System.ComponentModel.DataAnnotations;

namespace AppOwnsData.Models
{
    public class UserLogin
    {
        [Key]
        public long uid { get; set; }

        public string username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Please Enter Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [Display(Name = "Please Enter Email")]
        public string email { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}
