using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages
{
    class VerificationIndexPage
    {
        public VerificationIndexPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        private IWebElement FirstVerificationRequestButton => Driver.FindElement(By.ClassName("application-button-container"));

        private IWebElement Modal => Driver.FindElement(By.Id("modalVerification"));

        private IWebElement ModalYesButton => Driver.FindElement(By.Id("ConfirmButton"));

        public bool RequestExist()
        {
            return FirstVerificationRequestButton != null;
        }

        public void GoToFirstRequest()
        {
            FirstVerificationRequestButton.Click();
        }
    
        public void ClickYesIfNeccesary()
        {
            if(Modal != null && Modal.GetAttribute("display") != "none")
            {
                if(ModalYesButton != null)
                {
                    ModalYesButton.Click();
                }
            }
        }
    
        public bool IsRequestAccepted()
        {
            return FirstVerificationRequestButton.GetCssValue("border-color") == "rgb(24, 140, 72)";
        }

        public bool IsRequestDeclined()
        {
            return FirstVerificationRequestButton.GetCssValue("border-color") == "rgb(167, 44, 51)";
        }
    }
}
