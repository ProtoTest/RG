﻿using System;
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
    public class YourVideosPageBase : BasePageObject
    {
        public LoggedInHeader LoggedInHeader = new LoggedInHeader();
        Element YourVideos_Label = new Element("Your Videos Label", By.XPath("//div[contains(text(),'Your Videos')]"));
        Link Following_Link = new Link("Your Videos - Following Link", By.PartialLinkText("Following"));
        Link Queue_Link = new Link("Your Videos - Following Link", By.PartialLinkText("Queue"));
        Link Favorites_Link = new Link("Your Videos - Following Link", By.PartialLinkText("Favorites"));

        public YourVideos_FollowingPage EnterFollowing()
        {
            Following_Link.Click();
            return new YourVideos_FollowingPage();
        }

        public YourVideos_QueuePage EnterQueue()
        {
            Queue_Link.Click();
            return new YourVideos_QueuePage();
        }

        public YourVideos_FavoritesPage EnterFavorites()
        {
            Favorites_Link.Click();
            return new YourVideos_FavoritesPage();
        }

        public override void WaitForElements()
        {
            YourVideos_Label.Verify().Visible();
            Following_Link.WaitUntil().Visible();
            Queue_Link.WaitUntil().Visible();
            Favorites_Link.WaitUntil().Visible();
        }
    }
}
