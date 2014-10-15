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
    public class JoinPage : BasePageObject
    {
        public enum SEX {Male, Female};
        public enum AGE_RANGE {Range_18_29, Range_30_50, Range_60_90};
        public enum SCORE {Scratch, Seventies, Eighties, Nineties, Hundreds};

        // Starting point Modal
        Button Subscribe_Button = new Button("Subscribe button", ByE.PartialText("Subscribe"));

        // Questions Modal
        Link Question_1_Sex = new Link("Male/Female Question Link", By.Id("question1"));
        Link Question_2_Age = new Link("Age Range Question Link", By.Id("question2"));
        Link Question_3_Score = new Link("Average Score Question Link", By.Id("question3"));
        Button Question_Submit_Btn = new Button("Questions submit button", ByE.PartialAttribute("button", "class", "btn-step3"));

        // Username/Password Modal
        Field Email_Field = new Field("Subscribe > Email field", By.Id("p_lt_ctl05_RGJoinSurvey_txtEmail"));
        Field Password_Field = new Field("Subscribe > Password field", By.Id("p_lt_ctl05_RGJoinSurvey_passStrength"));
        Button StartLearning_Button = new Button("Subscribe > Start Learning Button", By.Id("p_lt_ctl05_RGJoinSurvey_btnOk"));

        private void EnterSubscriptionQuestions(SEX sex, AGE_RANGE age_range, SCORE score)
        {
            Subscribe_Button.WaitUntil().Visible().Click();

            // Question 1
            Question_1_Sex.WaitUntil().Visible().Click();
            new Element(sex.ToString() + " option", By.LinkText(sex.ToString())).WaitUntil().Visible().Click();

            // Question 2
            string age_range_str = "";
            switch (age_range)
            {
                case AGE_RANGE.Range_18_29: age_range_str = "between 18 to 29"; break;
                case AGE_RANGE.Range_30_50: age_range_str = "between 30 to 50"; break;
                case AGE_RANGE.Range_60_90: age_range_str = "between 60 to 90"; break;
                default: throw new System.Exception("Invalid age range passed in");
            }

            Common.Delay(1000);
            Question_2_Age.WaitUntil().Visible().Click();
            new Element(age_range_str + " option", By.PartialLinkText(age_range_str)).WaitUntil().Visible().Click();

            // Question 3
            string score_str = "";
            switch (score)
            {
                case SCORE.Scratch: score_str = "Scratch"; break;
                case SCORE.Seventies: score_str = "70s"; break;
                case SCORE.Eighties: score_str = "80s"; break;
                case SCORE.Nineties: score_str = "90s"; break;
                case SCORE.Hundreds: score_str = "100+"; break;
                default: throw new System.Exception("Invalid score passed in");
            }

            Common.Delay(1000);
            Question_3_Score.WaitUntil().Visible().Click();
            new Element(score_str + " option", By.LinkText(score_str)).WaitUntil().Visible().Click();

            Question_Submit_Btn.WaitUntil().Visible().Click();
            Common.Delay(1000);
        }

        private void EnterSubscription_U_P(string email, string password)
        {
            Email_Field.WaitUntil().Visible().Text = email;
            Password_Field.WaitUntil().Visible().Text = password;
            StartLearning_Button.WaitUntil().Visible().Click();
            Common.Delay(1000);
        }

        public HomePage Subscribe(SEX sex, AGE_RANGE age_range, SCORE score, string email, string password)
        {
            TestBase.LogEvent(string.Format("Subscribing with values: {0}, {1}, {2}, {3}, {4}", 
                                            sex.ToString(), age_range.ToString(), score.ToString(), email, password));

            EnterSubscriptionQuestions(sex, age_range, score);
            EnterSubscription_U_P(email, password);

            return new HomePage(true);
        }

        public override void WaitForElements()
        {
            
        }
    }
}


