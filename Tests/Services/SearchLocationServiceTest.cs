using LocationSpoting.Models;
using LocationSpoting.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Services
{
    public class SearchLocationServiceTest
    {
        private ISearchLocationService _searchLocationService;
        private List<Data> _data = new List<Data>()
        {
           new Data 
           { 
               Id = 1,
               Name = "Massage",
               Position = new Position 
               { 
                   Latitude= 59.3166428,
                   Longitude= 18.0561182999999,
               }
           },
            new Data
           {
               Id = 2,
               Name = "Salongens massage",
               Position = new Position
               {
                   Latitude= 59.3320299,
                   Longitude= 18.023149800000056,
               }
           },
             new Data
           {
               Id = 3,
               Name = "Massör",
               Position = new Position
               {
                   Latitude= 59.315887,
                   Longitude= 18.081163800000013,
               }
           },
              new Data
           {
               Id = 4,
               Name = "Svensk massage",
               Position = new Position
               {
                   Latitude= 59.3433317,
                   Longitude= 18.090476800000033,
               }
           }
        };
        
        [SetUp]
        public void Setup()
        {
            var dataProvider = new Mock<IDataProvider>();
            dataProvider.Setup(d => d.ReadFromFile()).Returns(_data);
            _searchLocationService = new SearchLocationService(dataProvider.Object);
        }

        [Test]
        public void SearchLocationTest()
        {
            SearchLocationRequest searchLocationRequest = new SearchLocationRequest()
            {
                Name = "Massage",
                Position = new Position
                {
                    Latitude = 4,
                    Longitude = 45
                }
            };
            var res = _searchLocationService.Search(searchLocationRequest);
            Assert.AreEqual(3, res.Results.Count());
            Assert.AreEqual(3, res.Results.Count());
            Assert.AreEqual(3, res.Results.Count());
            Assert.AreEqual(3, res.Results.Count());


            Assert.Multiple(() =>
            {
                Assert.AreEqual(3, res.Results.Count());
                Assert.AreEqual(3, res.Results.Count());
            });

        }
    }
}
