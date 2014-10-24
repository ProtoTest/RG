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
            AddToQueue_Link.Verify().Visible().Click();

            // TODO: Verify CSS now that it is selected?
            return this;
        }

        public VideoPlayingPage AddToFavorites()
        {
            Video.MouseOver();
            AddToFavorites_Link.Verify().Visible().Click();

            // TODO: Verify CSS now that it is selected?
            return this;
        }


        public override void WaitForElements()
        {
            Video.Verify().Visible();
        }
    }
}
