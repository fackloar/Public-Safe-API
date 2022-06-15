using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safe_Development.DataLayer.Identity;
using Safe_Development.DataLayer.Models;

namespace Safe_Development.DataLayer
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<DebitCard> DebitCards { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
