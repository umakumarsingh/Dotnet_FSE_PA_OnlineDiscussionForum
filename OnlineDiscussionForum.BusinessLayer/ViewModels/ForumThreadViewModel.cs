using OnlineDiscussionForum.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineDiscussionForum.BusinessLayer.ViewModels
{
    public class ForumThreadViewModel
    {
        [Required]
        public string ThreadName { get; set; }
        [Required]
        [Display(Name = "User Type")]
        public UserType? UserTypes { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
    }
}
