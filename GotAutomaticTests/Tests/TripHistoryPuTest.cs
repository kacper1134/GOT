using GotAutomaticTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GotAutomaticTests.Tests
{
    class TripHistoryPuTest
    {
        IWebDriver webDriver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44370/");
            webDriver.Manage().Window.Maximize();
        }

        [Test]
        public void WatchImagesTest()
        {
            // Step 1) Przejdź do strony z historią wycieczek.
            HomePage homePage = new HomePage(webDriver);
            Assert.That(homePage.CanGoToMenu(), Is.True);
            homePage.MoveToMenu();
            Assert.That(homePage.CanGoToHistory(), Is.True);
            homePage.GoToHistory();

            // Step 2) Przejdź do szczegółow pierwszej wycieczki.
            TripHistoryPage tripHistoryPage = new TripHistoryPage(webDriver);
            Assert.That(tripHistoryPage.TripExist(), Is.True);
            Assert.That(tripHistoryPage.DetailsButtonExist(), Is.True);
            tripHistoryPage.GoToDetails();

            // Step 3) Zobacz zdjęcia wycieczki.
            TripHistoryDetailsPage tripHistoryDetailsPage = new TripHistoryDetailsPage(webDriver);
            Assert.That(tripHistoryDetailsPage.ShowPhotosButtonExist(), Is.True);
            tripHistoryDetailsPage.ShowPhotos();

            // Step 4) Zamknij zdjęcia.
            Thread.Sleep(500);
            Assert.That(tripHistoryDetailsPage.ClosePhotosButtonExist(), Is.True);
            tripHistoryDetailsPage.ClosePhotos();

            // Step 5) Wróć do strony z historią wycieczek.
            Assert.That(tripHistoryDetailsPage.ReturnButtonExist(), Is.True);
            tripHistoryDetailsPage.Return();

            // Step 6) Sprawdź czy jesteś na stronie z historią wycieczek.
            Assert.That(tripHistoryPage.TripExist(), Is.True);
        }
    
        [Test]
        public void OrderFilterTest()
        {
            // Step 1) Przejdź do strony z historią wycieczek.
            HomePage homePage = new HomePage(webDriver);
            Assert.That(homePage.CanGoToMenu(), Is.True);
            homePage.MoveToMenu();
            Assert.That(homePage.CanGoToHistory(), Is.True);
            homePage.GoToHistory();

            // Step 2) Filtruj zweryfikowane wycieczki.
            TripHistoryPage tripHistoryPage = new TripHistoryPage(webDriver);
            Assert.That(tripHistoryPage.TripExist(), Is.True);
            Assert.That(tripHistoryPage.FilterSelectListExist(), Is.True);
            var filterOption = "Zweryfikowane";
            tripHistoryPage.SelectFilterOption(filterOption);
            Assert.That(filterOption == tripHistoryPage.GetFilterOption(), Is.True);

            // Step 3) Sortuj od najstarszych wycieczek.
            Assert.That(tripHistoryPage.OrderSelectListExist(), Is.True);
            var orderOption = "Od najstarszych";
            tripHistoryPage.SelectOrderOption(orderOption);
            Assert.That(orderOption == tripHistoryPage.GetOrderOption());

        }

        [OneTimeTearDown]
        public void TearDown() => webDriver.Quit();
    }
}
