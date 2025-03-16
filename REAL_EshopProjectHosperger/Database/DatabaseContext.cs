using Microsoft.EntityFrameworkCore;
using REAL_EshopProjectHosperger.Entities;

namespace REAL_EshopProjectHosperger.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        

        public DatabaseContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4a2_hospergermatej_db1;user=hospergermatej;password=123456;charset=utf8;");
        }
    }
}
