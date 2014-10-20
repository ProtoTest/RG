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
    public class BecomeMemberPage : BasePageObject
    {
        public enum MEMBERSHIP_TYPE { ANNUAL, LIFETIME, MONTHLY };

        public LoggedInHeader LoggedInHeader = new LoggedInHeader();
        public Button Annual_Membership_Button = new Button("Annual Membership purchase button", ByE.PartialAttribute("input", "value", "Annual Membership"));
        public Button Lifetime_Membership_Button = new Button("Lifetime Membership purchase button", ByE.PartialAttribute("input", "value", "Lifetime Membership"));
        public Button Monthly_Membership_Button = new Button("Monthly Membership purchase button", ByE.PartialAttribute("input", "value", "Monthly Membership"));

        public SecureCheckout_ShippingPage SelectMembership(MEMBERSHIP_TYPE type)
        {
            switch(type)
            {
                case MEMBERSHIP_TYPE.ANNUAL: Annual_Membership_Button.WaitUntil().Visible().Click(); break;
                case MEMBERSHIP_TYPE.LIFETIME: Lifetime_Membership_Button.WaitUntil().Visible().Click(); break;
                case MEMBERSHIP_TYPE.MONTHLY: Monthly_Membership_Button.WaitUntil().Visible().Click(); break;
                default:
                    throw new Exception("Invalid Membership type parameter");
            }

            return new SecureCheckout_ShippingPage();
        }

        public override void WaitForElements()
        {
            
        }
    }
}
