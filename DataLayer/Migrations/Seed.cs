using Microsoft.AspNetCore.Identity;
using Safe_Development.DataLayer;
using Safe_Development.DataLayer.Identity;
using Safe_Development.DataLayer.Models;

namespace Safe_Development.Migrations
{
    public class Seed
    {
        public static async Task Initialize(DataContext context, UserManager<User> userManager)
        {
            context.Database.EnsureCreated();

            if (!context.DebitCards.Any())
            {
                var debitCards = new List<DebitCard>()
                {
                    new DebitCard { Id = 1, Balance = 1000, DueMonth = 11, DueYear = 22, IsActive = true, Name = "John Doe", Number = "1234567890" },
                    new DebitCard { Id = 2, Balance = 2000, DueMonth = 03, DueYear = 27, IsActive = true, Name = "Jane Bee", Number = "0987654321" },
                };

                foreach (DebitCard debitCard in debitCards)
                {
                    context.DebitCards.Add(debitCard);
                }

            }
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        DisplayName = "TestUser1",
                        UserName = "TestUser1",
                        Email = "testuser1@test.com"
                    },
                    new User
                    {
                        DisplayName = "TestUser2",
                        UserName = "TestUser2",
                        Email="testuser2@test.com"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "123Xyz!@#");
                }

                context.SaveChanges();
            }
        }
    }
}
