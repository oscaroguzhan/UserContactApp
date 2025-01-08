using System;
using System.Diagnostics;
using System.Text.Json;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService ;
    
    private List<Contact> _contacts = [];

    public IEnumerable<Contact> GetAll()
    {
        var content = _fileService.ReadContentFromFile();
        try
        {
            _contacts = JsonSerializer.Deserialize<List<Contact>>(content)!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            _contacts = [];
        }
        return _contacts;
    }

    public bool Save(ContactRegistrationForm form)
    {
        try {
            var contact = ContactFactory.Create(form);
            _contacts.Add(contact);
            var json = JsonSerializer.Serialize(_contacts);
            return _fileService.SaveContentToFile(json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
