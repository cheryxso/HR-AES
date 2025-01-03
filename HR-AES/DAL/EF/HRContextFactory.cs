using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.EF
{
    public class HRContextFactory : IDesignTimeDbContextFactory<HRContext>
    {
        public HRContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HRContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HRDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new HRContext(optionsBuilder.Options);
        }
    }
}
