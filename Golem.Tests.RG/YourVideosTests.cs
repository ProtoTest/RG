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
                Login(UserTests.login_join_account_email, UserTests.account_password).
                LoggedInHeader.EnterAccount_YourVideos();
        }

        [Test, Category("Your Videos Tests"), DependsOn("EnterYourVideos")]
        public void FollowInstructor()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(UserTests.login_join_account_email, UserTests.account_password).
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
                Login(UserTests.login_join_account_email, UserTests.account_password).
                LoggedInHeader.EnterInstruction("Woods").
                UnFollowInstructor().
                LoggedInHeader.EnterAccount_YourVideos().
                EnterFollowing().VerifyNotFollowingInstructor("Woods");
        }

        [Test, Category("Your Videos Tests")]
        public void QueueVideoTest()
        {
            // TODO: remove this
            UserTests.login_join_account_email = "prototest_21145530@mailinator.com";

            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(UserTests.login_join_account_email, UserTests.account_password).
                LoggedInHeader.EnterInstruction("Woods");
        }

        [Test, Category("Your Videos Tests")]
        public void FavoritesVideoTest()
        {
            throw new NotImplementedException();
        }
    }
}
