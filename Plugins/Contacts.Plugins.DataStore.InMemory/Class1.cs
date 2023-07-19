using Contacts.UseCases.PluginInterfaces;

namespace Contacts.Plugins.DataStore.InMemory
{
    // All the code in this file is included in all platforms.
    public class ContactInMemoryRepository : IContactRepository
    {
        public Task<List<CoreBusiness.Contact>> GetContactsAsync(string filterText)
        {
            throw new NotImplementedException();
        }
    }
}