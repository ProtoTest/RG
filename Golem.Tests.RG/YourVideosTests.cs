using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using Golem.PageObjects.RG;
using MbUnit.Framework;
using OpenQA.Selenium;


namespace Golem.Tests.RG
{
    [TestFixture, DependsOn(typeof(UserTests))]
    public class YourVideosTests : WebDriverTestBase
    {
        [Test, Category("Your Videos Tests")]
        public void EnterYourVideos()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.EnterAccount_YourVideos();
        }

        [Test, Category("Your Videos Tests"), DependsOn("EnterYourVideos")]
        public void FollowInstructor()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.EnterInstruction("Woods").
                FollowInstructor().
                LoggedInHeader.EnterAccount_YourVideos().
                EnterFollowing().VerifyFollowingInstructor("Woods");

        }

        [Test, Category("Your Videos Tests"), DependsOn("FollowInstructor")]
        public void UnFollowInstructor()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.EnterInstruction("Woods").
                UnFollowInstructor().
                LoggedInHeader.EnterAccount_YourVideos().
                EnterFollowing().VerifyNotFollowingInstructor("Woods");
        }

        [Test, Category("Your Videos Tests")]
        public void QueueVideoTest()
        {
            // Enter Tiger Woods Instruction page, get his list of videos and grab the first one from the video list
            Golem.PageObjects.RG.Components.VideoDetails FirstInstructionVideo =
                HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.EnterInstruction("Woods").FeaturedVideos.First();

            // Click to start playing the video and add it to the user queue
            FirstInstructionVideo.Video_Link.Click();
            HomePage page = new VideoPlayingPage().AddToQueue().LoggedInHeader.LogOut();

            // Log Back in and verify the video is in the user queue
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.EnterAccount_YourVideos().EnterQueue().VerifyVideoOnPage(FirstInstructionVideo.Video_Title);
        }

        [Test, Category("Your Videos Tests")]
        public void FavoritesVideoTest()
        {
            // Enter Tiger Woods Instruction page, get his list of videos and grab the first one from the video list
            Golem.PageObjects.RG.Components.VideoDetails FirstInstructionVideo =
                HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.EnterInstruction("Woods").FeaturedVideos.First();

            // Click to start playing the video and add it to the user queue
            FirstInstructionVideo.Video_Link.Click();
            HomePage page = new VideoPlayingPage().AddToFavorites().LoggedInHeader.LogOut();

            // Log Back in and verify the video is in the user queue
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.EnterAccount_YourVideos().EnterFavorites().VerifyVideoOnPage(FirstInstructionVideo.Video_Title);
        }
    }
}
