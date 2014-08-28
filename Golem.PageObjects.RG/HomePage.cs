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
    public class HomePage : BasePageObject
    {
        //LoggedOutHeader loggedOutHeader = new LoggedOutHeader();
        //LoggedInHeader loggedInHeader = new LoggedInHeader();
        Element RG_Logo = new Element("RG LOGO", By.ClassName("logo"));
        public static HomePage OpenHomePage()
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(Config.GetConfigValue("EnvUrl", "http://revolutiongolf-integration-2014.bluemod.us/"));
            return new HomePage();
        }

        public override void WaitForElements()
        {
            RG_Logo.WaitUntil().Visible();
        }
    }
}
