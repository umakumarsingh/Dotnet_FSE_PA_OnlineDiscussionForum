using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDiscussionForum.BusinessLayer.Interfaces;
using OnlineDiscussionForum.Entities;

namespace OnlineDiscussionForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminForumController : ControllerBase
    {
        /// <summary>
        /// Creating Referancce variable of IAdminDiscussionForumServices and injecting Referance into constructor
        /// </summary>
        private readonly IAdminDiscussionForumServices _adminForumServices;
        public AdminForumController(IAdminDiscussionForumServices adminDiscussionForumServices)
        {
            _adminForumServices = adminDiscussionForumServices;
        }
        /// <summary>
        /// Get all UnApproved forum thread for Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ForumThread>> AllUnApprovedForumThread()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Approved Thread by passing Thread id as query string
        /// </summary>
        /// <param name="ThreadId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ApprovedThread/{threadId}")]
        public async Task<IActionResult> ApprovedForumThread(string ThreadId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Approved Thread by passing Thread id as query string
        /// </summary>
        /// <param name="ThreadId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ApprovedUser/{UserId}")]
        public async Task<IActionResult> ApprovedRegistredUser(string userId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all UnApproved Use for Admin to approved
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("UnApprovedUser")]
        public async Task<IEnumerable<ApplicationUser>> AllUnApprovedRegisterUser()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get All User for Admin approved as well not approved
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllUser")]
        public async Task<IEnumerable<ApplicationUser>> AllRegisterUser()
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
