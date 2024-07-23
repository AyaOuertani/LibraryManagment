using Microsoft.EntityFrameworkCore;
using LibraryManagment.Models;
namespace LibraryManagment.Data
{
    public class ApplicationDBcontext : DbContext
    {
        public ApplicationDBcontext(DbContextOptions options) : base(options)
        {
        }

        #region DbSets
        public DbSet<Member> Members { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                        .HasMany(c => c.Books)
                        .WithOne(b => b.BookCategory)
                        .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Loan>(x => x.HasKey(l => new { l.MemberId, l.BookId }));

            modelBuilder.Entity<Loan>()
                        .HasOne(l => l.Member)
                        .WithMany(m=>m.Loans)
                        .HasForeignKey(l => l.MemberId);

            modelBuilder.Entity<Loan>()
                        .HasOne(b => b.Books)
                        .WithMany(b => b.Loans)
                        .HasForeignKey(l => l.BookId);
        }
        #endregion

    }

}
