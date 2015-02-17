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
    public class LoggedOutHeader : HeaderBase
    {
        HeaderBase BaseHeader = new HeaderBase();
        Element Join_Link = new Element("JOIN Link", By.XPath("//a[text()='Join']"));
        Element Login_Link = new Element("LOG IN Link", By.XPath("//a[text()='Log In']"));
        Link RGLive_Hover = new Link(By.CssSelector("li[class=nav-live] a"));
        Link RGLive_Link = new Link(By.CssSelector("a[href*=rg-live]"));
        Link RGTV_Link = new Link(By.LinkText("RG RV"));

        public LoginJoinPage GotoLoginJoinPage()
        {
            Login_Link.Click();
            return new LoginJoinPage();
        }

        public JoinPage GotoJoinPage()
        {
            Join_Link.Click();
            return new JoinPage();
        }

        public BecomeMemberPage OpenRGLive()
        {
            driver.Sleep(1000);
            RGLive_Hover.WaitUntil().Visible().Click();
            driver.Sleep(1000);
            RGLive_Link.WaitUntil().Visible().Click();
            RGLive_Link.WaitUntil().Not().Visible();
            return new BecomeMemberPage();
        }

        public BecomeMemberPage OpenRGTV()
        {
            RGLive_Hover.MouseOver();
            RGTV_Link.Click();
            return new BecomeMemberPage();
        }

        public override void WaitForElements()
        {
            BaseHeader.WaitForElements();
            Join_Link.WaitUntil().Visible();
            Login_Link.WaitUntil().Visible();
        }
    }
}
