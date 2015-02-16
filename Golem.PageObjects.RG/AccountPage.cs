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
    public class AccountPage : BasePageObject
    {
        public LoggedInHeader LoggedInHeader = new LoggedInHeader();

        // Page labels
        Element Member_Label = new Element("Member Label", By.XPath("//h2//*[contains(text(),'Member')]"));
        Element AccountSettings_Label = new Element("Account Settings Label", ByE.PartialText("Account Settings"));
        Element BillingShipping_Label = new Element("Billing & Shipping Label", ByE.PartialText("Billing & Shipping"));

        // Only visible if purchases were made
        Element PurchaseHistory_Label = new Element("Purchase History Label", ByE.PartialText("Purchase History"));

        // Member section
        Button UpgradeToRGPlus_Button = new Button("Upgrade to RG+ button", By.XPath("//a[contains(text(), 'Upgrade to RG+')]"));

        // Account Settings set labels
        Element AccountSettings_NickName_Label = new Element("Account Settings Nickname Label", By.CssSelector("input[id*=RGChangePassword_lblNickName]"));
        Element AccountSettings_Email_Label = new Element("Account Settings Email Label", By.CssSelector("input[*=RGChangePassword_lblUserName]"));
        Link AccountSettings_Edit_Link = new Link("Account Settings Edit Link", By.XPath("//*[@class='account-info']//a[contains(text(),'Edit')]"));

        // Account Settings form fields
        Field DisplayName_Field = new Field("Display Name Field", By.CssSelector("input[id*=RGChangePassword_NickNametextbox]"));
        Field Email_Field = new Field("Email Field", By.CssSelector("input[id*=RGChangePassword_txtEmail]"));
        Field OldPassword_Field = new Field("Old Password Field", By.CssSelector("input[id*=RGChangePassword_txtOldPassword]"));
        Field NewPassword_Field = new Field("New Password Field", By.CssSelector("input[*=RGChangePassword_Password]"));

        Button AccountSettings_Cancel_Button = new Button("Cancel Button", By.XPath("//*[@class='edit-account']//a[contains(text(),'Cancel')]"));
        Button AccountSettings_Save_Button = new Button("Save Button", By.CssSelector("input[id*=RGChangePassword_btnOk]"));
        
        
        Button Delete_Button = new Button("Delete Button", ByE.PartialText("Delete"));

        // Purchase History section

        #region "Billing and Shipping Elements"
        //
        // Billing & Shipping section
        //
        
        // Billing
        Element Billing_Card_Info_Label = new Element("Preferred Payment card info label", By.XPath("//*[@class='select payment']/span"));
        Link Billing_Edit_Link = new Link("Edit Preferred Payment Link", By.XPath("//*[@class='select payment']//a[contains(text(),'Edit')]"));
        Field Billing_Name_Field = new Field("Billing name field", By.Id("txtCreditFormNameOnCard"));
        Field Billing_Card_number = new Field("Billing card number field", By.Id("txtCreditFormCardNumber"));
        Dropdown Billing_Expiration_Month_Dropdown = new Dropdown("Billing Expiration Month Dropdown", By.Id("ddlExpirationMonth"));
        Dropdown Billing_Expiration_Year_Dropdown = new Dropdown("Billing Expiration Year Dropdown", By.Id("ddlExpirationYear"));
        Field Billing_CCV_Field = new Field("Billing CCV field", By.Id("txtCreditFormCardCcv"));
        Field Billing_Address_Field = new Field("Billing address field", By.Id("txtCreditFormCardAddress"));
        Button Billing_Delete_Button = new Button("Billing Edit Delete button", By.XPath("//*[@class='edit-card']//a[contains(text(),'Delete')]"));
        Button Billing_Cancel_Button = new Button("Billing Edit Cancel button", By.XPath("//*[@class='edit-card']//a[contains(text(),'Cancel')]"));
        Button Billing_Save_Button = new Button("Billing Edit Save button", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCreditForm_btnSave"));
        
        // Shipping
        Link ShippingAddressDropdown_Link = new Link("Shipping Address Dropdown link", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_lbActiveAddress"));
        
        // Link is visible when the user clicks on  the shipping address dropdown
        Link Shipping_Add_Address_Link = new Link("Shipping add address link", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_lbAddNew"));

        // Add address form fields
        Field Shipping_Address1_field = new Field("Shipping Address 1 field", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_txtAddressLine1"));
        Field Shipping_Address2_field = new Field("Shipping Address 2 field", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_txtAddressLine2"));
        Field Shipping_Zip_field = new Field("Shipping zip field", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_txtAddressZip"));
        Dropdown Shipping_Country_Dropdown = new Dropdown("Shipping Country Dropdown", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_ucCountrySelector_uniSelectorCountry_drpSingleSelect"));
        Dropdown Shipping_State_Dropdown = new Dropdown("Shipping State dropdown", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_ucCountrySelector_uniSelectorState_drpSingleSelect"));
        Field Shipping_City_field = new Field("Shipping City field", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_txtAddressCity"));
        Button Shipping_Save_button = new Button("Shipping Save Button", By.Id("p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_btnSubmitAddressEdit"));
        Button Shipping_Cancel_button = new Button("Shipping Cancel Button", By.XPath("//*[@id='p_lt_ctl15_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_pnlEditAddress']//a[contains(text(),'Cancel')]"));
        
        #endregion // shipping and billing elements


        public BecomeMemberPage Upgrade_To_RG_Plus()
        {
            UpgradeToRGPlus_Button.WaitUntil().Visible().Click();

            return new BecomeMemberPage();
        }

        /// <summary>
        ///     Enters the non-null parameters into the form and 'Saves'
        /// </summary>
        /// <param name="display_name">Can be null</param>
        /// <param name="email">Can be null</param>
        /// <param name="old_password">Can be null</param>
        /// <param name="new_password">Can be null</param>
        /// <returns>AccountPage</returns>
        public AccountPage UpdateAccountSettings(string display_name, string email, string old_password, string new_password)
        {
            AccountSettings_Edit_Link.Verify().Visible().Click();

            if (display_name != null) DisplayName_Field.Text = display_name;
            if (email != null) Email_Field.Text = email;
            if ((old_password != null) && (new_password != null))
            {
                OldPassword_Field.Text = old_password;
                NewPassword_Field.Text = new_password;
            }
            AccountSettings_Save_Button.Click();

            return new AccountPage();
        }

        public AccountPage VerifyAccountSettingsInfo(string display_name, string email)
        {
            if (display_name != null) AccountSettings_NickName_Label.Verify().Visible().Verify().Text(display_name);
            if (email != null) AccountSettings_Email_Label.Verify().Visible().Verify().Text(email);

            return this;
        }

        #region "Preferred Payment"

        private void EnterPreferredPaymentDetails(string name, string card_number, string expiration_month, string expiration_year, string ccv, string billing_address)
        {
            if (name != null) Billing_Name_Field.WaitUntil().Visible().Text = name;
            if (card_number != null) Billing_Card_number.WaitUntil().Visible().Text = card_number;
            if (expiration_month != null) Billing_Expiration_Month_Dropdown.WaitUntil().Visible().SelectOption(expiration_month);
            if (expiration_year != null) Billing_Expiration_Year_Dropdown.WaitUntil().Visible().SelectOption(expiration_year);
            if (ccv != null) Billing_CCV_Field.WaitUntil().Visible().Text = ccv;
            if (billing_address != null) Billing_Address_Field.WaitUntil().Visible().Text = billing_address;
        }

        /// <summary>
        /// Enter the preferred billing details. Note: Params can be null
        /// </summary>
        /// <param name="name"></param>
        /// <param name="card_number"></param>
        /// <param name="expiration"></param>
        /// <param name="year"></param>
        /// <param name="ccv"></param>
        /// <param name="billing_address"></param>
        /// <returns></returns>
        public AccountPage EditPreferredPayment(string name, string card_number, string expiration_month, string expiration_year, string ccv, string billing_address)
        {
            VerifyPaymentAccordian_NotDisplayed();
            Billing_Edit_Link.WaitUntil().Visible().Click();
            VerifyPaymentAccordian_Displayed();
            EnterPreferredPaymentDetails(name, card_number, expiration_month, expiration_year, ccv, billing_address);
            Billing_Save_Button.WaitUntil().Visible().Click();

            return new AccountPage();
        }

        public AccountPage DeletePreferredPayment()
        {
            VerifyPaymentAccordian_NotDisplayed();
            Billing_Edit_Link.WaitUntil().Visible().Click();
            VerifyPaymentAccordian_Displayed();
            Billing_Delete_Button.WaitUntil().Visible().Click();

            return new AccountPage();
        }

        public AccountPage VerifyPreferredPayment_DropDown_Text(string label_text)
        {
            Billing_Card_Info_Label.WaitUntil().Visible().Verify().Text(label_text);

            return this;
        }

        public void VerifyPreferredPayment(string name, string card_number_last4, string expiration_month, string expiration_year, string billing_address)
        {
            // Enter the billing details form
            Billing_Edit_Link.WaitUntil().Visible().Click();

            VerifyPaymentAccordian_Displayed();

            // Verify all the fields
            Billing_Name_Field.Verify().Text(name);
            Billing_Card_number.Verify().Text(card_number_last4);

            // TODO: Can't verify these dropdowns, there is no way to determine which one is selected

            Billing_Address_Field.Verify().Text(billing_address);
        }

        public AccountPage VerifyPaymentAccordian_Displayed()
        {
            Billing_Name_Field.WaitUntil().Visible();
            Billing_Card_number.WaitUntil().Visible();
            Billing_Expiration_Month_Dropdown.WaitUntil().Visible();
            Billing_Expiration_Year_Dropdown.WaitUntil().Visible();
            Billing_Address_Field.WaitUntil().Visible();
            Billing_Cancel_Button.WaitUntil().Visible();
            Billing_Save_Button.WaitUntil().Visible();

            return this;
        }

        public AccountPage VerifyPaymentAccordian_NotDisplayed()
        {
            Billing_Name_Field.WaitUntil().Not().Visible();
            Billing_Card_number.WaitUntil().Not().Visible();
            Billing_Expiration_Month_Dropdown.WaitUntil().Not().Visible();
            Billing_Expiration_Year_Dropdown.WaitUntil().Not().Visible();
            Billing_Address_Field.WaitUntil().Not().Visible();
            Billing_Cancel_Button.WaitUntil().Not().Visible();
            Billing_Save_Button.WaitUntil().Not().Visible();

            return this;
        }

        #endregion // Preferred Payment

        #region "Shipping apis"

        /// <summary>
        ///  Enter the shipping information into the form. Parameters can be null
        /// </summary>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="country"></param>
        private void EnterShippingDetails(string address1, string address2, string city, string state, string zip, string country)
        {
            if (address1 != null) Shipping_Address1_field.WaitUntil().Visible().Text = address1;
            if (address2 != null) Shipping_Address2_field.WaitUntil().Visible().Text = address2;
            if (zip != null) Shipping_Zip_field.WaitUntil().Visible().Text = zip;
            if (country != null) Shipping_Country_Dropdown.WaitUntil().Visible().SelectOptionByPartialText(country);
            if (state != null) Shipping_State_Dropdown.WaitUntil().Visible().SelectOptionByPartialText(state);
            if (city != null) Shipping_City_field.WaitUntil().Visible().Text = city;
        }

        /// <summary>
        /// Add the shipping information to the account. Parameters can be null
        /// </summary>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public AccountPage AddShippingAddress(string address1, string address2, string city, string state, string zip, string country)
        {
            VerifyShippingAccordian_NotDisplayed();
            ShippingAddressDropdown_Link.WaitUntil().Visible().Click();
            Shipping_Add_Address_Link.WaitUntil().Visible().Click();
            VerifyShippingAccordian_Displayed();
            EnterShippingDetails(address1, address2, city, state, zip, country);
            Shipping_Save_button.WaitUntil().Visible().Click();

            return new AccountPage();
        }

        public AccountPage DeleteShippingAddress(string address1)
        {
            throw new NotImplementedException();
        }

        public AccountPage VerifyCurrentSelectedShippingAddress(string address1)
        {
            ShippingAddressDropdown_Link.WaitUntil().Visible().Verify().Text(address1);
            return this;
        }

        /// <summary>
        ///  Edit the shipping address. Parameters can be null
        /// </summary>
        /// <param name="address1_to_edit"></param>
        /// <param name="new_address1"></param>
        /// <param name="new_address2"></param>
        /// <param name="new_city"></param>
        /// <param name="new_state"></param>
        /// <param name="new_zip"></param>
        /// <param name="new_country"></param>
        /// <returns></returns>
        public AccountPage EditShippingAddress(string address1_to_edit, string new_address1, string new_address2, string new_city, string new_state, string new_zip, string new_country)
        {
            VerifyShippingAccordian_NotDisplayed();
            ShippingAddressDropdown_Link.WaitUntil().Visible().Click();
            new Element("Shipping address option", By.XPath(String.Format("//*[@class='select-drop']//a[contains(text(),'Edit') and ../a[contains(text(),'{0}')]]", address1_to_edit))).WaitUntil().Visible().Click();
            VerifyShippingAccordian_Displayed();
            EnterShippingDetails(new_address1, new_address2, new_city, new_state, new_zip, new_country);
            Shipping_Save_button.WaitUntil().Visible().Click();
            VerifyShippingAccordian_NotDisplayed();

            return new AccountPage();
        }

        public AccountPage VerifyShippingAccordian_Displayed()
        {
            Shipping_Address1_field.WaitUntil().Visible();
            Shipping_Address2_field.WaitUntil().Visible();
            Shipping_Zip_field.WaitUntil().Visible();
            Shipping_Country_Dropdown.WaitUntil().Visible();
            Shipping_City_field.WaitUntil().Visible();
            Shipping_Cancel_button.WaitUntil().Visible();
            Shipping_Save_button.WaitUntil().Visible();

            return this;
        }

        public AccountPage VerifyShippingAccordian_NotDisplayed()
        {
            Shipping_Address1_field.WaitUntil().Not().Visible();
            Shipping_Address2_field.WaitUntil().Not().Visible();
            Shipping_Zip_field.WaitUntil().Not().Visible();
            Shipping_Country_Dropdown.WaitUntil().Not().Visible();
            Shipping_City_field.WaitUntil().Not().Visible();
            Shipping_Cancel_button.WaitUntil().Not().Visible();
            Shipping_Save_button.WaitUntil().Not().Visible();

            return this;
        }

        #endregion //shipping apis

        public bool IsRGPlusMember()
        {
            try
            {
                return UpgradeToRGPlus_Button.Displayed && UpgradeToRGPlus_Button.Enabled;
            }
            catch
            {
                return false;
            }
        }

        public override void WaitForElements()
        {
            Member_Label.Verify().Visible();
            AccountSettings_Label.Verify().Visible();
            BillingShipping_Label.Verify().Visible();
        }

        
    }
}
