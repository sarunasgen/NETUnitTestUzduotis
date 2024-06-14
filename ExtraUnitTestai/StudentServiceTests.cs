using Moq;
using NETUnitTestUzduotis.Contracts;
using NETUnitTestUzduotis.Models;
using NETUnitTestUzduotis.Services;

namespace ExtraUnitTestai
{
    public class StudentServiceTests
    {
        Mock<IDatabaseRepository> _databaseRepoMock;
        IStudentService studentService;
        public StudentServiceTests()
        {
            
            _databaseRepoMock = new Mock<IDatabaseRepository>();
            _databaseRepoMock.Setup(x => x.AddGoodStudentAsync(It.IsAny<GoodStudent>()));
            _databaseRepoMock.Setup(x => x.AddBadStudentAsync(It.IsAny<BadStudent>()));
            _databaseRepoMock.Setup(x => x.GetStudent(It.IsAny<int>())).ReturnsAsync(new Student { FirstName = "Jonas", 
                LastName = "Jonaitis", StudentNo = 5});
            studentService = new StudentService(_databaseRepoMock.Object);
        }
        [Fact]
        public async void AddDifferentTypeStudent_Test()
        {
            //Arrange
            GoodStudent maxGood = new GoodStudent();
            BadStudent maxBad = new BadStudent();
            //Act
            await studentService.AddStudentAsync(maxGood);
            await studentService.AddStudentAsync(maxBad);
            //Assert
            _databaseRepoMock.Verify(x => x.AddGoodStudentAsync(maxGood), Times.Once);
            _databaseRepoMock.Verify(x => x.AddBadStudentAsync(maxBad), Times.Once);
        }
        [Fact]
        public async void AddGoodTypeStudent_Test()
        {
            //Arrange
            GoodStudent maxGood = new GoodStudent();
            //Act
            await studentService.AddStudentAsync(maxGood);
            //Assert
            _databaseRepoMock.Verify(x => x.AddGoodStudentAsync(It.IsAny<GoodStudent>()), Times.Once);
            _databaseRepoMock.Verify(x => x.AddBadStudentAsync(It.IsAny<BadStudent>()), Times.Never);
        }
        [Fact]
        public async void AddBadTypeStudent_Test()
        {
            //Arrange
            BadStudent maxBad = new BadStudent();
            //Act
            await studentService.AddStudentAsync(maxBad);
            //Assert
            _databaseRepoMock.Verify(x => x.AddGoodStudentAsync(It.IsAny<GoodStudent>()), Times.Never);
            _databaseRepoMock.Verify(x => x.AddBadStudentAsync(It.IsAny<BadStudent>()), Times.Once);
        }
        [Fact]
        public async void GetStudentById_Test()
        {
            //Arrange
            int id = 5;
            //Act
            Student result = await studentService.GetStudentAsync(id);
            //Assert
            Assert.Equal(result.StudentNo, id);
        }
    }
}