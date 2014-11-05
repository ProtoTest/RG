using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbUnit.Framework;
using OpenQA.Selenium.Interactions;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver.Elements;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.PageObjects.RG
{

    public class LoggedInHeader : HeaderBase
    {
        // User-Account Dropdown link
        Link UserAccount_Link = new Link("User Account Box Link", By.XPath("//*[@class='account-box']/a[1]"));

        // User-account dropdown menu links
        Link YourVideos_Link = new Link("Your Videos -- Link", By.PartialLinkText("Your Videos"));
        Link YourProfile_Link = new Link("Your Profile -- Link", By.PartialLinkText("Your Profile"));
        Link Account_Link = new Link("Account -- Link", By.PartialLinkText("Account"));
        Link Signout_Link = new Link("Sign Out -- Link", By.PartialLinkText("Sign Out")); 

        public override void WaitForElements()
        {
            UserAccount_Link.WaitUntil().Visible();
        }
        
        public YourVideosPageBase EnterAccount_YourVideos()
        {
            UserAccount_Link.Click();
            YourVideos_Link.WaitUntil().Visible().Click();
            return new YourVideosPageBase();
        }

        public InstructorVideosPage EnterInstruction(string instructor)
        {
            Instruction.Click();
            new Element("Instructor - " + instructor, By.XPath("//a[contains(text(),'" + instructor + "') and contains(@href,'instruction')]")).WaitUntil().Visible().Click();

            return new InstructorVideosPage(instructor);
        }

        /*
        public YourProfilePage EnterAccount_YourProfile()
        {
            UserAccount_Link.Click();
            YourProfile_Link.WaitUntil().Visible().Click();
            return new YourProfilePage();
        }
        */
        public AccountPage EnterYourAccount()
        {
            UserAccount_Link.Click();
            Account_Link.WaitUntil().Visible().Click();
            return new AccountPage();
        }

        public HomePage LogOut()
        {
            UserAccount_Link.Click();
            Signout_Link.WaitUntil().Visible().Click();
            return new HomePage();
        }
    }
}
