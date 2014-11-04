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
    public class SecureCheckout_OrderConfirmationPage : BasePageObject
    {
        protected Link PrintCopy_Link = new Link("Print a Copy Link", By.PartialLinkText("PRINT A COPY"));

        public override void WaitForElements()
        {
            new Element("Thank you label", By.XPath("//*[text()='Thank You']")).Verify().Visible();
            PrintCopy_Link.Verify().Visible();
        }

        public void VerifyOrder(string UserEmail)
        {
            string confirm_txt = string.Format("An Order Confirmation has been sent to: {0}", UserEmail);

            new Element("Order confirm label with email", By.XPath("//*[@class='confirmation']")).Verify().Visible().Verify().Text(confirm_txt);
        }
    }
}
