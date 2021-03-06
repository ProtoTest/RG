﻿using System;
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
        Link RGLive_Hover = new Link(By.CssSelector("li[class=nav-live] a"));
        Link RGLive_Link = new Link(By.CssSelector("a[href*=rg-live]"));
        Link RGTV_Link = new Link(By.LinkText("RG RV"));


        public override void WaitForElements()
        {
            UserAccount_Link.WaitUntil().Visible();
        }

        public YourVideos_FollowingPage EnterAccount_YourVideos()
        {
            UserAccount_Link.Click();
            YourVideos_Link.WaitUntil().Visible().Click();
            return new YourVideos_FollowingPage();
        }

        public InstructorVideosPage EnterInstruction(string instructor)
        {
            driver.Sleep(1000);
            Instruction.WaitUntil().Visible().MouseOver();

            var instrcutorLink = new Element("Instructor - " + instructor,
                By.XPath("//a[contains(text(),'" + instructor + "') and contains(@href,'instruction')]"));
            for(var i=0;i<5&&!instrcutorLink.IsDisplayed(5);i++)
            {
                Instruction.Click();
            }
            instrcutorLink.Click();
            driver.Sleep(1000);
            return new InstructorVideosPage(instructor);
        }

        public BaseTopicPage EnterTopic(string instructor)
        {
            driver.Sleep(1000);
            Instruction.WaitUntil().Visible().MouseOver();

            var instrcutorLink = new Element("Instructor - " + instructor,
                By.XPath("//a[contains(text(),'" + instructor + "') and contains(@href,'instruction')]"));
            for (var i = 0; i < 5 && !instrcutorLink.IsDisplayed(5); i++)
            {
                Instruction.Click();
            }
            instrcutorLink.Click();
            driver.Sleep(1000);
            return new BaseTopicPage();
        }

        public BecomeMemberPage OpenRGLiveAsNonPlus()
        {
            driver.Sleep(1000);
            RGLive_Hover.WaitUntil().Visible().Click();
            driver.Sleep(1000);
            RGLive_Link.WaitUntil().Visible().Click();
            RGLive_Link.WaitUntil().Not().Visible();
            return new BecomeMemberPage();
        }

        public RGLivePage OpenRGLiveAsPlusMember()
        {
            driver.Sleep(1000);
            RGLive_Hover.WaitUntil().Visible().Click();
            driver.Sleep(1000);
            RGLive_Link.WaitUntil().Visible().Click();
            RGLive_Link.WaitUntil().Not().Visible();
            return new RGLivePage();
        }

        public RGTVPage OpenRGTVAsPlus()
        {
            RGLive_Hover.MouseOver();
            RGTV_Link.Click();
            return new RGTVPage();
        }

        public AccountPage EnterYourAccount()
        {
            UserAccount_Link.Click();
            Account_Link.WaitUntil().Visible().Click();
            return new AccountPage();
        }

        public HomePage LogOut()
        {
            UserAccount_Link.WaitUntil().Visible().MouseOver();
            Signout_Link.WaitUntil().Visible().Click();
            return new HomePage();
        }
    }
}
