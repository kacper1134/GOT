using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages
{
    public class HomePage
    {
        public HomePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        private Actions Action => new Actions(Driver);

        public IWebElement lnkAccount => Driver.FindElement(By.LinkText("Konto"));

        public IWebElement lnkVerification => Driver.FindElement(By.LinkText("Moje wnioski"));

        public IWebElement lnkTrip => Driver.FindElement(By.LinkText("Moje wycieczki"));

        public IWebElement lnkHistory => Driver.FindElement(By.LinkText("Historia wycieczek"));

        public IWebElement lnkMap => Driver.FindElement(By.LinkText("Mapa"));

        public bool CanGoToMenu()
        {
            return lnkAccount != null;
        }

        public bool CanGoToVerification()
        {
            return lnkVerification != null;
        }

        public bool CanGoToTrip()
        {
            return lnkTrip != null;
        }

        public bool CanGoToHistory()
        {
            return lnkHistory != null;
        }

        public bool CanGoToMap()
        {
            return lnkMap != null;
        }

        public void MoveToMenu()
        {
            Action.MoveToElement(lnkAccount).Perform();
        }

        public void GoToVerification()
        {
            Action.MoveToElement(lnkVerification).Perform();
            lnkVerification.Click();
        }

        public void GoToTrip()
        {
            Action.MoveToElement(lnkTrip).Perform();
            lnkTrip.Click();
        }

        public void GoToHistory()
        {
            Action.MoveToElement(lnkHistory).Perform();
            lnkHistory.Click();
        }
    
        public void GoToMap()
        {
            lnkMap.Click();
        }
    }
}
