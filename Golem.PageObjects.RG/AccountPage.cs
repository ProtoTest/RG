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
        Button UpgradeToRGPlus_Button = new Button("Upgrade to RG+ button", By.PartialLinkText("Upgrade to RG+"));

        // Account Settings set labels
        Element AccountSettings_NickName_Label = new Element("Account Settings Nickname Label", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl02_RGChangePassword_lblNickName"));
        Element AccountSettings_Email_Label = new Element("Account Settings Email Label", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl02_RGChangePassword_lblUserName"));
        Link AccountSettings_Edit_Link = new Link("Account Settings Edit Link", By.XPath("//*[@class='account-info']//a[contains(text(),'Edit')]"));

        // Account Settings form fields
        Field DisplayName_Field = new Field("Display Name Field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl02_RGChangePassword_NickNametextbox"));
        Field Email_Field = new Field("Email Field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl02_RGChangePassword_txtEmail"));
        Field OldPassword_Field = new Field("Old Password Field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl02_RGChangePassword_txtOldPassword"));
        Field NewPassword_Field = new Field("New Password Field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl02_RGChangePassword_Password"));

        Button AccountSettings_Cancel_Button = new Button("Cancel Button", By.XPath("//*[@class='edit-account']//a[contains(text(),'Cancel')]"));
        Button AccountSettings_Save_Button = new Button("Save Button", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl02_RGChangePassword_btnOk"));
        
        
        Button Delete_Button = new Button("Delete Button", ByE.PartialText("Delete"));

        // Purchase History section

        //
        // Billing & Shipping section
        //
        Link ShippingAddressDropdown_Link = new Link("Shipping Address Dropdown link", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_lbActiveAddress"));
        
        // Link is visible when the user clicks on  the shipping address dropdown
        Link Shipping_Add_Address_Link = new Link("Shipping add address link", ByE.PartialText("Add New Address"));

        // Add address form fields
        Field Shipping_Address1_field = new Field("Shipping Address 1 field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_txtAddressLine1"));
        Field Shipping_Address2_field = new Field("Shipping Address 2 field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_txtAddressLine2"));
        Field Shipping_Zip_field = new Field("Shipping zip field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_txtAddressZip"));
        Dropdown Shipping_Country_Dropdown = new Dropdown("Shipping Country Dropdown", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_ucCountrySelector_uniSelectorCountry_drpSingleSelect"));
        Dropdown Shipping_State_Dropdown = new Dropdown("Shipping State dropdown", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_ucCountrySelector_uniSelectorState_drpSingleSelect"));
        Field Shipping_City_field = new Field("Shipping City field", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_txtAddressCity"));
        Button Shipping_Save_button = new Button("Shipping Save Button", By.Id("p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_btnSubmitAddressEdit"));
        Button Shipping_Cancel_button = new Button("Shipping Cancel Button", By.XPath("//*[@id='p_lt_ctl14_pageplaceholder_p_lt_ctl02_pageplaceholder_p_lt_ctl04_RGCustomerAddress_pnlEditAddress']//a[contains(text(),'Cancel')]"));

        public void Upgrade_To_RG_Plus()
        {
            throw new NotImplementedException();
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
            ShippingAddressDropdown_Link.WaitUntil().Visible().Click();
            Shipping_Add_Address_Link.WaitUntil().Visible().Click();

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
            new Element("Shipping address option", By.XPath(String.Format("//*[@class='select-drop']//a[contains(text(),'Edit') and ../a[contains(text(),'{0}')]]", address1_to_edit))).WaitUntil().Visible().Click();
            EnterShippingDetails(new_address1, new_address2, new_city, new_state, new_zip, new_country);
            Shipping_Save_button.WaitUntil().Visible().Click();

            return new AccountPage();
        }

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
