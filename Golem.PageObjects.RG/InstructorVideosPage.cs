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
using Golem.PageObjects.RG.Components;
using ProtoTest.Golem.WebDriver.Elements;
using ProtoTest.Golem.WebDriver.Elements.Types;
using System.Collections.ObjectModel;

namespace Golem.PageObjects.RG
{
    public class InstructorVideosPage : BasePageObject
    {
        protected string instructor;
        public LoggedInHeader LoggedInHeader = new LoggedInHeader();
        protected Button FollowInstructor_Button = new Button("Follow/UnFollow Instructor Button", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl03_ExpertFollowing_plcUp_followlnkBtn"));

        public InstructorVideosPage(string instructor)
        {
            this.instructor = instructor;
        }

        public InstructorVideosPage FollowInstructor()
        {
            if (!FollowInstructor_Button.Text.Contains("FOLLOWING"))
            {
                FollowInstructor_Button.Verify().Text("FOLLOW");
                FollowInstructor_Button.WaitUntil().Visible().Click();
                FollowInstructor_Button.Verify().Text("FOLLOWING");
            }
            else
            {
                WebDriverTestBase.Log("Already following this instructor");
            }

            return this;
        }

        public InstructorVideosPage UnFollowInstructor()
        {
            if (FollowInstructor_Button.Text.Contains("FOLLOWING"))
            {
                FollowInstructor_Button.Verify().Text("FOLLOWING");
                FollowInstructor_Button.WaitUntil().Visible().Click();
                FollowInstructor_Button.Verify().Text("FOLLOW");
            }
            else
            {
                WebDriverTestBase.Log("Already following instructor: " + instructor);
            }

            return this;
        }

        public List<VideoDetails> GetFeaturedVideoList()
        {
            List<VideoDetails> video_detail_list = new List<VideoDetails>();
            ReadOnlyCollection<IWebElement> videos = WebDriverTestBase.driver.FindElements(By.XPath("//div[contains(@class,'featured-video')]"));

            foreach (IWebElement video in videos)
            {
                string video_title = video.FindInChildren(By.ClassName("title")).Text;
                IWebElement video_link_ele = video.FindInChildren(By.TagName("a"));
                video_detail_list.Add(new VideoDetails(video_link_ele, video_title));
            }

            return video_detail_list;
        }

        public override void WaitForElements()
        {
            new Element(instructor + " - Instructor Label", By.XPath(string.Format("//h1[contains(text(),'{0}')]", instructor))).Verify().Visible();
            FollowInstructor_Button.Verify().Visible();
        }
    }
}
