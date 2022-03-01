using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages
{
    class TripDetailsPage
    {
        public TripDetailsPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        private IWebElement SegmentsContainer => Driver.FindElement(By.ClassName("segments"));

        private IWebElement ReturnButton => Driver.FindElement(By.Id("cancel-button"));

        public bool SegmentsContainerExist()
        {
            return SegmentsContainer != null;
        }

        public bool SegmentsContainerIsNotEmpty()
        {
            return SegmentsContainer.Text != "";
        }

        public bool ReturnButtonExist()
        {
            return ReturnButton != null; 
        }

        public void ReturnToTrips()
        {
            ReturnButton.Click();
        }

    }
}
