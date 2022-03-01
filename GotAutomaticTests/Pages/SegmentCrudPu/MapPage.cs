using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages.SegmentCrudPu
{
    class MapPage
    {
        public MapPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }
        private Actions Action => new Actions(Driver);

        private IWebElement Map => Driver.FindElement(By.Id("map"));

        private IWebElement SegmentDetails => Driver.FindElement(By.Id("modify-route-content"));

        private IWebElement CloseButton => Driver.FindElement(By.CssSelector("#modify-route-content > div.modal-header > button > span"));

        private IWebElement ModifyButton => Driver.FindElement(By.CssSelector("#button-submit"));

        private IWebElement CloseModalButton => Driver.FindElement(By.CssSelector("#message > div > div > div.modal-header > button > span"));

        public bool MapExist()
        {
            return Map != null;
        }

        public bool SegmentDetailsExist()
        {
            return SegmentDetails != null;
        }

        public bool CloseButtonExist()
        {
            return CloseButton != null;
        }

        public bool ModifyButtonExist()
        {
            return ModifyButton != null;
        }

        public bool CloseModalButtonExist()
        {
            return CloseModalButton != null;
        }

        public void ClickOnPoint()
        {
            Action.MoveToElement(Map).Perform();
            Action.MoveByOffset(-2, -2).Perform();
            Action.Click().Perform();
        }

        public void CloseDetails()
        {
            CloseButton.Click();
        }
    
        public void ModifySegment()
        {
            ModifyButton.Click();
        }
    
        public void CloseModal()
        {
            CloseModalButton.Click();
        }
    }
}
