using Safe_Development.BusinessLayer.DTOs;

namespace Safe_Development.API.Responses
{
    public class GetDebitCardsResponse
    {
        public List<DebitCardDTO> debitCards { get; set; }
    }
}
