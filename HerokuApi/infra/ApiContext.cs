using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HerokuApi.infra
{
    public class ApiContext : DbContext
    {
        public DbSet<Models.Produto> Produtos { get; set; }

        public ApiContext() { }

        public ApiContext(DbContextOptions<ApiContext> builder) : base(builder) { }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    var dataTime = DateTime.Now;

                    entry.Property("CreatedAt").CurrentValue = dataTime;
                    entry.Property("UpdatedAt").CurrentValue = dataTime;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }


}
