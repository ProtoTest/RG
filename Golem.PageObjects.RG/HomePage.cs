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
        LoggedOutHeader LoggedOutHeader = new LoggedOutHeader();
        //LoggedInHeader loggedInHeader = new LoggedInHeader();
        Footer Footer = new Footer();

        Element FeaturedProduct = new Element("Featured Product", By.ClassName("product"));
        FeaturedProductInfo FeatureProductInfoArea = new FeaturedProductInfo();

        public HomePage(bool LoggedIn = false)
        {
            if (LoggedIn)
            {
                //LoggedInHeader.WaitForElements();
            }
            else
            {
                LoggedOutHeader.WaitForElements();
            }
        }

        public static HomePage OpenHomePage(bool LoggedIn = false)
        {
            WebDriverTestBase.driver.Navigate().GoToUrl(Config.GetConfigValue("EnvUrl", "http://revolutiongolf-integration-2014.bluemod.us/"));
            return new HomePage(LoggedIn);
        }


        public override void WaitForElements()
        {
            FeaturedProduct.WaitUntil().Visible();
            Footer.WaitForElements();
        }
    }
}
