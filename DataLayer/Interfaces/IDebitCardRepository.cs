using Safe_Development.DataLayer.Models;

namespace Safe_Development.DataLayer.Interfaces
{
    public interface IDebitCardRepository
    {
        Task CreateDebitCard(DebitCard debitCard);
        Task<IEnumerable<DebitCard>> GetCards();
        Task<DebitCard> GetDebitCardById(int id); 
        Task Update(int id, string name);
        Task Delete(int id);
    }
}
