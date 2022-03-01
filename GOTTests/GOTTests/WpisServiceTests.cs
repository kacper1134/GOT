using GOT.Data;
using GOT.Data.Services;
using GOT.Exceptions;
using GOT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GOTTests
{
    public class WpisServiceTests
    {

        private readonly WpisService _wpisService;
        private readonly Mock<MyDbContext> _dbContextMock = new Mock<MyDbContext>(new DbContextOptionsBuilder<MyDbContext>().Options);

        public WpisServiceTests()
        {
            _wpisService = new WpisService(_dbContextMock.Object);
        }


        [Fact]
        public async Task GetAll_ShouldReturnAllEntries()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = GetEntriesSampleData();

            //Act
            var actualResult = (await _wpisService.GetAll()).ToList();

            //Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetNumberOfPages_ShouldReturnOnePage()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = 1;

            //Act
            var actualResult = _wpisService.GetNumberOfPages(100);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetNumberOfPages_ShouldReturnThreePages()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = 3;

            //Act
            var actualResult = _wpisService.GetNumberOfPages(3);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetNumberOfPages_ShouldThrowException()
        {
            //Arrange
            SetupDatabase();

            //Assert
            Assert.ThrowsException<InvalidPageSizeException>(() => _wpisService.GetNumberOfPages(0));
        }

        [Fact]
        //Page size is bigger than number of entries - actualResult should contain all entries
        public async Task GetByPageNumber_ShouldReturnAllEntries()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = GetEntriesSampleData();

            //Act
            var actualResult = (await _wpisService.GetByPageNumber(1, 100)).ToList();

            //Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        [Fact]
        // When getting only one entity only the newest one should be fetched - default sorting option is SortingOption.Newest
        public async Task GetByPageNumber_ShouldReturnNewestEntry()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = new List<Wpis> { GetEntriesSampleData().OrderByDescending(entry => entry.Data_Ukonczenia_Wycieczki).First() };

            //Act
            var actualResult = (await _wpisService.GetByPageNumber(1, 1)).ToList();

            //Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        [Fact]
        //This method should throw InvalidPageSizeException when page size is lesser than 1
        public async Task GetByPageNumber_ShouldThrowException()
        {
            await Assert.ThrowsExceptionAsync<InvalidPageSizeException>(async () => await _wpisService.GetByPageNumber(1, 0));
        }

        [Fact]
        //This should return three oldest entries
        public async Task GetByPageNumber_ShouldReturnThreeOldest()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = GetEntriesSampleData().OrderBy(entry => entry.Data_Ukonczenia_Wycieczki).Take(3).ToList();

            //Act
            var actualResult = (await _wpisService.GetByPageNumber(1, 3, sortingOption: SortingOption.Oldest)).ToList();

            //Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }

        private void SetupDatabase()
        {
            var entries = GetEntriesSampleData();

            _dbContextMock.Setup(db => db.Wpis).Returns(GetQueryableMockDbSet<Wpis>(entries));
        }

        private DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return dbSet.Object;
        }

        private List<Wpis> GetEntriesSampleData()
        {
            return new List<Wpis>()
            {
                new Wpis
                   {
                       Numer = 1,
                       Numer_Ksiazecki = 1,
                       Numer_Wycieczki = 1,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 11, 14)
                   },

                   new Wpis
                   {
                       Numer = 2,
                       Numer_Ksiazecki = 1,
                       Numer_Wycieczki = 2,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 10, 15)
                   },

                   new Wpis
                   {
                       Numer = 3,
                       Numer_Ksiazecki = 2,
                       Numer_Wycieczki = 2,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 10, 17)
                   },

                   new Wpis
                   {
                       Numer = 4,
                       Numer_Ksiazecki = 2,
                       Numer_Wycieczki = 1,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 11, 17)
                   },

                   new Wpis
                   {
                       Numer = 5,
                       Numer_Ksiazecki = 2,
                       Numer_Wycieczki = 3,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 12, 19)
                   },

                   new Wpis
                   {
                       Numer = 6,
                       Numer_Ksiazecki = 1,
                       Numer_Wycieczki = 4,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 8, 30)
                   },

                   new Wpis
                   {
                       Numer = 7,
                       Numer_Ksiazecki = 2,
                       Numer_Wycieczki = 5,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 7, 18)
                   },

                   new Wpis
                   {
                       Numer = 8,
                       Numer_Ksiazecki = 2,
                       Numer_Wycieczki = 4,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 8, 29)
                   },

                   new Wpis
                   {
                       Numer = 9,
                       Numer_Ksiazecki = 1,
                       Numer_Wycieczki = 5,
                       Data_Ukonczenia_Wycieczki = new DateTime(2021, 7, 17)
                   }
            };
        }

    }
}
