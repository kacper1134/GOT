using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages
{
    class TripHistoryPage
    {
        public TripHistoryPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        private IWebElement TripContainer => Driver.FindElement(By.ClassName("container"));

        private IWebElement DetailsButton => Driver.FindElement(By.Id("details-button"));

        private IWebElement FilterSelectList => Driver.FindElement(By.Id("filter-list"));

        private IWebElement OrderSelectList => Driver.FindElement(By.Id("sorting-list"));

        public bool TripExist()
        {
            return TripContainer != null;
        }

        public bool DetailsButtonExist()
        {
            return DetailsButton != null;
        }

        public bool FilterSelectListExist()
        {
            return FilterSelectList != null;
        }

        public bool OrderSelectListExist()
        {
            return OrderSelectList != null;
        }

        public void GoToDetails()
        {
            DetailsButton.Click();
        }

        public void SelectFilterOption(string text)
        {
            var selectElement = new SelectElement(FilterSelectList);
            selectElement.SelectByText(text);
        }

        public string GetFilterOption()
        {
            var selectElement = new SelectElement(FilterSelectList);
            return selectElement.SelectedOption.Text;
        }

        public void SelectOrderOption(string text)
        {
            var selectElement = new SelectElement(OrderSelectList);
            selectElement.SelectByText(text);
        }

        public string GetOrderOption()
        {
            var selectElement = new SelectElement(OrderSelectList);
            return selectElement.SelectedOption.Text;
        }
    }
}
