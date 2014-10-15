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

        public override void WaitForElements()
        {
            BaseHeader.WaitForElements();
            Join_Link.WaitUntil().Visible();
            Login_Link.WaitUntil().Visible();
        }
    }
}
