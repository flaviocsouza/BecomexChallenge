using App.Business.Interfaces;
using App.Business.Models;
using App.Business.Services;
using App.Business.Test.Fixtures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace App.Business.Test.Services
{
    [Collection(nameof(CountryCollection))]
    public class CountryServiceTests
    {
        readonly CountryTestsFixture _countryTestsFixture;

        public CountryServiceTests(CountryTestsFixture countryTestsFixture)
        {
            _countryTestsFixture = countryTestsFixture;
        }

        [Fact(DisplayName ="Must get a List of Countries By Name")]
        [Trait("Category", "Country Service")]
        public async Task Country_GetCountryByName_MustBringList()
        {
            //Arrange
            var countryHttpClient = new Mock<ICountryHttpClientService>();
            var countryCache = new Mock<ICountryCacheService>();

            countryHttpClient.Setup(c => c.GetCountriesByName(It.IsAny<string>()))
                .Returns(_countryTestsFixture.GetACountryList(10, "Test"));
            var countrySerivce = new CountryService(countryHttpClient.Object, countryCache.Object);

            //Act
            IEnumerable<Country> countries = await countrySerivce.GetCountriesByName("Test");

            //Assert
            countryHttpClient.Verify(client => client.GetCountriesByName(It.IsAny<string>()), Times.Once);
            Assert.True(countries.Any());
    
        }
        
        [Fact(DisplayName = "Must get a List of Countries By Currency")]
        [Trait("Category", "Country Service")]
        public async Task Country_GetCountryByCurrency_MustBringList()
        {
            //Arrange
            var countryHttpClient = new Mock<ICountryHttpClientService>();
            var countryCache = new Mock<ICountryCacheService>();

            countryHttpClient.Setup(c => c.GetCountriesByCurrency(It.IsAny<string>()))
                .Returns(_countryTestsFixture.GetACountryList(10, "Test"));
            var countrySerivce = new CountryService(countryHttpClient.Object, countryCache.Object);

            //Act
            IEnumerable<Country> countries = await countrySerivce.GetCountriesByCurrency("Test");

            //Assert
            countryHttpClient.Verify(client => client.GetCountriesByCurrency(It.IsAny<string>()), Times.Once);
            Assert.True(countries.Any());
        }

        [Fact(DisplayName = "Must get a Country By Code W/ Cache")]
        [Trait("Category", "Country Service")]
        public async Task Country_GetCountryByCurrency_MustBringOneCache()
        {
            //Arrange
            var countryHttpClient = new Mock<ICountryHttpClientService>();
            var countryCacheClient = new Mock<ICountryCacheService>();

            countryHttpClient.Setup(c => c.GetCountryByCode(It.IsAny<string>()))
                .Returns(_countryTestsFixture.GetCountry("Test"));


            countryCacheClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .Returns(await _countryTestsFixture.GetNullCountry("Test"));

            var countrySerivce = new CountryService(countryHttpClient.Object, countryCacheClient.Object);

            //Act
            Country country = await countrySerivce.GetCountryByCode("Test");

            //Assert
            countryHttpClient.Verify(client => client.GetCountryByCode(It.IsAny<string>()), Times.Once);
            Assert.NotNull(country);
        }

        [Fact(DisplayName = "Must get a Country By Code WO/ Cache")]
        [Trait("Category", "Country Service")]
        public async Task Country_GetCountryByCurrency_MustBringOneServer()
        {
            //Arrange
            var countryHttpClient = new Mock<ICountryHttpClientService>();
            var countryCacheClient = new Mock<ICountryCacheService>();

            countryHttpClient.Setup(c => c.GetCountryByCode(It.IsAny<string>()))
                .Returns(_countryTestsFixture.GetCountry("Test"));


            countryCacheClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .Returns(await _countryTestsFixture.GetNullCountry("Test"));

            var countrySerivce = new CountryService(countryHttpClient.Object, countryCacheClient.Object);

            //Act
            Country country = await countrySerivce.GetCountryByCode("Test");

            //Assert
            countryHttpClient.Verify(client => client.GetCountryByCode(It.IsAny<string>()), Times.Once);
            Assert.NotNull(country);
        }

        [Fact(DisplayName = "Must get a Country By Code Calling HttpClientService")]
        [Trait("Category", "Country Service")]
        public async Task Country_GetCountryByCurrency_CallHttpClientService()
        {
            //Arrange
            var countryHttpClient = new Mock<ICountryHttpClientService>();
            var countryCacheClient = new Mock<ICountryCacheService>();

            countryHttpClient.Setup(c => c.GetCountryByCode(It.IsAny<string>()))
                .Returns(_countryTestsFixture.GetCountry("Test"));


            countryCacheClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .Returns(await _countryTestsFixture.GetNullCountry("Test"));

            var countrySerivce = new CountryService(countryHttpClient.Object, countryCacheClient.Object);

            //Act
            Country country = await countrySerivce.GetCountryByCode("Test");

            //Assert
            countryHttpClient.Verify(client => client.GetCountryByCode(It.IsAny<string>()), Times.Once);
            countryCacheClient.Verify(client => client.GetCountry(It.IsAny<string>()), Times.Once);
            countryCacheClient.Verify(client => client.SetCountry(It.IsAny<Country>()), Times.Once);

            Assert.NotNull(country);
        }


        [Fact(DisplayName = "Must get a Country By Code Calling CacheService")]
        [Trait("Category", "Country Service")]
        public async Task Country_GetCountryByCurrency_CallCacheService()
        {
            //Arrange
            var countryHttpClient = new Mock<ICountryHttpClientService>();
            var countryCacheClient = new Mock<ICountryCacheService>();

            countryHttpClient.Setup(c => c.GetCountryByCode(It.IsAny<string>()))
                .Returns(_countryTestsFixture.GetCountry("Test"));


            countryCacheClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .Returns(await _countryTestsFixture.GetCountry("Test"));

            var countrySerivce = new CountryService(countryHttpClient.Object, countryCacheClient.Object);

            //Act
            Country country = await countrySerivce.GetCountryByCode("Test");

            //Assert
            countryHttpClient.Verify(client => client.GetCountryByCode(It.IsAny<string>()), Times.Never);
            countryCacheClient.Verify(client => client.GetCountry(It.IsAny<string>()), Times.Once);
            countryCacheClient.Verify(client => client.SetCountry(It.IsAny<Country>()), Times.Never);

            Assert.NotNull(country);
        }

    }
}
