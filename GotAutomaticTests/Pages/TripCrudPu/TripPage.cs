using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages
{
    class TripPage
    {
        public TripPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        private IWebElement TripContainer => Driver.FindElement(By.ClassName("tripContainer"));

        private IWebElement DetailsButton => Driver.FindElement(By.Id("DetailsTripButton"));

        private IWebElement UpdateButton => Driver.FindElement(By.Id("UpdateTripButton"));

        public bool TripExist()
        {
            return TripContainer != null;
        }

        public bool DetailsButtonExist()
        {
            return DetailsButton != null;
        }

        public bool UpdateButtonExist()
        {
            return UpdateButton != null;
        }

        public void GoToDetails()
        {
            DetailsButton.Click();
        }

        public void GoToUpdate()
        {
            UpdateButton.Click();
        }
    }
}
