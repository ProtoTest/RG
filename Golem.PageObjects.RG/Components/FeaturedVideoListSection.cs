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
using System.Collections.ObjectModel;

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

        public VideoPlayingPage SelectVideo()
        {
            this.Video_Link.Click();
            return new VideoPlayingPage();
        }
    }

    //public class FeaturedVideoListSection : BasePageObject
    //{
    //    public readonly List<VideoDetails> VideoList;

    //    public FeaturedVideoListSection()
    //    {
    //        VideoList = GetFeaturedVideoList();
    //    }

    //    //private List<VideoDetails> GetFeaturedVideoList()
    //    //{
    //    //    List<VideoDetails> video_detail_list = new List<VideoDetails>();
    //    //    ReadOnlyCollection<IWebElement> videos = WebDriverTestBase.driver.FindElements(By.XPath("//div[contains(@class,'featured-video')]"));

    //    //    foreach (IWebElement video in videos)
    //    //    {
    //    //        string video_title = video.FindInChildren(By.ClassName("title")).Text;
    //    //        IWebElement video_link_ele = video.FindInChildren(By.TagName("a"));
    //    //        video_detail_list.Add(new VideoDetails(video_link_ele, video_title));
    //    //    }

    //    //    return video_detail_list;
    //    //}

    //    public override void WaitForElements() 
    //    {
    //        new Element("Featured videos div section", By.ClassName("featured-videos")).Verify().Visible();
    //    }
        
    //}
}
