using Microsoft.EntityFrameworkCore;
using SBcredito.Domain.Entities;

namespace SBcredito.Data.Contexts
{
    public class SBCreditoContext : DbContext
    {
        public SBCreditoContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SBCreditoContext).Assembly);
        }

        public DbSet<TituloAnalise> TituloAnalises { get; set; }
    }
}
