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
    public class InstructorVideosPage : BasePageObject
    {
        public LoggedInHeader LoggedInHeader = new LoggedInHeader();
        Button FollowInstructor_Button = new Button("Follow/UnsFollow Instructor Button", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl03_ExpertFollowing_plcUp_followlnkBtn"));

        public InstructorVideosPage(string instructor)
        {
            new Element(instructor + " - Instructor Label", By.XPath(string.Format("//h1[contains(text(),'{0}')]", instructor))).Verify().Visible();
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
            FollowInstructor_Button.Verify().Text("FOLLOWING");
            FollowInstructor_Button.WaitUntil().Visible().Click();
            FollowInstructor_Button.Verify().Text("FOLLOW");

            return this;
        }

        public override void WaitForElements()
        {
            FollowInstructor_Button.Verify().Visible();
        }
    }
}
