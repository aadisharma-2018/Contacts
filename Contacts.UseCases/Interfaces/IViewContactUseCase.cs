namespace Contacts.UseCases.Interfaces
{
    public interface IViewContactUseCase
    {
        Task<CoreBusines.Contact> ExecuteAsync(int contactId);
    }
}