using CommunityToolkit.Maui;
using Contacts.Maui.ViewModels;
using Contacts.Maui.Views;
using Contacts.Plugins.DataStore.InMemory;
using Contacts.UseCases;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PlugInInterfaces;
using Microsoft.Extensions.Logging;
using Contacts.Maui.Views_MVVM;
using Contacts.Plugins.DataStore.SQLLite;

namespace Contacts.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();

#endif
		//builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
		builder.Services.AddSingleton<IContactRepository, ContactSQLiteRepository>();
		builder.Services.AddSingleton<IViewContactsUseCase, ViewContactsUseCase>();
		builder.Services.AddSingleton<IViewContactUseCase, ViewContactUseCase>();
		builder.Services.AddTransient<IEditContactUseCase, EditContactUseCase>();
		builder.Services.AddTransient<IAddContactUseCase, AddContactUseCase>();
		builder.Services.AddTransient<IDeleteContactUseCase, DeleteContactUseCase>();

		builder.Services.AddSingleton<ContactsViewModel>();
		builder.Services.AddSingleton<ContactViewModel>();

		builder.Services.AddSingleton<ContactsPage>();
        builder.Services.AddSingleton<EditContactPage>();
		builder.Services.AddSingleton<AddContactPage>();

		builder.Services.AddSingleton<Contacts_MVVM_Page>();
		builder.Services.AddSingleton<EditContactPage_MVVM>();
        builder.Services.AddSingleton<AddContactPage_MVVM>();

        return builder.Build();
	}
}
