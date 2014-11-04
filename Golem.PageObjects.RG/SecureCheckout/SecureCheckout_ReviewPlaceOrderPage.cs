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
    public class SecureCheckout_ReviewPlaceOrderPage : BasePageObject
    {
        public Checkbox AcceptTerms_Checkbox = new Checkbox("Accept Terms and Conditions checkbox", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_ConfirmationCheckbox_chkAccept"));
        public Button PlaceOrder_Button = new Button("Place Order Button", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl01_dwbNext_btn_btn"));

        public SecureCheckout_OrderConfirmationPage PlaceOrder()
        {
            AcceptTerms_Checkbox.Click();
            PlaceOrder_Button.Click();

            return new SecureCheckout_OrderConfirmationPage();
        }

        public override void WaitForElements()
        {
            AcceptTerms_Checkbox.WaitUntil().Visible();
            PlaceOrder_Button.WaitUntil().Visible();
        }
    }
}
