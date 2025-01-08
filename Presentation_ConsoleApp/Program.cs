using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation_ConsoleApp.Dialogs;

var serviceCollection = new ServiceCollection();
// register services
serviceCollection.AddSingleton<IFileService>(new FileService("Data", "contacts.json"));
serviceCollection.AddSingleton<IContactService, ContactService>();
serviceCollection.AddSingleton<MenuDialogs>();
var serviceProvider = serviceCollection.BuildServiceProvider();
MenuDialogs menuDialogs = serviceProvider.GetRequiredService<MenuDialogs>();
menuDialogs.ShowMainMenu();