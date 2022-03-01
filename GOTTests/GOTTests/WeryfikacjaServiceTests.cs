using GOT.Data;
using GOT.Data.Services;
using GOT.Exceptions;
using GOT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GOTTests
{
    public class WeryfikacjaServiceTests
    {
        private readonly WeryfikacjaService _weryfikacjaService;
        private readonly Mock<MyDbContext> _dbContextMock = new Mock<MyDbContext>(new DbContextOptionsBuilder<MyDbContext>().Options);


        public WeryfikacjaServiceTests()
        {
            _weryfikacjaService = new WeryfikacjaService(_dbContextMock.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectVerification()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = GetVerificationSampleData().Where(verification => verification.Numer_Wpisu == 3).First();

            //Act
            var actualResult = await _weryfikacjaService.GetById(3);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetById_ShouldThrowInvalidEntryIdentifierException()
        {
            //Arrange
            SetupDatabase();

            //Assert
            await Assert.ThrowsExceptionAsync<InvalidEntryIdentifierException>(async () => await _weryfikacjaService.GetById(-1));
        }

        [Fact]
        public async Task GetCount_ShouldReturnListSize()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = GetVerificationSampleData().Count();

            //Act
            var actualResult = await _weryfikacjaService.GetCount();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Fact]
        public async Task UpdateStatusById_ShouldChangeStatus()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = GetVerificationSampleData().Where(verification => verification.Numer_Wpisu == 3).First();
            expectedResult.Status = GOT.Models.Enums.Status.Odrzucony;

            //Act
            await _weryfikacjaService.UpdateStatusById(3, GOT.Models.Enums.Status.Odrzucony);

            var actualResult = await _weryfikacjaService.GetById(3);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Fact]
        public async Task UpdateStatusById_ShouldThrowInvalidEntryIdentifierException()
        {
            //Arrange
            SetupDatabase();

            //Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await _weryfikacjaService.UpdateStatusById(100, GOT.Models.Enums.Status.Odrzucony));
        }

        [Fact]
        public async Task UpdateStatusById_ShouldNotChangeStatus()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = GetVerificationSampleData().Where(verification => verification.Numer_Wpisu == 5).Single();

            //Act
            await _weryfikacjaService.UpdateStatusById(5, GOT.Models.Enums.Status.Weryfikowany);
            var actualResult = await _weryfikacjaService.GetById(5);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetPageNumbers_ShouldReturnAscendingNumbers()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = (1, 2, 3);

            //Act
            var actualResult = await _weryfikacjaService.GetPageNumbers(1, 3);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Fact]
        public async Task GetPageNumbers_ShouldReturnEqualNumbers()
        {
            //Arrange
            SetupDatabase();
            var expectedResult = (1, 1, 1);

            //Act
            var actualResult = await _weryfikacjaService.GetPageNumbers(1, 100);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        private void SetupDatabase()
        {
            var verifications = GetVerificationSampleData();

            _dbContextMock.Setup(db => db.Weryfikacja).Returns(GetQueryableMockDbSet<Weryfikacja>(verifications));
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

        private List<Weryfikacja> GetVerificationSampleData()
        {
            return new List<Weryfikacja>
            {
                new Weryfikacja
                    {
                        Numer_Wpisu = 1,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "aaaa",
                        Status = GOT.Models.Enums.Status.Odrzucony
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 2,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = GOT.Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 3,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = GOT.Models.Enums.Status.Zweryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 4,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = GOT.Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 5,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = GOT.Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 6,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = GOT.Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 7,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = GOT.Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 8,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = GOT.Models.Enums.Status.Weryfikowany
                    },

                    new Weryfikacja
                    {
                        Numer_Wpisu = 9,
                        Login_Przodownika = "kacper1134",
                        Uzasadnienie = "",
                        Status = GOT.Models.Enums.Status.Weryfikowany
                    }
            };
        }
    }
}
