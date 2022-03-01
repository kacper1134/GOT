using GotAutomaticTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotAutomaticTests.Tests
{
    class VerificationPuTest
    {
        IWebDriver webDriver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44370/");
            webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void PositiveVerificationTest()
        {
            // Step 1) Przejdź do strony z wnioskami.
            HomePage homePage = new HomePage(webDriver);
            Assert.That(homePage.CanGoToMenu(), Is.True);
            homePage.MoveToMenu();
            Assert.That(homePage.CanGoToVerification(), Is.True);
            homePage.GoToVerification();

            // Step 2) Wybierz pierwszy wniosek z listy.
            VerificationIndexPage verificationIndexPage = new VerificationIndexPage(webDriver);
            Assert.That(verificationIndexPage.RequestExist(), Is.True);
            verificationIndexPage.GoToFirstRequest();

            // Step 2.1) Jeżeli wniosek jest już rozpatrzony to kliknij tak w modalu.
            verificationIndexPage.ClickYesIfNeccesary();

            // Step 3) Przyjmij wniosek
            VerificationDetailsPage verificationDetailsPage = new VerificationDetailsPage(webDriver);
            Assert.That(verificationDetailsPage.AcceptButtonExist(), Is.True);
            verificationDetailsPage.AcceptButtonClick();
            Assert.That(verificationDetailsPage.ModalExist(), Is.True);
            verificationDetailsPage.AcceptRequest();

            // Step 4) Sprawdź czy wniosek został przyjęty.
            Assert.That(verificationIndexPage.IsRequestAccepted(), Is.True);
        }

        [Test]
        public void NegativeVerificationTest()
        {
            // Step 1) Przejdź do strony z wnioskami.
            HomePage homePage = new HomePage(webDriver);
            Assert.That(homePage.CanGoToMenu(), Is.True);
            homePage.MoveToMenu();
            Assert.That(homePage.CanGoToVerification(), Is.True);
            homePage.GoToVerification();

            // Step 2) Wybierz pierwszy wniosek z listy.
            VerificationIndexPage verificationIndexPage = new VerificationIndexPage(webDriver);
            Assert.That(verificationIndexPage.RequestExist(), Is.True);
            verificationIndexPage.GoToFirstRequest();

            // Step 2.1) Jeżeli wniosek jest już rozpatrzony to kliknij tak w modalu.
            verificationIndexPage.ClickYesIfNeccesary();

            // Step 3) Przejdź do uzasadnienia.
            VerificationDetailsPage verificationDetailsPage = new VerificationDetailsPage(webDriver);
            Assert.That(verificationDetailsPage.DeclineButtonExist(), Is.True);
            verificationDetailsPage.DeclineButtonClick();

            // Step 4) Wypełnij uzasadnienie.
            ApplicationDeclineReasonPage applicationDeclineReasonPage = new ApplicationDeclineReasonPage(webDriver);
            Assert.That(applicationDeclineReasonPage.ReasonTextAreaExist(), Is.True);
            applicationDeclineReasonPage.WriteReason("lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum");

            // Step 5) Odrzuć wniosek.
            Assert.That(applicationDeclineReasonPage.SendButtonExist(), Is.True);
            applicationDeclineReasonPage.SendButtonClick();
            Assert.That(applicationDeclineReasonPage.ModalExist(), Is.True);
            applicationDeclineReasonPage.DeclineRequest();

            // Step 6) Sprawdź czy wniosek został odrzucony.
            Assert.That(verificationIndexPage.IsRequestDeclined(), Is.True);
        }

        [OneTimeTearDown]
        public void TearDown() => webDriver.Quit();
    }
}

