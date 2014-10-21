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
    public class HeaderBase : BasePageObject
    {
        Element RG_Logo = new Element("RG LOGO", By.ClassName("logo"));
        Element Instruction = new Element("Instruction Hover", By.XPath("//nav//a[contains(text(),'Instruction')]"));
        Element Shop = new Element("Shop Link", By.XPath("//nav//a[contains(text(),'Shop')]"));
        Element RG = new Element("@RG Hover", By.XPath("//nav//a[contains(text(),'@RG')]"));
        Element RG_Live = new Element("RG Live Hover", By.XPath("//nav//a[contains(text(),'RG Live')]"));
        Element Search = new Element("Search Link", By.XPath("//*[text()='Search']"));

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
