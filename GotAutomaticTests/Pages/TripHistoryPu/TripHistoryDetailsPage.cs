using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages
{
    class TripHistoryDetailsPage
    {
        public TripHistoryDetailsPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        private IWebElement ShowPhotosButton => Driver.FindElement(By.Id("show-photos"));

        private IWebElement ClosePhotosButton => Driver.FindElement(By.ClassName("close"));

        private IWebElement ReturnButton => Driver.FindElement(By.ClassName("return-button"));

        public bool ShowPhotosButtonExist()
        {
            return ShowPhotosButton != null;
        }

        public bool ClosePhotosButtonExist()
        {
            return ClosePhotosButton != null;
        }

        public bool ReturnButtonExist()
        {
            return ReturnButton != null;
        }

        public void ShowPhotos()
        {
            ShowPhotosButton.Click();
        }

        public void ClosePhotos()
        {
            ClosePhotosButton.Click();
        }

        public void Return()
        {
            ReturnButton.Click();
        }
    }
}
