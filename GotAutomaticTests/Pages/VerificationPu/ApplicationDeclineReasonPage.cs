using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Pages
{
    class ApplicationDeclineReasonPage
    {
        public ApplicationDeclineReasonPage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        private IWebDriver Driver { get; }

        private IWebElement ReasonTextArea => Driver.FindElement(By.Name("reason"));

        private IWebElement SendButton => Driver.FindElement(By.Id("send-button"));

        private IWebElement Modal => Driver.FindElement(By.Id("modalAccept"));

        private IWebElement ModalYesButton => Driver.FindElement(By.ClassName("modalLeftButton"));

        public bool ReasonTextAreaExist()
        {
            return ReasonTextArea != null;
        }

        public bool SendButtonExist()
        {
            return SendButton != null;
        }

        public bool ModalExist()
        {
            return Modal != null && ModalYesButton != null;
        }

        public void WriteReason(string reason)
        {
            ReasonTextArea.SendKeys(reason);
        }

        public void SendButtonClick()
        {
            SendButton.Click();
        }

        public void DeclineRequest()
        {
            ModalYesButton.Click();
        }
    }
}
