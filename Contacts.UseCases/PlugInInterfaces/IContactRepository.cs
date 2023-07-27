using Contact = Contacts.CoreBusines.Contact;

namespace Contacts.UseCases.PlugInInterfaces
{
    public interface IContactRepository
    {
        Task AddContactAsync(Contact contact);
        Task DeleteContactAsync(int contactId);
        Task<Contact> GetContactIdAsync(int contactId);
        Task<List<Contact>> GetContactsAsync(string filterText);
        Task UpdateContactAsync(int contactId, Contact contact);
    }
}
