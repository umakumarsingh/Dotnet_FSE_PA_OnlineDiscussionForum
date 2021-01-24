using Moq;
using OnlineDiscussionForum.BusinessLayer.Interfaces;
using OnlineDiscussionForum.BusinessLayer.Services;
using OnlineDiscussionForum.BusinessLayer.Services.Repository;
using OnlineDiscussionForum.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineDiscussionForum.Test.TestCases
{
    public class FunctionalTests
    {
        /// <summary>
        /// Creating Referance Variable of Service Interface and Mocking Repository Interface and class
        /// </summary>
        private readonly IDiscussionForumServices _forumServices;
        public readonly Mock<IDiscussionForumRepository> service = new Mock<IDiscussionForumRepository>();
        private readonly IAdminDiscussionForumServices _adminForumServices;
        public readonly Mock<IAdminDiscussionForumRepository> adminService = new Mock<IAdminDiscussionForumRepository>();
        private readonly ApplicationUser _applicationUser;
        private readonly ForumThread _forumThread;
        public FunctionalTests()
        {
            //Creating New mock Object with value.
            _forumServices = new DiscussionForumServices(service.Object);
            _adminForumServices = new AdminDiscussionForumServices(adminService.Object);
            _applicationUser = new ApplicationUser
            {
                UserId = "",
                Name = "Kumar Uma",
                UserTypes = UserType.Student,
                Email = "services@iiht.co.in",
                Password = "12345",
                ConfirmPassword = "12345",
                PhoneNumber = 9631475475,
                Address = "Banglore",
                IsApproved = false
            };
            _forumThread = new ForumThread
            {
                ThreadId = "",
                ThreadName = "Science Question Discussion",
                UserTypes = UserType.Student,
                Email = "services@iiht.co.in",
                Description = "Answer this question",
                IsApproved = false
            };
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static FunctionalTests()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Using this test case method try to get all Forum Thread
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetAllForumThread()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.GetAllForumThread());
            var result = await _forumServices.GetAllForumThread();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_GetAllForumThread=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get Forum Thread by Id, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ForumThreadById()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.ForumThreadById(_forumThread.ThreadId)).ReturnsAsync(_forumThread);
            var result = await _forumServices.ForumThreadById(_forumThread.ThreadId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_ForumThreadById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Add a Forum Thread return async return _foruThread object of working fine.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Take_AddNewForumThread()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.NewForumThread(_forumThread)).ReturnsAsync(_forumThread);
            var result = await _forumServices.NewForumThread(_forumThread);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Take_AddNewForumThread=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get Forum Thread by Name, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindForumThreadByName()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.FindForumThread(_forumThread.ThreadName));
            var result = await _forumServices.FindForumThread(_forumThread.ThreadName);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_FindForumThreadByName=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get Forum Thread by Email, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindForumThreadByUser_Email()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.FindForumThreadByEmail(_applicationUser.Email));
            var result = await _forumServices.FindForumThreadByEmail(_applicationUser.Email);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_FindForumThreadByUser_Email=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Add new User return async return _applicationUser object of working fine.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Take_AddNewUser()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.RegisterNewUser(_applicationUser)).ReturnsAsync(_applicationUser);
            var result = await _forumServices.RegisterNewUser(_applicationUser);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Take_AddNewUser=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get Forum User by Id, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ForumThread_UserById()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.UserById(_applicationUser.UserId)).ReturnsAsync(_applicationUser);
            var result = await _forumServices.UserById(_applicationUser.UserId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_ForumThread_UserById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Approved forum thread by thread Id and return approved thread object
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Approved_ForumThread_ById()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.ApprovedThread(_forumThread.ThreadId)).ReturnsAsync(_forumThread);
            var result = await _adminForumServices.ApprovedThread(_forumThread.ThreadId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Approved_ForumThread_ById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Approved Application User by User Id and return approved User object
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Approved_ApplicationUser_ById()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.ApprovedUser(_applicationUser.UserId)).ReturnsAsync(_applicationUser);
            var result = await _adminForumServices.ApprovedUser(_applicationUser.UserId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Approved_ApplicationUser_ById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing ForumThrea by ThreadId Id and _threadUpdate Collection
        /// if get updated then test Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateThread()
        {
            //Arrange
            bool res = false;
            var _threadUpdate = new ForumThread
            {
                ThreadId = "",
                ThreadName = "Science Question Discussion",
                UserTypes = UserType.Student,
                Email = "services@iiht.co.in",
                Description = "Answer this question",
                IsApproved = false
            };
            //Act
            adminService.Setup(repo => repo.UpdateThread(_threadUpdate.ThreadId, _threadUpdate)).ReturnsAsync(_threadUpdate);
            var result = await _adminForumServices.UpdateThread(_threadUpdate.ThreadId, _threadUpdate);
            if (result == _threadUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateThread=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to Delete an Existing Thread by Thread Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteForumThread()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeleteThread(_forumThread.ThreadId)).ReturnsAsync(true);
            var resultDelete = await _adminForumServices.DeleteThread(_forumThread.ThreadId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteForumThread=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test case method try to get all Un-Approved Thread
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_AllUnApprovedThread()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AllUnApprovedThread());
            var result = await _adminForumServices.AllUnApprovedThread();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_AllUnApprovedThread=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test case method try to get all Un-Approved User
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_AllUnApprovedUser()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AllUnApprovedUser());
            var result = await _adminForumServices.AllUnApprovedUser();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_AllUnApprovedUser=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using this test case method try to get all User
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_AllUser()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AllUser());
            var result = await _adminForumServices.AllUser();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_AllUser=" + res + "\n");
            return res;
        }
    }
}
