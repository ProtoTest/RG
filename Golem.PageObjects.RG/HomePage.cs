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
        private static bool logged_in = false;
        public bool LoggedIn { get {return logged_in;} }

        public LoggedOutHeader LoggedOutHeader = null;
        public LoggedInHeader LoggedInHeader = null;

        //Element FeaturedProduct = new Element("Featured Product", By.ClassName("product"));
        // Not on page currently //FeaturedProductInfo FeatureProductInfoArea = new FeaturedProductInfo();

        public HomePage(bool LoggedIn=false)
        {
            logged_in = LoggedIn;

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
                throw new Exception("Trying to join, when application state appears to already be logged in");
            }
        }

        public JoinPage GotoJoinPage()
        {
            if (!LoggedIn)
            {
                return LoggedOutHeader.GotoJoinPage();
            }
            else
            {
                throw new Exception("Trying to login/join, when application state appears to already be logged in");
            }
        }


        public override void WaitForElements()
        {
            // Not currently on page // FeaturedProduct.WaitUntil().Visible();

        }
    }
}
