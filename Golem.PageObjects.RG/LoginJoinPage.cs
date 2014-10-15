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
    public class LoginJoinPage : BasePageObject
    {
        Element LoginEmail_Field = new Element("Login Email Field", By.Id("p_lt_ctl00_RGLogonMiniFormBasic_loginElem_UserName"));
        Element LoginPassword_Field = new Element("Login Password Field", By.Id("p_lt_ctl00_RGLogonMiniFormBasic_loginElem_Password"));
        Button LoginContinue_Button = new Button("Login Continue Button", By.Id("p_lt_ctl00_RGLogonMiniFormBasic_loginElem_btnLogon"));

        Element CreateAccountEmail_Field = new Element("Create Account Email Field", By.Id("p_lt_ctl01_RGRegistrationMiniForm_txtEmail"));
        Element CreateAccountPassword_Field = new Element("Create Account Passwoord Field", By.Id("p_lt_ctl01_RGRegistrationMiniForm_passStrength"));
        Button CreateAccount_Button = new Button("Create Account Button", By.Id("p_lt_ctl01_RGRegistrationMiniForm_btnOk"));

        public HomePage CreateAccount(string email, string password)
        {
            CreateAccountEmail_Field.Text = email;
            CreateAccountPassword_Field.Text = password;
            CreateAccount_Button.Click();
            
            return new HomePage(true);
        }

        public HomePage Login(string email, string password)
        {
            LoginEmail_Field.Text = email;
            LoginPassword_Field.Text = password;
            LoginContinue_Button.Click();

            return new HomePage(true);
        }

        private void VerifyPageLabels(string[] labels)
        {
            foreach(string label in labels)
            {
                try
                {
                    WebDriverTestBase.driver.FindElementWithText(label);
                }
                catch (NoSuchElementException)
                {
                    WebDriverTestBase.AddVerificationError(string.Format("Failed to find text '{0}' on {1}", label, this.className));
                }
            }
        }

        public override void WaitForElements()
        {
            LoginEmail_Field.WaitUntil().Visible();
            LoginPassword_Field.WaitUntil().Visible();
            LoginContinue_Button.WaitUntil().Visible();
            CreateAccountEmail_Field.WaitUntil().Visible();
            CreateAccountPassword_Field.WaitUntil().Visible();
            CreateAccount_Button.WaitUntil().Visible();

            string[] pageText = {
                                    "Join the Round."
                                    ,"Welcome Back"
                                    ,"I Don't Have an Account"
                                    ,"Forgot your Password?"
                                    ,"Sign in to use previously saved account details and track your purchases and favorite videos."
                                    ,"Welcome to the most progressive golf school in the world. Join to access the full experience."
                                };

            VerifyPageLabels(pageText);
        }
    }
}
