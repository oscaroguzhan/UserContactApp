using System;
using Business.Helpers;

namespace Business.Models;

public class Contact
{
    public string Id { get; set; } = string.Empty;
     public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;
    
    public string City { get; set; } = string.Empty;
}
