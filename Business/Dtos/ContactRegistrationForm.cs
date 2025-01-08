using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ContactRegistrationForm
{
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;
    
    public string City { get; set; } = string.Empty;

}
