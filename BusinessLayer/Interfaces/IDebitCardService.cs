using Safe_Development.BusinessLayer.DTOs;
using Safe_Development.BusinessLayer.Validation;

namespace Safe_Development.BusinessLayer.Interfaces
{
    public interface IDebitCardService
    {
        Task<IOperationResult<DebitCardDTO>> GetDebitCardById(int id);
        Task<IList<DebitCardDTO>> GetCards();
        Task<IOperationResult<DebitCardDTO>> CreateDebitCard(DebitCardDTO debitCardDTO);
        Task Update(int id, string name);
        Task Delete(int id);

    }
}
