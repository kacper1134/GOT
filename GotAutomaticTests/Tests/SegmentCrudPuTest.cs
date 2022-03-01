using GotAutomaticTests.Pages;
using GotAutomaticTests.Pages.SegmentCrudPu;
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
    class SegmentCrudPuTest
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
            // Step 1) Przejdź do strony z mapą.
            HomePage homePage = new HomePage(webDriver);
            Assert.That(homePage.CanGoToMap(), Is.True);
            homePage.GoToMap();

            // Step 2) Klknij na odcinek.
            MapPage mapPage = new MapPage(webDriver);
            Assert.That(mapPage.MapExist(), Is.True);
            mapPage.ClickOnPoint();

            // Step 3) Sprawdź czy szczegóły istnieją.
            Assert.That(mapPage.SegmentDetailsExist(), Is.True);

            // Step 4) Wyłącz szczegóły.
            Thread.Sleep(500);
            Assert.That(mapPage.CloseButtonExist(), Is.True);
            mapPage.CloseDetails();

            // Step 5) Upewnij się, że mapa istnieje.
            Assert.That(mapPage.MapExist(), Is.True);
        }

        [Test]
        public void ModifyTest()
        {
            // Step 1) Przejdź do strony z mapą.
            HomePage homePage = new HomePage(webDriver);
            Assert.That(homePage.CanGoToMap(), Is.True);
            homePage.GoToMap();

            // Step 2) Kliknij na odcinek.
            MapPage mapPage = new MapPage(webDriver);
            Assert.That(mapPage.MapExist(), Is.True);
            mapPage.ClickOnPoint();

            // Step 3) Sprawdź czy szczegóły istnieją.
            Assert.That(mapPage.SegmentDetailsExist(), Is.True);

            // Step 4) Kliknij przycisk modyfikuj odcinek.
            Assert.That(mapPage.ModifyButtonExist(), Is.True);
            mapPage.ModifySegment();

            // Step 5) Wyłącz modala.
            Assert.That(mapPage.CloseModalButtonExist(), Is.True);
            mapPage.CloseModal();

            // Step 6) Upewnij się, że mapa istnieje.
            Assert.That(mapPage.MapExist(), Is.True);
        }

        [OneTimeTearDown]
        public void TearDown() => webDriver.Quit();
    }
}
