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
using Golem.PageObjects.RG;

namespace Golem.PageObjects.RG
{
    public class HeaderBase : BasePageObject
    {
        protected Element RG_Logo = new Element("RG LOGO", By.ClassName("logo"));
        protected Element Instruction = new Element("Instruction Hover", By.XPath("//nav//a[contains(text(),'Instruction')]"));
        protected Element Shop = new Element("Shop Link", By.XPath("//nav//a[contains(text(),'Shop')]"));
        protected Element RG = new Element("@RG Hover", By.XPath("//nav//a[contains(text(),'@RG')]"));
        protected Element RG_Live = new Element("RG Live Hover", By.XPath("//nav//a[contains(text(),'RG Live')]"));
        protected Element Search = new Element("Search Link", By.XPath("//*[text()='Search']"));

        public SearchResultsPage SearchFor(string text)
        {
            Search.Click();
            return new SearchResultsPage().SearchFor(text);
        }

        public override void WaitForElements()
        {
            RG_Logo.Verify().Visible();
            Instruction.Verify().Visible();
            Shop.Verify().Visible();
            RG.Verify().Visible();
            RG_Live.Verify().Visible();
            Search.Verify().Visible();
        }
    }
}
