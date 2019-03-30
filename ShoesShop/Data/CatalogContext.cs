using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShoesShop.Models
{
    public class CatalogContext : DbContext
    {
        public CatalogContext (DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }

        public DbSet<ShoesShop.Models.Catalog> Catalog { get; set; }
    }
}
