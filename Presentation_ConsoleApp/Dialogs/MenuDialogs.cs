
using Business.Factories;
using Business.Interfaces;

namespace Presentation_ConsoleApp.Dialogs;

public class MenuDialogs(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void ShowMainMenu()
    {
        while (true)
        {
            DisplayMainMenu();
            Console.Write("Enter your choice (1-3): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewContact();
                    break;
                case "2":
                    ListAllContacts();
                    break;
                case "3":
                    Console.WriteLine("Thank you for using the application...");
                    Thread.Sleep(500);
                    Environment.Exit(0);

                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        
    }

    private void AddNewContact()
    {
         // create an instance of Contact 
        var form = ContactFactory.CreateContactRegistrationForm();
        Console.Clear();
        Console.WriteLine("-------- Add a new contact --------");
        Console.WriteLine();
        Console.Write("Enter first name: ");
        form.FirstName = Console.ReadLine()!;
        Console.Write("Enter last name: ");
        form.LastName = Console.ReadLine()!;
        Console.Write("Enter email: ");
        form.Email = Console.ReadLine()!;
        Console.Write("Enter phone number: ");
        form.PhoneNumber = Console.ReadLine()!;
        Console.Write("Enter postal code: ");
        form.PostalCode = Console.ReadLine()!;
        Console.Write("Enter city: ");
        form.City = Console.ReadLine()!;

        var result = _contactService.Save(form);
        if (result)
        {
            Console.WriteLine("Contact added successfully.");
        }
        else
        {
            Console.WriteLine("Failed to add contact.");
        }
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        

    }
    private void ListAllContacts()
    {
        Console.Clear();
        Console.WriteLine("-------- View all contacts --------");
        Console.WriteLine();
        var contacts = _contactService.GetAll();
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Id: {contact.Id}");
            Console.WriteLine($"First Name: {contact.FirstName}");
            Console.WriteLine($"Last Name: {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"Postal Code: {contact.PostalCode}");
            Console.WriteLine($"City: {contact.City}");
            Console.WriteLine("-----------------------------------");
        }
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        
       
    }


    private static void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("-------- Welcome to Contact Manager App --------");
        Console.WriteLine();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine();
        Console.WriteLine($"{"1.", -3} Add a new contact");
        Console.WriteLine($"{"2.", -3} List all contacts");
        Console.WriteLine($"{"3.", -3} Exit the application");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine();
    }
}
