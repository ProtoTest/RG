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
    [TestFixture]
    public class UserTests : WebDriverTestBase
    {
        public static string login_join_account_email = "prototest_" + Common.GetRandomString() + "_1@mailinator.com";
        public static string subscribe_account_email = "prototest_" + Common.GetRandomString() + "_2@mailinator.com";
        public static string account_password = Config.GetConfigValue("Password", "prototest123");

        [Test, Category("User Test")]
        public void VerifyApplicationUp()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Config.GetConfigValue("GlobalAdmin", ""),
                      account_password).LoggedInHeader.LogOut();
        }

        [Test, Category("User Test")]
        [DependsOn("VerifyApplicationUp")]
        public void CreateUserFromLoginPage()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                CreateAccount(login_join_account_email, account_password);
        }

        [Test, Category("User Test")]
        [DependsOn("VerifyApplicationUp")]
        public void SubscribeNewUser()
        {
            HomePage.OpenHomePage().
                GotoJoinPage().
                Subscribe(JoinPage.SEX.Male,
                          JoinPage.AGE_RANGE.Range_30_50,
                          JoinPage.SCORE.Scratch,
                          subscribe_account_email, 
                          account_password).LoggedInHeader.LogOut();
        }

    }
}
