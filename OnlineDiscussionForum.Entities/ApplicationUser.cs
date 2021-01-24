using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineDiscussionForum.Entities
{
    public class ApplicationUser
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
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
