/// <summary>
/// Unit tests for the ContactService class. Moq library uses to create a mock implementation of IFileService interface
/// which is dependency of the ContactService class. By mocking IFileService the tests can isolate the behaviour of contantservice
/// without relying on the actual file system operations
/// </summary>
using System.Reflection.Metadata;
using System.Text.Json;
using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace Business_Test.Services;

public class ContactService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactService _contactService;

    

    public ContactService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactService = new ContactService(_fileServiceMock.Object);
    }
    [Fact]
    public void Save_ShouldReturnTrue_AddSaveContactToListAndSaveToFile() {
        // arrange
        var contactRegistrationForm = new ContactRegistrationForm(){
            FirstName = "Jane",
            LastName = "Doe",
            Email = "jane.doe@gmail.com"
        };

        // when we add stimulate whether if it returns true or not
        _fileServiceMock.Setup(x => x.SaveContentToFile(It.IsAny<string>())).Returns(true);
        // act
        var result = _contactService.Save(contactRegistrationForm);

        //assert 
        Assert.True(result);
        _fileServiceMock.Verify(x => x.SaveContentToFile(It.IsAny<string>()), Times.Once);
    }
    [Fact]
    public void GetAll_ShouldReturnListOfContacts() {
        // arrange
        var list = new List<Contact> { new Contact { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", PhoneNumber = "3323232", PostalCode = "4535445", City = "Malmö" } };
        _fileServiceMock.Setup(x => x.ReadContentFromFile()).Returns(JsonSerializer.Serialize(list));
        //act
        var result = _contactService.GetAll();
        // assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(list[0].FirstName, result.First().FirstName);
        Assert.Equal(list[0].LastName, result.First().LastName);
        Assert.Equal(list[0].Email, result.First().Email);
        Assert.Equal(list[0].Id, result.First().Id);


    }
    
}
