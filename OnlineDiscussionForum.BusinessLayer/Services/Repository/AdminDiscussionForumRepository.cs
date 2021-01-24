using MongoDB.Bson;
using MongoDB.Driver;
using OnlineDiscussionForum.DataLayer;
using OnlineDiscussionForum.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineDiscussionForum.BusinessLayer.Services.Repository
{
    public class AdminDiscussionForumRepository : IAdminDiscussionForumRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<ApplicationUser> _dbACollection;
        private IMongoCollection<ForumThread> _dbFCollection;
        public AdminDiscussionForumRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbFCollection = _mongoContext.GetCollection<ForumThread>(typeof(ForumThread).Name);
            _dbACollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
        }
        /// <summary>
        /// Get all Un-Approved forum Thread from MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ForumThread>> AllUnApprovedThread()
        {
            try
            {
                var list = _mongoContext.GetCollection<ForumThread>("ForumThread")
                .Find(Builders<ForumThread>.Filter.Where(x => x.IsApproved == false), null)
                .SortByDescending(e => e.ThreadId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all Un-Approved Application User from MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> AllUnApprovedUser()
        {
            try
            {
                var list = _mongoContext.GetCollection<ApplicationUser>("ApplicationUser")
                .Find(Builders<ApplicationUser>.Filter.Where(x => x.IsApproved == false), null)
                .SortByDescending(e => e.UserId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get alluser From MongoDb collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ApplicationUser>> AllUser()
        {
            try
            {
                var list = _mongoContext.GetCollection<ApplicationUser>("ApplicationUser")
                .Find(Builders<ApplicationUser>.Filter.Empty, null)
                .SortByDescending(e => e.UserId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Approved user posted thread by admin then show for User.
        /// </summary>
        /// <param name="threadId"></param>
        /// <returns></returns>
        public async Task<ForumThread> ApprovedThread(string threadId)
        {
            try
            {
                if (threadId == null)
                {
                    throw new ArgumentNullException(typeof(ForumThread).Name + "Object or may be thread Id is Null");
                }
                var objectId = new ObjectId(threadId);
                FilterDefinition<ForumThread> filter = Builders<ForumThread>.Filter.Eq("ThreadId", objectId);
                _dbFCollection = _mongoContext.GetCollection<ForumThread>(typeof(ForumThread).Name);
                var findThread = await _dbFCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
                if(findThread.IsApproved == false)
                {
                    bool res = true;
                    var update = await _dbFCollection.FindOneAndUpdateAsync(Builders<ForumThread>.
                    Filter.Eq("ThreadId", findThread.ThreadId), Builders<ForumThread>.
                    Update.Set("IsApproved", res));
                    return update;
                }
                return findThread;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Approved application user by admin then user are able to post a thread
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> ApprovedUser(string userId)
        {
            try
            {
                if (userId == null)
                {
                    throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object or may be user Id is Null");
                }
                var objectId = new ObjectId(userId);
                FilterDefinition<ApplicationUser> filter = Builders<ApplicationUser>.Filter.Eq("UserId", objectId);
                _dbACollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
                var findUser = await _dbACollection.FindAsync(filter).Result.FirstOrDefaultAsync();
                if (findUser.IsApproved == false)
                {
                    bool res = true;
                    var update = await _dbACollection.FindOneAndUpdateAsync(Builders<ApplicationUser>.
                    Filter.Eq("UserId", findUser.UserId), Builders<ApplicationUser>.
                    Update.Set("IsApproved", res));
                    return update;
                }
                return findUser;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// delete a Forum Thread by thread Id
        /// </summary>
        /// <param name="threadId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteThread(string threadId)
        {
            try
            {
                var objectId = new ObjectId(threadId);
                FilterDefinition<ForumThread> filter = Builders<ForumThread>.Filter.Eq("ThreadId", objectId);
                var result = await _dbFCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Update an existing thread by Id and forumThread object
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="forumThread"></param>
        /// <returns></returns>
        public async Task<ForumThread> UpdateThread(string threadId, ForumThread forumThread)
        {
            if (forumThread == null && threadId == null)
            {
                throw new ArgumentNullException(typeof(ForumThread).Name + "Object or may be threadId is Null");
            }
            var update = await _dbFCollection.FindOneAndUpdateAsync(Builders<ForumThread>.
                Filter.Eq("ThreadId", forumThread.ThreadId), Builders<ForumThread>.
                Update.Set("ThreadName", forumThread.ThreadName).Set("UserTypes", forumThread.UserTypes)
                .Set("Email", forumThread.Email).
                Set("Description", forumThread.Description).Set("IsApproved", forumThread.IsApproved));
            return update;
        }
    }
}
