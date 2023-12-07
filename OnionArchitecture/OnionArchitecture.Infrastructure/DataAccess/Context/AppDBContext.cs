using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Core;
using System.Reflection;

namespace OnionArchitecture.Infrastructure.DataAccess.Context
{
    public class AppDBContext : DbContext
    {
        public virtual DbSet<Article> Articles { get; set; }

        public AppDBContext()
        {
            Database.EnsureCreated();
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
