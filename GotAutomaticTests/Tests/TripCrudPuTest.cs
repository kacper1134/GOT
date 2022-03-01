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
    class TripCrudPuTest
    {
        IWebDriver webDriver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44370/");
            webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void DetailsTest()
        {
            // Step 1) Przejdź do strony z wycieczkami.
            HomePage homePage = new HomePage(webDriver);
            Assert.That(homePage.CanGoToMenu(), Is.True);
            homePage.MoveToMenu();
            Assert.That(homePage.CanGoToTrip(), Is.True);
            homePage.GoToTrip();

            // Step 2) Przejdź do szczegółow pierwszej wycieczki.
            TripPage tripPage = new TripPage(webDriver);
            Assert.That(tripPage.TripExist(), Is.True);
            Assert.That(tripPage.DetailsButtonExist(), Is.True);
            tripPage.GoToDetails();

            // Step 3) Sprawdź czy trasa wycieczki nie jest pusta.
            TripDetailsPage tripDetailsPage = new TripDetailsPage(webDriver);
            Assert.That(tripDetailsPage.SegmentsContainerExist(), Is.True);
            Assert.That(tripDetailsPage.SegmentsContainerIsNotEmpty(), Is.True);

            // Step 4) Wróć do strony z wycieczkami.
            Assert.That(tripDetailsPage.ReturnButtonExist(), Is.True);
            tripDetailsPage.ReturnToTrips();

            // Step 5) Sprawdź czy jesteś na stronie z wycieczkami.
            Assert.That(tripPage.TripExist(), Is.True);
        }

        [Test]
        public void UpdateTest()
        {
            // Step 1) Przejdź do strony z wycieczkami.
            HomePage homePage = new HomePage(webDriver);
            Assert.That(homePage.CanGoToMenu(), Is.True);
            homePage.MoveToMenu();
            Assert.That(homePage.CanGoToTrip(), Is.True);
            homePage.GoToTrip();

            // Step 2) Przejdź do modyfikacji pierwszej wycieczki.
            TripPage tripPage = new TripPage(webDriver);
            Assert.That(tripPage.TripExist(), Is.True);
            Assert.That(tripPage.UpdateButtonExist(), Is.True);
            tripPage.GoToUpdate();

            // Step 3) Modyfikuj trasę.
            TripUpdatePage tripUpdatePage = new TripUpdatePage(webDriver);
            Assert.That(tripUpdatePage.RouteModifyButtonExist(), Is.True);
            tripUpdatePage.GoToModifyRoute();

            // Step 4) Wybierz pierwszą trasę.
            RouteModifyPage routeModifyPage = new RouteModifyPage(webDriver);
            Assert.That(routeModifyPage.RouteSelectListExist(), Is.True);
            Assert.That(routeModifyPage.RouteConfirmButtonExist(), Is.True);
            routeModifyPage.ModifyTripRoute();

            // Step 5) Wróć do strony z wycieczkami.
            Assert.That(tripUpdatePage.ConfirmUpdateButtonExist(), Is.True);
            tripUpdatePage.ConfirmButtonClick();
            Assert.That(tripUpdatePage.ConfirmModalButtonExist(), Is.True);
            tripUpdatePage.ModifyTrip();

            // Step 6) Sprawdź czy jesteś na stronie z wycieczkami.
            Assert.That(tripPage.TripExist(), Is.True);
        }

        [OneTimeTearDown]
        public void TearDown() => webDriver.Quit();
    }
}
