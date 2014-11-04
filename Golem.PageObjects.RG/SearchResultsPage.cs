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
    public class SearchResultsPage : BasePageObject
    {
        protected Field Search_Field = new Field("Search box input", By.Id("p_lt_ctl00_sbSearchBox_txtWord"));
        protected Element SearchResult_Video_Section = new Element("Video Search Results", By.XPath("//h2//*[contains(text(),'Videos')]"));

        public SearchResultsPage SearchFor(string text)
        {
            Search_Field.Text = text;
            Search_Field.SendKeys(Keys.Enter);

            return new SearchResultsPage();
        }

        public override void WaitForElements()
        {
            Search_Field.WaitUntil().Visible();
        }
    }
}
