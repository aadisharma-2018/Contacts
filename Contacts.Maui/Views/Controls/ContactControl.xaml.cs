﻿namespace Contacts.Maui.Views.Controls;

public partial class ContactControl : ContentView
{

    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnUpdate;
    public event EventHandler<EventArgs> OnCancel;


    public ContactControl()
	{
		InitializeComponent();
	}

	public string Name
	{
		get
		{
			return entryName.Text;
		}
		set
		{
			entryName.Text = value;
		}
	}

	public string Email
	{
		get
		{
			return entryEmail.Text;
		}
		set
		{
			entryEmail.Text = value;
		}
	}

    public string Phone
    {
        get
        {
            return entryPhone.Text;
        }
        set
        {
            entryPhone.Text = value;
        }
    }

    public string Address
    {
        get
        {
            return entryAddress.Text;
        }
        set
        {
            entryAddress.Text = value;
        }
    }

    void btnUpdate_Clicked(System.Object sender, System.EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is required.");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                OnError?.Invoke(sender, error.ToString());
            }
            return;
        }

        OnUpdate?.Invoke(sender, e);
    }

    void btnCancel_Clicked(System.Object sender, System.EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}
