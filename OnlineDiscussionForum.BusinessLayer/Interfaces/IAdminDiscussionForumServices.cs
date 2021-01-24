using OnlineDiscussionForum.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDiscussionForum.BusinessLayer.Interfaces
{
    public interface IAdminDiscussionForumServices
    {
        Task<ForumThread> ApprovedThread(string threadId);
        Task<ApplicationUser> ApprovedUser(string userId);
        Task<ForumThread> UpdateThread(string threadId, ForumThread forumThread);
        Task<bool> DeleteThread(string threadId);
        Task<IEnumerable<ForumThread>> AllUnApprovedThread();
        Task<IEnumerable<ApplicationUser>> AllUnApprovedUser();
        Task<IEnumerable<ApplicationUser>> AllUser();
    }
}
