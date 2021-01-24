using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDiscussionForum.BusinessLayer.Interfaces;
using OnlineDiscussionForum.BusinessLayer.ViewModels;
using OnlineDiscussionForum.Entities;

namespace OnlineDiscussionForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        /// <summary>
        /// Creating Referancce variable of IDiscussionForumServices and injecting Referance into constructor
        /// </summary>
        private readonly IDiscussionForumServices  _forumServices;
        public ForumController(IDiscussionForumServices discussionForumServices)
        {
            _forumServices = discussionForumServices;
        }
        /// <summary>
        /// Get all Forum Thread list from Db collection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ForumThread>> GetAllForumThread()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get a forum thread by Id
        /// </summary>
        /// <param name="ThreadId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ForumThread/{ThreadId}")]
        public async Task<IActionResult> ForumThreadById(string ThreadId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new forum thread to MongoDb collection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("newthread")]
        public async Task<IActionResult> AddnewForumThread([FromBody] ForumThreadViewModel model)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find forum thread from MongoDb collecton based on name and email of user
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FindForumThread/{Name}")]
        public async Task<IActionResult> FindForumThread(string Name)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find forum thread from MongoDb collecton based on email of user
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FindForumThreadByEmail/{Email}")]
        public async Task<IActionResult> FindForumThreadByEmail(string Email)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new user to MongoDb Collection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterNewUser([FromBody] ApplicationUserViewModel model)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get a user by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UserById/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
