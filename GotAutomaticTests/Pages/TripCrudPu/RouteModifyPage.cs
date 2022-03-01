using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages
{
    class RouteModifyPage
    {
        public RouteModifyPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        private IWebElement RouteSelectList => Driver.FindElement(By.Name("routeNumber"));

        private IWebElement RouteConfirmButton => Driver.FindElement(By.Id("submit-button"));

        public bool RouteSelectListExist()
        {
            return RouteSelectList != null;
        }

        public bool RouteConfirmButtonExist()
        {
            return RouteConfirmButton != null;
        }

        public void ModifyTripRoute()
        {
            RouteConfirmButton.Click();
        }
    }
}
