﻿using System;
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
        public string NoPaymentAddedText = "Add new credit card";

        ////this test is disabled as we don't want to upgrade to RG+ as there is currently a hack
        //[Disable]
        //[Test, Category("Account Tests")]
        //public void UpgradeToRGPlus()
        //{
        //    HomePage.OpenHomePage().
        //        GotoLoginJoinPage().
        //        Login(Users.User1.email, Users.User1.password).
        //        LoggedInHeader.EnterYourAccount().
        //        Upgrade_To_RG_Plus().
        //        SelectMembership(BecomeMemberPage.MEMBERSHIP_TYPE.ANNUAL).
        //        EnterShippingDetails("ProtoTest Tester", "1999 Broadway", null, "303-896-5309", "80222", "USA", "Colorado", "Denver").
        //        ContinueToNextStep().
        //        SelectTestPayment().
        //        ContinueToNextStep().
        //        PlaceOrder().
        //        VerifyOrder(Users.User1.email);
        //}   

        //[Test, Category("Account Tests")]
        //public void EditAccountSettings_DisplayName()
        //{
        //    string DisplayNameUT = "RG-Inator";

        //    HomePage.OpenHomePage().
        //        GotoLoginJoinPage().
        //        Login(Users.User1.email, Users.User1.password).
        //        LoggedInHeader.EnterYourAccount().
        //        UpdateAccountSettings(DisplayNameUT, null, null, null).
        //        VerifyAccountSettingsInfo(DisplayNameUT, Users.User1.email);
        //}

        //[Test, Category("Account Tests")]
        //public void EditAccountSettings_Login_Password()
        //{
        //    string new_account_email = "prototest_" + Common.GetRandomString() + "@mailinator.com";
        //    string new_account_password = "prototest123";

        //    HomePage.OpenHomePage().
        //        GotoLoginJoinPage().
        //        Login(Users.User1.email, Users.User1.password).
        //        LoggedInHeader.EnterYourAccount().
        //        UpdateAccountSettings(null, new_account_email, Users.User1.password, new_account_password).
        //        VerifyAccountSettingsInfo(null, new_account_email).
        //        LoggedInHeader.LogOut();

        //    // Update the login email and password
        //    Users.User1.email = new_account_email;
        //    Users.User1.password = new_account_password;

        //    // Login with the new credentials
        //    HomePage.OpenHomePage().
        //        GotoLoginJoinPage().
        //        Login(Users.User1.email, new_account_password).
        //        LoggedInHeader.LogOut();
        //}

        //[Test, Category("Account Tests")]
        //public void Add_Billing_Preferred_Payment()
        //{
        //    string exp_month = "12";
        //    string exp_year = "2022";
        //    string name = "James VanDerBeek";
        //    string address = "1999 Broadway, Denver, CO 80122";
        //    string ccv = "123";
        //    string test_cc = "4111111111111111";
        //    string cc_last_four = "1111";

        //    HomePage.OpenHomePage().
        //        GotoLoginJoinPage().
        //        Login(Users.User1.email, Users.User1.password).
        //        LoggedInHeader.EnterYourAccount().
        //        EditPreferredPayment(name, test_cc, exp_month, exp_year, ccv, address).
        //        VerifyPreferredPayment(name, cc_last_four, exp_month, exp_year, address);

        //    // Verify the address was updated
        //    HomePage.OpenHomePage(true).
        //        LoggedInHeader.EnterYourAccount().
        //        VerifyPreferredPayment(name, cc_last_four, exp_month, exp_year, address);
        //}
        
        //[Test, Category("Account Tests"), DependsOn("Add_Billing_Preferred_Payment")]
        //public void Edit_Billing_Preferred_Payment()
        //{
        //    string exp_month = "11";
        //    string exp_year = "2021";
        //    string name = "Curt Russell";
        //    string address = "2100 Pennsylvania Ave, Washington, DC 20052";
        //    string ccv = "999";
        //    string test_cc = "4111111111111111";
        //    string cc_last_four = "1111";

        //    HomePage.OpenHomePage().
        //        GotoLoginJoinPage().
        //        Login(Users.User1.email, Users.User1.password).
        //        LoggedInHeader.EnterYourAccount().EditPreferredPayment(name, test_cc, exp_month, exp_year, ccv, address);

        //    // Verify the initial card label text and address was updated
        //    HomePage.OpenHomePage(true).
        //        LoggedInHeader.EnterYourAccount().
        //        VerifyPreferredPayment(name, cc_last_four, exp_month, exp_year, address);
        //}

        //[Test, Category("Account Tests"), DependsOn("Edit_Billing_Preferred_Payment")]
        //public void Delete_Billing_Preferred_Payment()
        //{
        //    HomePage.OpenHomePage().
        //        GotoLoginJoinPage().
        //        Login(Users.User1.email, Users.User1.password).
        //        LoggedInHeader.EnterYourAccount().
        //        DeletePreferredPayment().
        //        VerifyPreferredPayment_DropDown_Text(NoPaymentAddedText).LoggedInHeader.LogOut();

        //    // Log back in and verify still no payment added
        //    VerifyNoPreferredPaymentAdded();
        //}

        //[Test, Category("Account Tests")]
        //public void Shipping_AddAddress()
        //{
        //    HomePage.OpenHomePage().
        //        GotoLoginJoinPage().
        //        Login(Users.User1.email, Users.User1.password).
        //        LoggedInHeader.EnterYourAccount().
        //        AddShippingAddress("1999 Broadway", null, "Denver", "Colorado", "80222", "USA").
        //        VerifyCurrentSelectedShippingAddress("1999 Broadway");
        //}

        //[Test, Category("Account Tests"), DependsOn("Shipping_AddAddress")]
        //public void Shipping_EditAddress()
        //{
        //    HomePage.OpenHomePage().
        //       GotoLoginJoinPage().
        //       Login(Users.User1.email, Users.User1.password).
        //       LoggedInHeader.EnterYourAccount().
        //       EditShippingAddress("1999 Broadway", "123 Fake St", null, "Littleton", "Colorado", "80127", "USA").
        //       VerifyCurrentSelectedShippingAddress("123 Fake St"); ;
        //}

        //[Test, Category("Account Tests"), DependsOn("Shipping_EditAddress") ]
        //public void Shipping_DeleteAddress()
        //{
        //    throw new NotImplementedException();
        //}

        //private void VerifyNoPreferredPaymentAdded()
        //{
        //    HomePage.OpenHomePage().
        //        GotoLoginJoinPage().
        //        Login(Users.User1.email, Users.User1.password).
        //        LoggedInHeader.EnterYourAccount().
        //        VerifyPreferredPayment_DropDown_Text(NoPaymentAddedText);
        //}

    }
}
