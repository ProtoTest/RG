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
    /// <summary>
    ///  First page of the secure Checkout Flow
    /// </summary>
    public class SecureCheckout_ShippingPage : BasePageObject
    {
        Dropdown SavedAddress_Dropdown = new Dropdown("Saved Address Dropdown", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_drpAddresses"));
        Field Shipping_Phone = new Field("Billing phone number field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressPhone_textbox"));
        Field Shipping_FullName_Field = new Field("Billing Full name field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_cdCustomerDetails_plcUp_customerForm_CustomerFirstName_textbox"));
        Field Shipping_Address1_field = new Field("Billing Address 1 field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressLine1_textbox"));
        Field Shipping_Address2_field = new Field("Billing Address 2 field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressLine2_textbox"));
        Field Shipping_Zip_field = new Field("Billing zip field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressZip_textbox"));
        Dropdown Shipping_Country_Dropdown = new Dropdown("Billing Country Dropdown", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressCountryID_uniSelectorCountry_drpSingleSelect"));
        Dropdown Shipping_State_Dropdown = new Dropdown("Billing State dropdown", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressCountryID_uniSelectorState_drpSingleSelect"));
        Field Shipping_City_field = new Field("Billing City field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl00_caAddressShipping_plcUp_addressForm_AddressCity_textbox"));

        Button Continue_Button = new Button("Continue button", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl00_pphCartContent_p_lt_ctl02_pphCartContainer_p_lt_ctl01_dwbNext_btn_hyperLink"));

        public SecureCheckout_BillingPage ContinueToNextStep()
        {
            Continue_Button.Click();

            return new SecureCheckout_BillingPage();
        }

        private void EnterFormDetails(string full_name, string address1, string address2, string phone, string zip, string country, string state, string city)
        {
            if (full_name != null) Shipping_FullName_Field.Text = full_name;
            if (address1 != null) Shipping_Address1_field.Text = address1;
            if (address2 != null) Shipping_Address2_field.Text = address2;
            if (phone != null) Shipping_Phone.Text = phone;
            if (zip != null) Shipping_Zip_field.Text = zip;
            if (country != null) Shipping_Country_Dropdown.SelectOptionByPartialText(country);
            if (state != null) Shipping_State_Dropdown.SelectOptionByPartialText(state);
            if (city != null) Shipping_City_field.Text = city;
        }

        public SecureCheckout_ShippingPage EnterShippingDetails(string full_name, string address1, string address2, string phone, string zip, string country, string state, string city)
        {
            EnterFormDetails(full_name, address1, address2, phone, zip, country, state, city);
            return this;
        }

        public override void WaitForElements()
        {
            Continue_Button.WaitUntil().Visible();
            // Continue_Button.Verify().Text("Continue");
        }
    }
}
