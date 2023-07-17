namespace Contacts.Maui.Views;
using Contacts.Maui.Models;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void contactCtrl_OnUpdate(System.Object sender, System.EventArgs e)
    {
        ContactRepository.AddContact(new Models.Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Phone = contactCtrl.Phone,
            Address = contactCtrl.Address,

        });

        Shell.Current.GoToAsync("..");
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