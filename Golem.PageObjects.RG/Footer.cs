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
    public class Footer : BasePageObject
    {
        Link RG_Logo_Link = new Link("RG Logo Link", By.ClassName("logo-footer"));
        Link Twitter_Link = new Link("Twitter Link", By.ClassName("twitter"));
        Link Facebook_Link = new Link("Facebook Link", By.ClassName("facebook"));
        Link GooglePlus_Link = new Link("Google Plus Link", By.ClassName("google"));

        Link About_Link = new Link("About Link", By.XPath("//a[text()='About']"));
        Link Contact_Link = new Link("Contact Link", By.XPath("//*[@class='footer-nav']//a[text()='Contact Us']"));
        Link FAQ_Link = new Link("FAQ Link", By.XPath("//a[text()='FAQ']"));
        Link TOS_Link = new Link("Terms of Service Link", By.XPath("//a[text()='Terms of Service']"));
        Link Privacy_Link = new Link("Privacy Policy Link", By.XPath("//a[text()='Privacy Policy']"));
        Element Copyright_Label = new Element("Copyright Label", By.XPath("//*[@class='copyright' and text()='© Revolution Golf " + System.DateTime.Now.Year + "']"));

        public override void WaitForElements()
        {
            RG_Logo_Link.Verify().Visible();
            Twitter_Link.Verify().Visible();
            Facebook_Link.Verify().Visible();
            GooglePlus_Link.Verify().Visible();

            About_Link.Verify().Visible();
            Contact_Link.Verify().Visible();
            FAQ_Link.Verify().Visible();
            TOS_Link.Verify().Visible();
            Privacy_Link.Verify().Visible();
            Copyright_Label.Verify().Visible();
        }
    }
}
