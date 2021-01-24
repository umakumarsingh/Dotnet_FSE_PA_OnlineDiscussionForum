using OnlineDiscussionForum.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineDiscussionForum.BusinessLayer.ViewModels
{
    public class ApplicationUserViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "User Type")]
        public UserType? UserTypes { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Display(Name = "Phone Number")]
        public double PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsApproved { get; set; }
    }
}
