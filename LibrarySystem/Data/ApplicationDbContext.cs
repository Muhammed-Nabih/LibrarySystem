using LibrarySystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public DbSet<BorrowRequest> BorrowRequests { get; set; }
    }
}
