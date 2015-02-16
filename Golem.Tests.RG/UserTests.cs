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

        [Test, Category("User Test")]
        public void VerifyApplicationUp()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email,Users.User1.password).LoggedInHeader.LogOut();
        }

        [Test, Category("User Test")]
        [DependsOn("VerifyApplicationUp")]
        public void CreateUserFromLoginPage()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                CreateAccount(Users.User2.email, Users.User1.password);
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
                          Users.RandomUser2.email, 
                          Users.RandomUser2.password).LoggedInHeader.LogOut();
        }

    }
}
