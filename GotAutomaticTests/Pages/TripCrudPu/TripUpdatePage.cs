using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages
{
    class TripUpdatePage
    {
        public TripUpdatePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        private IWebElement RouteModifyButton => Driver.FindElement(By.ClassName("route-button"));

        private IWebElement ConfirmUpdateButton => Driver.FindElement(By.Id("create-trip-button"));

        private IWebElement ConfirmModalButton => Driver.FindElement(By.Id("ConfirmButton"));

        public bool RouteModifyButtonExist()
        {
            return RouteModifyButton != null;
        }

        public bool ConfirmUpdateButtonExist()
        {
            return ConfirmUpdateButton != null;
        }

        public bool ConfirmModalButtonExist()
        {
            return ConfirmModalButton != null;
        }

        public void GoToModifyRoute()
        {
            RouteModifyButton.Click();
        }

        public void ConfirmButtonClick()
        {
            ConfirmUpdateButton.Click();
        }

        public void ModifyTrip()
        {
            ConfirmModalButton.Click();
        }
    }
}
