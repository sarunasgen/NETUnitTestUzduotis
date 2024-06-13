using Moq;
using NETUnitTestUzduotis.Models;
using NETUnitTestUzduotis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETUnitTestUzduotis.Tests
{
    public class ListInteractionServiceTests
    {
        IListInteractionService service;
        Mock<IDatabaseService> databaseServiceMock;
        public ListInteractionServiceTests()
        {
            Dog luckyDog = new Dog { Name = "LuckyDog" };
            databaseServiceMock = new Mock<IDatabaseService>();
            databaseServiceMock.Setup(x => x.InsertAnimal(It.IsAny<Animal>()));
            databaseServiceMock.Setup(x => x.GetDog(It.Is<int>(id => id == 12))).Returns(luckyDog);
            service = new ListInteractionService(databaseServiceMock.Object);
        }
        [Fact]
        public void AddCatToCatList_Test()
        {
            //Arrange
            Animal cat = new Cat { Age = 12, Name = "Murkis" };
            //Act
            service.AddToCatList(cat);
            //Assert
            Assert.Contains((Cat)cat, service.GetCatList());
            databaseServiceMock.Verify(x=>x.InsertAnimal(cat), Times.Once);
        }
        [Fact]
        public void AddDogToCatList_Fail_Test()
        {
            //Arrange
            Animal dog = new Dog { Age = 8, Name = "Lakis" };
            //Act
            Action addDogToCatList = () => service.AddToCatList(dog);
            //Assert
            Assert.ThrowsAny<Exception>(addDogToCatList);
            Assert.DoesNotContain(dog, service.GetCatList());
        }
        [Fact]
        public void IsAnimalCat_Test()
        {
            //Arrange
            Animal cat = new Cat { Age = 8, Name = "Murkis" };
            //Act
            bool result = service.IsCat(cat);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void IsAnimalCat_Dog_Fail_Test()
        {
            //Arrange
            Animal dog = new Dog { Age = 8, Name = "Lakis" };
            //Act
            bool result = service.IsCat(dog);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void GetDogById_Test()
        {
            //Act
            Dog result = service.GetDogByIdFromDb(12);
            //Assert
            Assert.IsType<Dog>(result);
        }

    }
}
