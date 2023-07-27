namespace Contacts.UseCases.Interfaces
{
    public interface IViewContactsUseCase
    {
        Task<List<CoreBusines.Contact>> ExecuteAsync(string filterText);
    }
}