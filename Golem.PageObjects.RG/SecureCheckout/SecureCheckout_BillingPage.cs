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
    public class SecureCheckout_BillingPage : BasePageObject
    {
        Dropdown PaymentMethod_Dropdown = new Dropdown("Payment Method Dropdown", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_pmsPaymentMethod_drpPayment_uniSelector_drpSingleSelect"));
        Button Continue_Button = new Button("Continue button", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl01_dwbNext_btn_btn"));

        public SecureCheckout_ReviewPlaceOrderPage ContinueToNextStep()
        {
            Continue_Button.Click();

            return new SecureCheckout_ReviewPlaceOrderPage();
        }

        public SecureCheckout_BillingPage SelectTestPayment()
        {
            PaymentMethod_Dropdown.SelectOptionByPartialText("Test");

            return new SecureCheckout_BillingPage();
        }

        public override void WaitForElements()
        {
            PaymentMethod_Dropdown.WaitUntil().Visible();
            Continue_Button.WaitUntil().Visible();
        }
    }
}
