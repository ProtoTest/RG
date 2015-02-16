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
using Golem.PageObjects.RG.Components;

namespace Golem.PageObjects.RG
{
    public class SearchResultsPage : BasePageObject
    {
        protected Field Search_Field = new Field("Search box input", By.CssSelector("input[id*=bSearchBox_txtWord]"));
        protected Element SearchResult_Video_Section = new Element("Video Search Results", By.XPath("//h2//*[contains(text(),'Videos')]"));
        public List<VideoDetails> FeaturedVideos;

        public SearchResultsPage SearchFor(string text)
        {
            Search_Field.Text = text;
            Search_Field.SendKeys(Keys.Enter);
            return new SearchResultsPage();
        }

        //public SearchResultsPage PopulateFeaturedVideosList()
        //{
        //    SearchResult_Video_Section.WaitUntil().Visible();
        //    FeaturedVideos = new FeaturedVideoListSection().VideoList;
        //    return this;
        //}

        public override void WaitForElements()
        {
            Search_Field.WaitUntil().Visible();
        }
    }
}
