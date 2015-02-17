using System.Runtime.CompilerServices;
using Golem.PageObjects.RG.Components;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.PageObjects.RG
{
    public class BaseTopicPage : BasePageObject
    {
        public Element TopImage = new Element(By.ClassName("hero"));
        public Element MoreDropdown = new Element(By.ClassName("more"));
        public Button Follow_Button = new Button("Follow Button", By.ClassName("btn-follow-topic"));
        public Button Share_BUtton = new Button(By.ClassName("btn-share"));
        public Element MostRecent_Dropdown = new Element(By.ClassName("filter-drop"));

        public LoggedOutHeader LoggedOutHeader
        {
            get { return new LoggedOutHeader(); }
        }

        public LoggedInHeader LoggedInHeader
        {
            get { return new LoggedInHeader(); }
        }

        public FeaturedVideoListSection Videos
        {
            get { return new FeaturedVideoListSection(); }
        }

        public BaseTopicPage Follow()
        {
            Follow_Button.Click();
            return this;
        }


        public override void WaitForElements()
        {
            TopImage.Verify().Visible();
            MoreDropdown.Verify().Visible();
            Follow_Button.Verify().Present();
            Share_BUtton.Verify().Visible();
            MostRecent_Dropdown.Verify().Visible();
        }
    }
}
