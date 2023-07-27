namespace Contacts.Maui.Views;
using Contacts.Maui.Models;
using Contacts.UseCases.Interfaces;

using Contact = Contacts.CoreBusines.Contact;

public partial class AddContactPage : ContentPage
{
    private readonly IAddContactUseCase addContactUseCase;

    public AddContactPage(IAddContactUseCase addContactUseCase)
	{
		InitializeComponent();
        this.addContactUseCase = addContactUseCase;
    }

    private async void contactCtrl_OnUpdate(System.Object sender, System.EventArgs e)
    {
        await addContactUseCase.ExecuteAsync(new Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Phone = contactCtrl.Phone,
            Address = contactCtrl.Address,

        });

        await Shell.Current.GoToAsync("..");
    }

    void contactCtrl_OnCancel(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    void contactCtrl_OnError(System.Object sender, System.String e)
    {
        DisplayAlert("Error", e, "OK");
    }
}