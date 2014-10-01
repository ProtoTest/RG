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
        public static bool LoggedIn = false;
        LoggedOutHeader LoggedOutHeader = null;
        LoggedInHeader LoggedInHeader = null;
        Footer Footer = new Footer();

        Element FeaturedProduct = new Element("Featured Product", By.ClassName("product"));
        // Not on page currently //FeaturedProductInfo FeatureProductInfoArea = new FeaturedProductInfo();

        public HomePage()
        {
            if (LoggedIn)
            {
                LoggedInHeader = new LoggedInHeader();
            }
            else
            {
                LoggedOutHeader = new LoggedOutHeader();
            }
        }

        public static HomePage OpenHomePage()
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(Config.GetConfigValue("EnvUrl", "http://revolutiongolf-integration-2014.bluemod.us/"));
            return new HomePage();
        }

        public LoginJoinPage GotoLoginJoinPage()
        {
            if (!LoggedIn)
            {
                return LoggedOutHeader.GotoLoginJoinPage();
            }
            else
            {
                throw new Exception("Trying to login, when state appears to already be logged in");
            }
        }


        public override void WaitForElements()
        {
            // Not currently on page // FeaturedProduct.WaitUntil().Visible();
            Footer.WaitForElements();
        }
    }
}
