using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class InventoryAppContext : DbContext
    {
        public InventoryAppContext() : base("InventoryContext")

        {

        }

        public DbSet<Product> Products { get; set; }

    }
}
