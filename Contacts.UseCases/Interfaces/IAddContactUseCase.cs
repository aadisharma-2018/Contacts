namespace Contacts.UseCases.Interfaces
{
    public interface IAddContactUseCase
    {
        Task ExecuteAsync(CoreBusines.Contact contact);
    }
}