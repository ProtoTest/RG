using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.RG
{
    public class RGPlusUpsellPage : BasePageObject
    {
        public Element BecomeAMember_Label = new Element(ByE.Text("Become a Member Get Full Access."));
        public Element Video = new Element(By.ClassName("video-wrapper"));
        public Element LeftPanelText = new Element(By.ClassName("left-side"));
        public Element RGMonthlyButton = new Element(ByE.PartialText("RG+ Monthly Membership"));
        public Element RGAnnualButton = new Element(ByE.PartialText("RG+ Annual Membership"));
        public Element RGLifetimeButton = new Element(ByE.PartialText("RG+ Lifetime Membership"));

        public override void WaitForElements()
        {
            BecomeAMember_Label.Verify().Visible();
            Video.Verify().Visible();
            LeftPanelText.Verify().Visible();
            RGMonthlyButton.Verify().Visible();
            RGAnnualButton.Verify().Visible();
            RGLifetimeButton.Verify().Visible();
        }
    }
}
