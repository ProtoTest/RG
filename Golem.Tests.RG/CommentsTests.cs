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

        public CommentsTests()
        {
            Users.User1.email = "prototest_05004910_1@mailinator.com";
        }

        //[Test, Category("Comments Tests")]
        //public void AddCommentToVideo()
        //{
        //    string video_to_search_for = "TW-Video";
        //    string comment_to_add = "Comment: " + Common.GetRandomString();
        //    string display_name = Users.User1.email;

        //    // Search and navigate to first video
        //    SearchResultsPage search_results_page = HomePage.OpenHomePage().
        //       GotoLoginJoinPage().
        //       Login(Users.User1.email, Users.User1.password).
        //       LoggedInHeader.SearchFor(video_to_search_for);

        //    // Store teh first video and get its title
        //    VideoDetails first_video = search_results_page.PopulateFeaturedVideosList().FeaturedVideos.First();
        //    string video_name = first_video.Video_Title;

        //    // Select the video, make a comment, verify the comment is there added
        //    VideoPlayingPage video_playing_page = first_video.SelectVideo().
        //        AddComment(comment_to_add).
        //        VerifyLatestComment(display_name, comment_to_add);
        //}

        //[Test, Category("Comments Tests"), DependsOn("AddCommentToVideo")]
        //public void ReplyToCommentOnVideo()
        //{
        //    string video_to_search_for = "TW-Video";
        //    string comment_to_add = "Comment: " + Common.GetRandomString();
        //    string display_name = Users.User1.email;

        //    // Search and navigate to first video
        //    SearchResultsPage search_results_page = HomePage.OpenHomePage().
        //       GotoLoginJoinPage().
        //       Login(Users.User1.email, Users.User1.password).
        //       LoggedInHeader.SearchFor(video_to_search_for);

        //    // Store the first video and get its title
        //    VideoDetails first_video = search_results_page.PopulateFeaturedVideosList().FeaturedVideos.First();
        //    string video_name = first_video.Video_Title;

        //    // Select the video, make a comment, verify the comment is there added
        //    VideoPlayingPage video_playing_page = first_video.SelectVideo().
        //        ReplyToLatestComment(comment_to_add).
        //        VerifyReplyToLatestComment(display_name, comment_to_add);
        //}
    }
}
