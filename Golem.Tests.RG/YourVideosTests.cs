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
                LoggedInHeader.EnterInstruction("Martin Chuck").
                FollowInstructor().
                LoggedInHeader.
                EnterAccount_YourVideos().
                EnterFollowing().
                VerifyFollowing("Martin Chuck").
                UnFollowInstructor("Martin Chuck").
                VerifyNotFollowing("Martin Chuck");

        }

        [Test, Category("Your Videos Tests"), DependsOn("EnterYourVideos")]
        public void FollowTopic()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.EnterTopic("Chipping").Follow().
                LoggedInHeader.
                EnterAccount_YourVideos().
                EnterFollowing().
                UnFollowTopic("Chipping & Pitching").
                VerifyNotFollowing("Chipping & Pitching");


        }

        [Test, Category("Your Videos Tests")]
        public void QueueVideoTest()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.SearchFor("Golf Swing Tempo")
                .Videos.OpenFirstVideo()
                .AddToQueue()
                .LoggedInHeader.LogOut();

            // Log Back in and verify the video is in the user queue
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.EnterAccount_YourVideos().EnterQueue().VerifyVideoOnPage("Golf Swing Tempo");
        }

        [Test, Category("Your Videos Tests")]
        public void FavoritesVideoTest()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.SearchFor("Create width in the backswing")
                .Videos.OpenFirstVideo().AddToFavorites().LoggedInHeader.LogOut();

            HomePage.OpenHomePage().
              GotoLoginJoinPage().
              Login(Users.User1.email, Users.User1.password).
              LoggedInHeader.EnterAccount_YourVideos().EnterFavorites().VerifyVideoOnPage("Create width in the backswing");
        }

        [Test, Category("Your Videos Tests")]
        public void PrimaryCoachTest()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.EnterAccount_YourVideos()
                .EnterFollowing()
                .SelectPrimaryCoachViaDropdown("Bronson Wright")
                .VerifyPrimaryCoachLabel("BRONSON WRIGHT")
                .SelectPrimaryCoachViaDropdown("Sir Nick Faldo")
                .VerifyPrimaryCoachLabel("SIR NICK FALDO");
        }
    }
}
