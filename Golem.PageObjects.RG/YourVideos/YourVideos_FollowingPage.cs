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

        Element ContainerForName = new Element(By.XPath("//div[@class='row' and .//div[contains(text(),'{0}')]]"));



        Element EditButton = new Element(By.ClassName("icon-icon-x"));
        Element UnfollowTopicButton = new Element(By.ClassName("follow"));
        Element UnfollowInstructorButton = new Element(By.ClassName("following-change-primary"));
        Element PrimaryButton = new Element(By.ClassName("primary-expert"));


        public YourVideos_FollowingPage VerifyFollowing(string instructor)
        {
            FollowingHeader.WithParam(instructor).Verify().Visible();
            return this;

        }

        public YourVideos_FollowingPage VerifyNotFollowing(string instructor)
        {
            FollowingHeader.WithParam(instructor).Verify().Not().Visible();
            return this;
        }

        public YourVideos_FollowingPage UnFollowTopic(string name)
        {
            driver.Sleep(1000);
            ContainerForName.WithParam(name).FindElement(EditButton).Click();
            driver.Sleep(1000);
            UnfollowTopicButton.WaitUntil().Present().GetVisibleElement().Click();
            return new YourVideos_FollowingPage();
        }

        public YourVideos_FollowingPage UnFollowInstructor(string name)
        {
            driver.Sleep(1000);
            ContainerForName.WithParam(name).FindElement(EditButton).Click();
            driver.Sleep(1000);
            UnfollowInstructorButton.WaitUntil().Present().GetVisibleElement().Click();
            return new YourVideos_FollowingPage();
        }
        public override void WaitForElements()
        {
            new Element("Following header text", ByE.PartialText("Also Following")).Verify().Visible();
        }
    }
}
