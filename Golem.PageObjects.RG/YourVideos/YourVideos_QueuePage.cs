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
    public class YourVideos_QueuePage : YourVideosPageBase
    {
        public Element QueueButtonSelected = new Element(By.CssSelector("div[class~=active] span[class=icon-icon-plus]"));
        public override void WaitForElements()
        {
            //Assert.Contains(WebDriverTestBase.driver.Url, "queue", "Failed to verify webdriver is on the user 'queue' page");
            QueueButtonSelected.Verify().Visible();
        }
    }
}
