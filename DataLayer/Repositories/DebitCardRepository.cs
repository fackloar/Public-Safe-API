using Microsoft.EntityFrameworkCore;
using Safe_Development.DataLayer.Interfaces;
using Safe_Development.DataLayer.Models;

namespace Safe_Development.DataLayer.Repositories
{
    public class DebitCardRepository : IDebitCardRepository
    {

        DataContext dataContext;

        public DebitCardRepository(DataContext context)
        {
            dataContext = context;
        }

        public async Task CreateDebitCard(DebitCard debitCard)
        {
            using (dataContext)
            {
                await dataContext.AddAsync(debitCard);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task<DebitCard> GetDebitCardById(int id)
        {
            var result = await dataContext.DebitCards
                .Where(card => card.Id == id)
                .SingleOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("No card with this id");
            }
        }
        public async Task<IEnumerable<DebitCard>> GetCards()
        {
            return await dataContext.DebitCards.OrderBy(dc => dc.Id).ToListAsync();
        }

        public async Task Update(int id, string name)
        {
            using (dataContext)
            {
                var debitCardToChange = dataContext.DebitCards.Find(id);
                if (debitCardToChange != null)
                {
                    debitCardToChange.Name = name;
                    dataContext.Update(debitCardToChange);
                }

                await dataContext.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            using (dataContext)
            {
                var debitCardToDelete = dataContext.DebitCards.Find(id);

                if (debitCardToDelete != null)
                {
                    dataContext.DebitCards.Remove(debitCardToDelete);
                }

                await dataContext.SaveChangesAsync();
            }
        }


    }
}
