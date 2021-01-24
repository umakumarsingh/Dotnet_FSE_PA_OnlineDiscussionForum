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
    public class DiscussionForumRepository : IDiscussionForumRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<ApplicationUser> _dbACollection;
        private IMongoCollection<ForumThread> _dbFCollection;
        public DiscussionForumRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbFCollection = _mongoContext.GetCollection<ForumThread>(typeof(ForumThread).Name);
            _dbACollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
        }
        /// <summary>
        /// Find Forum thread by name as well email
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ForumThread>> FindForumThread(string Name)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<ForumThread>();
                var findName = filterBuilder.Eq(s => s.ThreadName, Name);
                var findEmail = filterBuilder.Eq(s => s.Email, Name.ToString());
                _dbFCollection = _mongoContext.GetCollection<ForumThread>(typeof(ForumThread).Name);
                var result = await _dbFCollection.FindAsync(findName | findEmail).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Find Forum thread by user email
        /// </summary>
        /// <param name="Eamil"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ForumThread>> FindForumThreadByEmail(string Eamil)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<ForumThread>();
                var findEmail = filterBuilder.Eq(s => s.Email, Eamil.ToString());
                _dbFCollection = _mongoContext.GetCollection<ForumThread>(typeof(ForumThread).Name);
                var result = await _dbFCollection.FindAsync(findEmail).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get forum thread by Thread Id
        /// </summary>
        /// <param name="ThreadId"></param>
        /// <returns></returns>
        public async Task<ForumThread> ForumThreadById(string ThreadId)
        {
            try
            {
                var objectId = new ObjectId(ThreadId);
                FilterDefinition<ForumThread> filter = Builders<ForumThread>.Filter.Eq("ThreadId", objectId);
                _dbFCollection = _mongoContext.GetCollection<ForumThread>(typeof(ForumThread).Name);
                return await _dbFCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all Forum Thread from MongoDb collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ForumThread>> GetAllForumThread()
        {
            try
            {
                var list = _mongoContext.GetCollection<ForumThread>("ForumThread")
                .Find(Builders<ForumThread>.Filter.Where(x => x.IsApproved == true), null)
                .SortByDescending(e => e.ThreadId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Add new forum thread in MongoDb collection
        /// </summary>
        /// <param name="forumThread"></param>
        /// <returns></returns>
        public async Task<ForumThread> NewForumThread(ForumThread forumThread)
        {
            try
            {
                if (forumThread == null)
                {
                    throw new ArgumentNullException(typeof(ForumThread).Name + "Object is Null");
                }
                _dbFCollection = _mongoContext.GetCollection<ForumThread>(typeof(ForumThread).Name);
                await _dbFCollection.InsertOneAsync(forumThread);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return forumThread;
        }
        /// <summary>
        /// Register new user for Application
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> RegisterNewUser(ApplicationUser user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object is Null");
                }
                _dbACollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
                await _dbACollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return user;
        }
        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> UserById(string userId)
        {
            try
            {
                var objectId = new ObjectId(userId);
                FilterDefinition<ApplicationUser> filter = Builders<ApplicationUser>.Filter.Eq("UserId", objectId);
                _dbACollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
                return await _dbACollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
