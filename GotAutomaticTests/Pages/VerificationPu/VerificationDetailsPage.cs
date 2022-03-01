using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages
{
    class VerificationDetailsPage
    {
        public VerificationDetailsPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        private IWebElement AcceptButton => Driver.FindElement(By.Id("accept-button"));

        private IWebElement DeclineButton => Driver.FindElement(By.Id("discard-button"));

        private IWebElement Modal => Driver.FindElement(By.Id("modalAccept"));

        private IWebElement ModalYesButton => Driver.FindElement(By.ClassName("modalLeftButton"));

        public bool AcceptButtonExist()
        {
            return AcceptButton != null;
        }

        public bool DeclineButtonExist()
        {
            return DeclineButton != null;
        }

        public bool ModalExist()
        {
            return Modal != null && ModalYesButton != null;
        }

        public void AcceptButtonClick()
        {
            AcceptButton.Click();
        }
    
        public void AcceptRequest()
        {
            ModalYesButton.Click();
        }

        public void DeclineButtonClick()
        {
            DeclineButton.Click();
        }
    }
}
