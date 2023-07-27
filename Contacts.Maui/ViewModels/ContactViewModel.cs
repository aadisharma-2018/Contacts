//using Android.Database;
using Contacts.Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

using Contact = Contacts.Maui.Models.Contact;
using CommunityToolkit.Mvvm.Input;

namespace Contacts.Maui.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private Contact contact;
        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        public ContactViewModel()
        {
            this.Contact = ContactRepository.GetContactById(1);
        }

        public void LoadContact(int contactId)
        {
            this.Contact = ContactRepository.GetContactById(contactId);
        }

        [RelayCommand]
        public void SaveContact()
        {
            ContactRepository.UpdateContact(
                this.Contact.ContactId,
                this.Contact);
        }

    }
}
