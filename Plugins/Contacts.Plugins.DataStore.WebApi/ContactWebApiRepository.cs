using Contacts.UseCases.PlugInInterfaces;
using System.Text;
using System.Text.Json;

namespace Contacts.Plugins.DataStore.WebApi
{
    // All the code in this file is included in all platforms.
    public class ContactWebApiRepository : IContactRepository
    {
        private HttpClient _client;
        private JsonSerializerOptions _serializerOptions;

        public ContactWebApiRepository()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task AddContactAsync(CoreBusines.Contact contact)
        {
            string json = JsonSerializer.Serialize<CoreBusines.Contact>(contact, _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            Uri uri = new Uri($"{Constants.WebApiBaseUrl}/contacts");
            await _client.PostAsync(uri, content);
        }

        public async Task DeleteContactAsync(int contactId)
        {
            Uri uri = new Uri($"{Constants.WebApiBaseUrl}/contacts/{contactId}");
            await _client.DeleteAsync(uri);
        }

        public async Task<CoreBusines.Contact> GetContactIdAsync(int contactId)
        {
            Uri uri = new Uri($"{Constants.WebApiBaseUrl}/contacts/{contactId}");
            CoreBusines.Contact contact = null;
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                contact = JsonSerializer.Deserialize<CoreBusines.Contact>(content, _serializerOptions);
            }

            return contact;
        }

        public async Task<List<CoreBusines.Contact>> GetContactsAsync(string filterText)
        {
            var contacts = new List<CoreBusines.Contact>();

            Uri uri;
            if (string.IsNullOrWhiteSpace(filterText))
            {
                uri = new Uri($"{Constants.WebApiBaseUrl}/contacts");
            }
            else
            {
                uri = new Uri($"{Constants.WebApiBaseUrl}/contacts?s={filterText}");
            }

            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                contacts = JsonSerializer.Deserialize<List<CoreBusines.Contact>>(content, _serializerOptions);
            }

            return contacts;
        }

        public async Task UpdateContactAsync(int contactId, CoreBusines.Contact contact)
        {
            string json = JsonSerializer.Serialize<CoreBusines.Contact>(contact, _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            Uri uri = new Uri($"{Constants.WebApiBaseUrl}/contacts/{contactId}");
            await _client.PutAsync(uri, content);
        }
    }
}