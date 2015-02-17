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
    public class InstructorVideosPage : BaseTopicPage
    {
        protected string instructor;
        public LoggedInHeader LoggedInHeader = new LoggedInHeader();
        protected Button FollowInstructor_Button = new Button("Follow Instructor Button", By.XPath("//a[contains(@id,'ExpertFollowing') and contains(text(),'Follow ')]"));

        protected Button UnFollowInstructor_Button = new Button("UnFollow Instructor Button",
            By.XPath("//a[contains(@id,'ExpertFollowing') and contains(text(),'Following')]"));
        protected Button PrimaryCoach_Button = new Button("Primary Instructor Button", By.PartialLinkText("Primary Instructor"));

       // public readonly List<VideoDetails> FeaturedVideos = new FeaturedVideoListSection().VideoList;

        public InstructorVideosPage(string instructor)
        {
            this.instructor = instructor;
        }

        public InstructorVideosPage FollowInstructor()
        {
           // if (FollowInstructor_Button.IsDisplayed(5))
                FollowInstructor_Button.GetVisibleElement().Click();
            return this;
        }

        public InstructorVideosPage UnFollowInstructor()
        {
         //   if (UnFollowInstructor_Button.IsDisplayed(5))
         //   {
                UnFollowInstructor_Button.GetVisibleElement().Click();
         //   }
            

            return this;
        }


        public override void WaitForElements()
        {
            new Element(instructor + " - Instructor Label", By.XPath(string.Format("//h1[contains(text(),'{0}')]", instructor))).Verify().Visible();
     
        }
    }
}
