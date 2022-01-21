using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerokuApi.infra
{
    public class ApiContext : DbContext
    {
        public DbSet<Models.Produto> Produtos { get; set; }

        public ApiContext() { }

        public ApiContext(DbContextOptions<ApiContext> builder) : base(builder) { }

    }
}
