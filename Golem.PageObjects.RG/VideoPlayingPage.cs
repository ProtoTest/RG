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

        Field MainComment_Field = new Field("Add new comment thread field", By.XPath("//*[@class='comment-input']//input"));
        Button Main_AddComment_Button = new Button("Add new comment thread button", By.XPath("//*[@class='comment-input']//a"));

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

        public VideoPlayingPage AddComment(string comment)
        {
            MainComment_Field.WaitUntil().Visible().Text = comment;
            Main_AddComment_Button.WaitUntil().Visible().Click();

            return this;
        }

        public override void WaitForElements()
        {
            Video.Verify().Visible();
            Main_AddComment_Button.Verify().Visible();
            MainComment_Field.Verify().Visible();
        }

        public VideoPlayingPage VerifyLatestComment(string display_name, string comment_text)
        {
            Element DisplayName = new Element("Latest Comment display name", By.XPath("//ul[@class='comments-list']/li[1]//*[contains(@class,'comment-container')]//span[contains(@class,'name')]"));
            Element CommentText = new Element("Latest Comment text", By.XPath("//ul[@class='comments-list']/li[1]//*[contains(@class,'comment-container')]//*[@class='comment-text']"));

            DisplayName.Verify().Visible().Verify().Text(display_name);
            CommentText.Verify().Visible().Verify().Text(comment_text);

            return this;
        }

        public VideoPlayingPage ReplyToLatestComment(string comment_to_add)
        {
            Element FirstCommentContainer = new Element("First Comment Container", By.XPath("//ul[@class='comments-list']/li[1]//*[contains(@class,'comment-container')]"));
            IWebElement FirstCommentReplyButton = FirstCommentContainer.FindInChildren(By.XPath(".//a[text()='Reply']"));

            FirstCommentContainer.Verify().Visible().MouseOver();
            FirstCommentContainer.Click();
            FirstCommentReplyButton.Verify().Visible().Click();

            return this;
        }

        public VideoPlayingPage VerifyReplyToLatestComment(string display_name, string comment_to_add)
        {
            Common.Delay(4000);
            return this;
        }
    }
}
