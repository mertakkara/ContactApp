using ContactApp.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
