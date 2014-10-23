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
        public void FollowInstructorTest()
        {
            // TODO -- REmove me
            UserTests.login_join_account_email = "prototest_21145530@mailinator.com";

            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(UserTests.login_join_account_email, UserTests.account_password).
                LoggedInHeader.EnterInstruction("Woods").
                FollowInstructor().
                LoggedInHeader.EnterAccount_YourVideos().
                EnterFollowing().VerifyFollowingInstructor("Woods");

        }
    }
}
