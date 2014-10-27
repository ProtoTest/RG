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

namespace Golem.PageObjects.RG.Components
{
    public class VideoDetails
    {
        public readonly IWebElement Video_Link;
        public readonly string Video_Title;

        public VideoDetails(IWebElement Video_Link, string Video_Title)
        {
            this.Video_Link = Video_Link;
            this.Video_Title = Video_Title;
        }
    }
}
