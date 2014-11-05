using System;
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
using System.Collections.Generic;

namespace Golem.PageObjects.RG
{
    public class InstructorVideosPage : BasePageObject
    {
        protected string instructor;
        public LoggedInHeader LoggedInHeader = new LoggedInHeader();
        protected Button FollowInstructor_Button = new Button("Follow/UnFollow Instructor Button", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl03_ExpertFollowing_plcUp_desktopLink"));
        public readonly List<VideoDetails> FeaturedVideos = new FeaturedVideoListSection().VideoList;

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


        public override void WaitForElements()
        {
            new Element(instructor + " - Instructor Label", By.XPath(string.Format("//h1[contains(text(),'{0}')]", instructor))).Verify().Visible();
            FollowInstructor_Button.Verify().Visible();
        }
    }
}
