using System;
using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    bool Save(ContactRegistrationForm form);
    IEnumerable<Contact> GetAll();

}
