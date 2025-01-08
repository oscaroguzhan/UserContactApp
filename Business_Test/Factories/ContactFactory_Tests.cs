using System;
using Business.Dtos;
using Business.Factories;
using Business.Models;

namespace Business_Test.Factories;

public class ContactFactory_Tests
{
    [Fact]
    public void Create_ShouldReturnContactRegistrationForm()
    {
        // Arrange
        // Act
        var result = ContactFactory.CreateContactRegistrationForm();
        
        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactRegistrationForm>(result);
    }

    [Fact]
    public void Create_ShouldReturnContact_WhenContactRegistrationFormIsProvided()
    {
        // Arrange
        var form = new ContactRegistrationForm()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com"
        };

        // Act
        var result = ContactFactory.Create(form);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Contact>(result);
        Assert.Equal(form.FirstName, result.FirstName);
        Assert.Equal(form.LastName, result.LastName);
        Assert.Equal(form.Email, result.Email);
    }
}