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
    public class SmokeTest : WebDriverTestBase
    {
        private string login_join_account_email = "prototest_" + Common.GetRandomString() + "_1@mailinator.com";
        private string subscribe_account_email = "prototest_" + Common.GetRandomString() + "_2@mailinator.com";
        private string account_password = Config.GetConfigValue("Password", "prototest123");

        [Test, Category("Smoke Test")]
        public void VerifyApplicationUp()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Config.GetConfigValue("GlobalAdmin", ""),
                      account_password).LoggedInHeader.LogOut();
        }

        [Test, Category("Smoke Test")]
        [DependsOn("VerifyApplicationUp")]
        public void CreateUserFromLoginPage()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                CreateAccount(login_join_account_email, account_password);
        }

        [Test, Category("Smoke Test")]
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
