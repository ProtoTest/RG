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
using System.Collections.ObjectModel;

namespace Golem.PageObjects.RG.Components
{
    public class FeaturedVideoListSection : BasePageObject
    {
      //  public Element Container = new Element(By.ClassName("div-featured-videos"));
        public ElementCollection Videos = new ElementCollection(By.ClassName("featured-video"));

        public Element FirstVideo()
        {
            return Videos.First();
        }

        public VideoPlayingPage OpenFirstVideo()
        {
            Videos.FirstOrDefault().Click();
            return new VideoPlayingPage();
        }

        public LoginJoinPage OpenFirstVideoAsAnonUser()
        {
            Videos.FirstOrDefault().Click();
            return new LoginJoinPage();
        }

        public RGPlusUpsellPage OpenFirstVideoTORGUpsell()
        {
            Videos.FirstOrDefault().Click();
            return new RGPlusUpsellPage();
        }

        public Element VideoWithTitle(string name)
        {
            return Videos.First();
        }

        public override void WaitForElements()
        {
     
        }


    }
}
