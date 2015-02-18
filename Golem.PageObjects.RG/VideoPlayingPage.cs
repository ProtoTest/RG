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
        Element FirstCommentContainer = new Element("First Comment Container", By.XPath("//ul[@class='comments-list']/li[1]//*[contains(@class,'comment-container')]"));
        Element FirstCommentReplyButton = new Element("FirstCommentReplyButton", By.XPath("//ul[@class='comments-list']/li[1]//*[contains(@class,'comment-container')]//a[text()='Reply']"));
        Element ReplyActionContainer = new Element("Reply Action Container", By.XPath("//ul[@class='comments-list']/li[1]//*[contains(@class,'reply-action-container')]/textarea"));
        Element ReplyActionSubmit = new Element("Reply Action Submit Button", By.XPath("//ul[@class='comments-list']/li[1]//*[contains(@class,'reply-action-container')]/div[contains(@class,'reply-actions')]/a[contains(@class,'btn-orange')]"));
               
        public LoggedInHeader LoggedInHeader = new LoggedInHeader();

        Element Video = new Element("BrightCove video", By.XPath("//*[@id='video-container']//object"));
        Link AddToQueue_Link = new Link("Add video to queue link", By.XPath("//*[@id='video-container']//a[contains(@class,'add')]"));
        Link AddToFavorites_Link = new Link("Add video to favorites", By.XPath("//*[@id='video-container']//a[contains(@class,'favorite')]"));
        Link ShareVideo_Link = new Link("Share", By.XPath("//*[@id='video-container']//a[@class='share-video']"));
        Element LatestCommentContainer = new Element(By.XPath("//ul[@class='comments-list']/li[1]"));
        Element CommentName = new Element(By.ClassName("name"));
        Element CommentText = new Element(By.XPath(".//div[contains(@class,'comment-text')]/p"));

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
            driver.Sleep(2000);
            LatestCommentContainer.FindElement(CommentName).Verify().Visible().Verify().Text(display_name);
            LatestCommentContainer.FindElement(CommentText).Verify().Visible().Verify().Text(comment_text);

            return this;
        }

        public VideoPlayingPage ReplyToLatestComment(string comment_to_add)
        {
            for (int i = 0; i < 4; i++)
            {
                FirstCommentContainer.Verify().Visible().MouseOver();
            }

            FirstCommentReplyButton.WaitUntil().Present().GetVisibleElement().Click();
            ReplyActionContainer.WaitUntil().Present().GetVisibleElement().SendKeys(comment_to_add);
            ReplyActionSubmit.WaitUntil().Present().GetVisibleElement().Click();

            return this;
        }

        public VideoPlayingPage VerifyReplyToLatestComment(string display_name, string comment_to_add)
        {
            Common.Delay(4000);
            return this;
        }
    }
}
