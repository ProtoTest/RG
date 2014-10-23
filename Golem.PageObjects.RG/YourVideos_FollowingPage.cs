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
        public YourVideos_FollowingPage VerifyFollowingInstructor(string instructor)
        {
            // Iterate over all the instructor text elements found and see if any are visible
            System.Collections.ObjectModel.ReadOnlyCollection <IWebElement> instructor_text_refs = WebDriverTestBase.driver.FindElements(ByE.PartialText(instructor));
            if (instructor_text_refs.Count > 0)
            {
                bool found = false;
                foreach (IWebElement element in instructor_text_refs)
                {
                    // ignore option elements
                    if ((element.Displayed) && (!element.TagName.Equals("option")))
                    {
                        found = true;
                    }
                }

                if(!found) WebDriverTestBase.AddVerificationError("Failed to verify Instructor " + instructor + " is on the Following page. No visible elements found.");
            }

            string video_xpath = string.Format("//*[contains(@class, 'featured-video') and .//*[contains(text(),'{0}')]]", instructor);
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> instructor_videos = WebDriverTestBase.driver.FindElements(By.XPath(video_xpath));
            if (instructor_videos.Count <= 0)
            {
                WebDriverTestBase.AddVerificationError("Failed to verify Instructor " + instructor + " vidoes are displayed on the Following page");
            }

            return this;
        }

        public YourVideos_FollowingPage VerifyNotFollowingInstructor(string instructor)
        {
            // Attempt to find any element with 'text' of the instructor name in the DOM
            // Iterate through all of them and make sure they are not visible
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> instructor_text_refs = WebDriverTestBase.driver.FindElements(ByE.PartialText(instructor));
            if (instructor_text_refs.Count != 0)
            {
                bool found = false;
                foreach (IWebElement element in instructor_text_refs)
                {
                    // ignore option elements
                    if ((element.Displayed) && (!element.TagName.Equals("option")))
                    {
                        found = true;
                    }
                }

                if (found) WebDriverTestBase.AddVerificationError("Failed to verify user is NOT following Instructor " + instructor + " on the Following page. Visible Elements found.");
            }

            string video_xpath = string.Format("//*[contains(@class, 'featured-video') and .//*[contains(text(),'{0}')]]", instructor);
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> instructor_videos = WebDriverTestBase.driver.FindElements(By.XPath(video_xpath));
            if (instructor_videos.Count != 0)
            {
                WebDriverTestBase.AddVerificationError("Failed to verify Instructor " + instructor + " vidoes are NOT displayed on the Following page");
            }

            return this;
        }

        public override void WaitForElements()
        {
            new Element("Following header text", ByE.PartialText("Also Following")).Verify().Visible();
        }
    }
}
