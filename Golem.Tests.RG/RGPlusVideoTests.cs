using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Golem.PageObjects.RG;
using ProtoTest.Golem.WebDriver;
using MbUnit.Framework;

namespace Golem.Tests.RG
{
    class RGPlusVideoTests : WebDriverTestBase
    {
        [Test]
        public void VerifyNonPlusMemberGetsUpsell()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.RGPlus_User1.email, Users.RGPlus_User1.password)
                .LoggedInHeader.SearchFor("A special post-masters moment")
                .Videos.OpenFirstVideo();
        }

        [Test]
        public void VerifyVideoShowsForRGPlusMember()
        {
            HomePage.OpenHomePage().
                GotoLoginJoinPage().
                Login(Users.User1.email, Users.User1.password)
                .LoggedInHeader.SearchFor("A special post-masters moment")
                .Videos.OpenFirstVideoTORGUpsell();
        }

        [Test]
        public void VerifyAnonUser()
        {
            HomePage.OpenHomePage()
                .LoggedOutHeader.SearchFor("A special post-masters moment")
                .Videos.OpenFirstVideoAsAnonUser();
        }
    }
}
