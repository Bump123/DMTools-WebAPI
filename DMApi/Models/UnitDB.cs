using Microsoft.EntityFrameworkCore;

namespace DMApi.Models
{
    public class UnitDB: DbContext
    {
        public UnitDB(DbContextOptions<UnitDB> options) : base(options) 
        {
            
        }

        public virtual DbSet<Unit> Unit { get; set; }

    }
}
