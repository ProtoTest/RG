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
    public class YourVideos_FollowingPage : YourVideosPageBase
    {
        Element FollowingHeader = new Element(By.XPath("//div[@class='vm-title' and contains(text(),'{0}')]"));

        public YourVideos_FollowingPage VerifyFollowingInstructor(string instructor)
        {
            FollowingHeader.WithParam(instructor).Verify().Visible();
            return this;

        }

        public YourVideos_FollowingPage VerifyNotFollowingInstructor(string instructor)
        {
            FollowingHeader.WithParam(instructor).Verify().Not().Visible();
            return this;
        }

        public override void WaitForElements()
        {
            new Element("Following header text", ByE.PartialText("Also Following")).Verify().Visible();
        }
    }
}
