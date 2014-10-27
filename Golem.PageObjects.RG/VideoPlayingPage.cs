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
    public class VideoPlayingPage : BasePageObject
    {
        public LoggedInHeader LoggedInHeader = new LoggedInHeader();

        Element Video = new Element("BrightCove video", By.XPath("//*[@id='video-container']//object"));
        Link AddToQueue_Link = new Link("Add video to queue link", By.XPath("//*[@id='video-container']//a[contains(@class,'add')]"));
        Link AddToFavorites_Link = new Link("Add video to favorites", By.XPath("//*[@id='video-container']//a[contains(@class,'favorite')]"));
        Link ShareVideo_Link = new Link("Share", By.XPath("//*[@id='video-container']//a[@class='share-video']"));

        public VideoPlayingPage AddToQueue()
        {
            Video.MouseOver();

            if (!AddToQueue_Link.GetAttribute("class").Contains("active"))
            {
                AddToQueue_Link.WaitUntil().Visible().Click();

                // After adding the video, the 'class' attribute now has an 'active' name addeds 
                AddToQueue_Link.WaitUntil().CSS("class", "active");

                // TODO: Image verification?
            }
            else
            {
                TestBase.Log("This video is already added to the user Queue list of videos");
            }

            return this;
        }

        public VideoPlayingPage AddToFavorites()
        {
            Video.MouseOver();

            if (!AddToFavorites_Link.GetAttribute("class").Contains("active"))
            {
                AddToFavorites_Link.Verify().Visible().Click();

                // After adding the video, the 'class' attribute now has an 'active' name addeds 
                AddToFavorites_Link.WaitUntil().CSS("class", "active");

                // TODO: Image verification?
            }
            else
            {
                TestBase.Log("This video is already added to the user favorites list of videos");
            }
            return this;
        }


        public override void WaitForElements()
        {
            Video.Verify().Visible();
        }
    }
}
