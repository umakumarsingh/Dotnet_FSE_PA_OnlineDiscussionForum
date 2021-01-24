using OnlineDiscussionForum.BusinessLayer.Interfaces;
using OnlineDiscussionForum.BusinessLayer.Services.Repository;
using OnlineDiscussionForum.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDiscussionForum.BusinessLayer.Services
{
    public class DiscussionForumServices : IDiscussionForumServices
    {
        /// <summary>
        /// Creating Referance variable of IDiscussionForumRepository and injecting its variable into
        /// DiscussionForumServices constructor to call
        /// </summary>
        private readonly IDiscussionForumRepository _forumRepository;
        public DiscussionForumServices(IDiscussionForumRepository discussionForumRepository)
        {
            _forumRepository = discussionForumRepository;
        }
        /// <summary>
        /// Find Forum Thread by thread name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ForumThread>> FindForumThread(string Name)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find forum thread by user email Id
        /// </summary>
        /// <param name="Eamil"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ForumThread>> FindForumThreadByEmail(string Eamil)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get forum thread by thread Id
        /// </summary>
        /// <param name="ThreadId"></param>
        /// <returns></returns>
        public async Task<ForumThread> ForumThreadById(string ThreadId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all forum thread and displayon forum controller
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ForumThread>> GetAllForumThread()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new forum thread to MongoDb collection
        /// </summary>
        /// <param name="forumThread"></param>
        /// <returns></returns>
        public async Task<ForumThread> NewForumThread(ForumThread forumThread)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new user to MongoDb collection
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> RegisterNewUser(ApplicationUser user)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get register User By UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> UserById(string userId)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
