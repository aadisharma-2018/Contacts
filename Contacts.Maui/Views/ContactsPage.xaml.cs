namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

		List<Contact> contacts = new List<Contact>()
		{
			new Contact {Name="Aadi Sharma", Email="asharma@mitre.org"},
			new Contact {Name="Frank", Email="frank@mitre.org"},
			new Contact {Name="Joe Biden", Email="jbiden@secretservice.org"},

		};

		listContacts.ItemsSource = contacts;
	}

	public class Contact
	{
		public string Name { get; set; }
		public string Email { get; set; }

	}

    private void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null)
		{
            Shell.Current.GoToAsync(nameof(EditContactPage));


        }


    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {

        listContacts.SelectedItem = null;

    }
}