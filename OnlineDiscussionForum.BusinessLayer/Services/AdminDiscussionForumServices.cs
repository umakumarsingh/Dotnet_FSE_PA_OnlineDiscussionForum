using OnlineDiscussionForum.BusinessLayer.Interfaces;
using OnlineDiscussionForum.BusinessLayer.Services.Repository;
using OnlineDiscussionForum.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDiscussionForum.BusinessLayer.Services
{
    public class AdminDiscussionForumServices : IAdminDiscussionForumServices
    {
        /// <summary>
        /// Creating Referance variable of IAdminDiscussionForumRepository and injecting its variable into
        /// AdminDiscussionForumServices constructor to call
        /// </summary>
        private readonly IAdminDiscussionForumRepository _adminRepository;
        public AdminDiscussionForumServices(IAdminDiscussionForumRepository adminDiscussionForumRepository)
        {
            _adminRepository = adminDiscussionForumRepository;
        }
        /// <summary>
        /// Get all UnApprovedThread for admin to approved
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ForumThread>> AllUnApprovedThread()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all UnApproved User for admin  
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> AllUnApprovedUser()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all user for admin
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> AllUser()
        {
            //Do code here
            throw new NotImplementedException();
        }

        public async Task<ForumThread> ApprovedThread(string threadId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Approved registred user for application
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> ApprovedUser(string userId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete a thred by Thread Id
        /// </summary>
        /// <param name="threadId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteThread(string threadId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing thread by thread id and thread object.
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="forumThread"></param>
        /// <returns></returns>
        public async Task<ForumThread> UpdateThread(string threadId, ForumThread forumThread)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
