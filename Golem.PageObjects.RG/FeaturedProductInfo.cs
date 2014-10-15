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
    public class FeaturedProductInfo : BasePageObject
    {
        Element ExclusiveOffer_Label = new Element("Exclusive offer text", By.XPath("//*[@class='product-info']//*[contains(text(),'EXCLUSIVE OFFER')]"));
        Element BuyNow_Button = new Element("Buy Now Button", By.XPath("//*[@class='product-info']//*[contains(text(),'BUY NOW')]"));
        Element ProductDetails_Button = new Element("Product Details Button", By.XPath("//*[@class='product-info']//*[contains(text(),'PRODUCT DETAILS')]"));
        Element ProductCost_Label = new Element("Product Cost Text", By.XPath("//*[@class='product-info']//h2"));

        public override void WaitForElements()
        {
            ExclusiveOffer_Label.Verify().Visible();
            BuyNow_Button.Verify().Visible();
            ProductDetails_Button.Verify().Visible();
            ProductCost_Label.Verify().Visible();
        }
    }
}
