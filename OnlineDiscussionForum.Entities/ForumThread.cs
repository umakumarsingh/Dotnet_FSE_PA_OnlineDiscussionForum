using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineDiscussionForum.Entities
{
    public class ForumThread
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ThreadId { get; set; }
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
