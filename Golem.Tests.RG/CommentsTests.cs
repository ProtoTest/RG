using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using Golem.PageObjects.RG;
using MbUnit.Framework;
using OpenQA.Selenium;
using Golem.PageObjects.RG.Components;

namespace Golem.Tests.RG
{
    public class CommentsTests : WebDriverTestBase
    {

        [Test, Category("Comments Tests")]
        public void AddCommentToVideo()
        {
            string video_to_search_for = "Golf Swing Tempo";
            string comment_to_add = "Comment: " + Common.GetRandomString();
            string display_name = Users.User1.email;

            HomePage.OpenHomePage().
               GotoLoginJoinPage().
               Login(Users.User1.email, Users.User1.password).
               LoggedInHeader.
               SearchFor(video_to_search_for).
               Videos.OpenFirstVideo().
                AddComment(comment_to_add).
                VerifyLatestComment(display_name, comment_to_add);
        }

        [Test, Category("Comments Tests"), DependsOn("AddCommentToVideo")]
        public void ReplyToCommentOnVideo()
        {
            string video_to_search_for = "ticket";
            string comment_to_add = "Comment: " + Common.GetRandomString();
            string display_name = Users.User1.email;

            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password).
                LoggedInHeader.SearchFor(video_to_search_for).Videos.
                OpenFirstVideo().ReplyToLatestComment(comment_to_add).
                VerifyReplyToLatestComment(display_name, comment_to_add);            
        }
    }
}
