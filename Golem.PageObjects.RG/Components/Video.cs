using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProtoTest.Golem.WebDriver;

namespace Golem.PageObjects.RG.Components
{
    public class Video : BasePageObject
    {
        private Element Container;
        private Element name = new Element(By.ClassName("name"));
        private Element title = new Element(By.ClassName("title"));
        private Element image = new Element(By.ClassName("img-container"));
        private Element play = new Element(By.ClassName("play"));

        public Video(Element container)
        {
            this.Container = container;
        }

        public override void WaitForElements()
        {
            Container.FindElement(name).Verify().Visible();
            Container.FindElement(title).Verify().Visible();
            Container.FindElement(image).Verify().Visible();
            Container.FindElement(play).Verify().Visible();
        }
    }
}
