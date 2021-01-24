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
    public class BoundaryTest
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
        public BoundaryTest()
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
        static BoundaryTest()
        {
            if (!File.Exists("../../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_boundary_revised.txt");
                File.Create("../../../../output_boundary_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Test for Validate UserId is used to test UserId is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UserId()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterNewUser(_applicationUser)).ReturnsAsync(_applicationUser);
            var result = await _forumServices.RegisterNewUser(_applicationUser);
            if (result.UserId.Length.ToString() == _applicationUser.UserId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_UserId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Validate ThreadId is used to test UserId is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ThreadId()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.NewForumThread(_forumThread)).ReturnsAsync(_forumThread);
            var result = await _forumServices.NewForumThread(_forumThread);
            if (result.ThreadId.Length.ToString() == _forumThread.ThreadId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_ThreadId=" + res + "\n");
            return res;
        }
    }
}
