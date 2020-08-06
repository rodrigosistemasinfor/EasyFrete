using EasyFreteApp.Infra.Data.Entities;
using EasyFreteApp.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EasyFreteApp.Infra.Data
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        {

        }

        public virtual DbSet<UsuarioEntity> Usuario { get; set; }

        public virtual DbContext DbContext => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.CPF).IsUnique();
                entity.HasIndex(e => e.RG).IsUnique();
            });

        }

        public void Clear()
        {
            var changedEntries = ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Detached)
                .ToList();

            foreach (var entry in changedEntries)
                Entry(entry.Entity).State = EntityState.Detached;
        }
    }
}
