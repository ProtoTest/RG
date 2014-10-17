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
    public class AccountTests : WebDriverTestBase
    {

        [Test, Category("Account Tests")]
        public void UpgradeToRGPlus()
        {
            throw new NotImplementedException();
        }   

        [Test, Category("Account Tests")]
        public void EditAccountSettings_DisplayName()
        {
            string DisplayNameUT = "RG-Inator";

            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(UserTests.login_join_account_email, UserTests.account_password).
                LoggedInHeader.EnterYourAccount().
                UpdateAccountSettings(DisplayNameUT, null, null, null).
                VerifyAccountSettingsInfo(DisplayNameUT, UserTests.login_join_account_email);
        }

        [Test, Category("Account Tests")]
        public void EditAccountSettings_Login_Password()
        {
            string new_account_email = "prototest_" + Common.GetRandomString() + "@mailinator.com";
            string new_account_password = "prototest123";

            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(UserTests.login_join_account_email, UserTests.account_password).
                LoggedInHeader.EnterYourAccount().
                UpdateAccountSettings(null, new_account_email, UserTests.account_password, new_account_password).
                VerifyAccountSettingsInfo(null, new_account_email).
                LoggedInHeader.LogOut();

            // Update the login email and password
            UserTests.login_join_account_email = new_account_email;
            UserTests.account_password = new_account_password;

            // Login with the new credentials
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(UserTests.login_join_account_email, UserTests.account_password).
                LoggedInHeader.LogOut();
        }

        [Test, Category("Account Tests")]
        public void EditBilling()
        {
            throw new NotImplementedException();
        }

        [Test, Category("Account Tests")]
        public void Shipping_AddAddress()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(UserTests.login_join_account_email, UserTests.account_password).
                LoggedInHeader.EnterYourAccount().
                AddShippingAddress("1999 Broadway", null, "Denver", "Colorado", "80222", "USA").
                VerifyCurrentSelectedShippingAddress("1999 Broadway");
        }

        [Test, Category("Account Tests"), DependsOn("Shipping_AddAddress")]
        public void Shipping_DeleteAddress()
        {
            throw new NotImplementedException();


        }

        [Test, Category("Account Tests")]
        public void Shipping_EditAddress()
        {
            HomePage.OpenHomePage().
               GotoLoginJoinPage().
               Login(UserTests.login_join_account_email, UserTests.account_password).
               LoggedInHeader.EnterYourAccount().
               EditShippingAddress("1999 Broadway", "123 Fake St", null, "Littleton", null, "80127", null).
               VerifyCurrentSelectedShippingAddress("123 Fake St"); ;
        }

    }
}
