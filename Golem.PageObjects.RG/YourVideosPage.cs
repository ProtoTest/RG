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
    public class YourVideosPage : BasePageObject
    {
        Element YourVideos_Label = new Element("Your Videos Label", By.XPath("//div[contains(text(),'Your Videos')]"));

        public override void WaitForElements()
        {
            YourVideos_Label.Verify().Visible();

        }
    }
}
