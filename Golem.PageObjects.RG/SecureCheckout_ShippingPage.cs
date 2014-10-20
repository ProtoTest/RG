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
    public class SecureCheckout_ShippingPage : BasePageObject
    {
        Dropdown SavedAddress_Dropdown = new Dropdown("Saved Address Dropdown", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_drpAddresses"));
        Field Billing_Phone = new Field("Billing phone number field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressPhone_textbox"));
        Field Billing_FullName_Field = new Field("Billing Full name field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_cdCustomerDetails_plcUp_customerForm_CustomerFirstName_textbox"));
        Field Billing_Address1_field = new Field("Billing Address 1 field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressLine1_textbox"));
        Field Billing_Address2_field = new Field("Billing Address 2 field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressLine2_textbox"));
        Field Billing_Zip_field = new Field("Billing zip field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressZip_textbox"));
        Dropdown Billing_Country_Dropdown = new Dropdown("Billing Country Dropdown", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressCountryID_uniSelectorCountry_drpSingleSelect"));
        Dropdown Billing_State_Dropdown = new Dropdown("Billing State dropdown", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressCountryID_uniSelectorState_drpSingleSelect"));
        Field Billing_City_field = new Field("Billing City field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressCity_textbox"));

        Button Continue_Button = new Button("Continue button", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl01_dwbNext_btn_hyperLink"));

        public SecureCheckout_BillingPage ContinueToNextStep()
        {
            Continue_Button.WaitUntil().Visible().Click();

            return new SecureCheckout_BillingPage();
        }

        public override void WaitForElements()
        {
            
        }
    }
}
