using Business.Dtos;
using Business.Helpers;
using Business.Models;

namespace Business.Factories;

public static class ContactFactory
{
    public static ContactRegistrationForm CreateContactRegistrationForm() => new();

    public static Contact Create(ContactRegistrationForm form)
    {
        return new()
        {
            Id = IdGenerator.GenerateId(),
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            PostalCode = form.PostalCode,
            City = form.City
        };

    }

}
