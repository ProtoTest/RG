using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using Golem.PageObjects.RG;
using MbUnit.Framework;
using OpenQA.Selenium;

namespace Golem.Tests.RG
{
    [TestFixture]
    public class SmokeTest : WebDriverTestBase
    {
        [Test, Category("Smoke Test")]
        public void VerifyApplicationUp()
        {
            HomePage.OpenHomePage();
        }

        [Test, Category("Smoke Test")]
        public void LoginWithExistingUser()
        {
            HomePage.OpenHomePage();
        }

    }
}
