using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data.DAL
{
    public class MainContextFactory : IDesignTimeDbContextFactory<MainContext>
    {
        //Server=9UKYKP;Database=QirmiziDB;User Id=test;Password=6hc9f2W@;
        //Server=qirmizi.mssql.somee.com;Database=qirmizi;User Id=qirmizidb_SQLLogin_1;Password=2cydxf1ly5;MultipleActiveResultSets=true;
        //private const string ConnectionString = "Server=9UKYKP;Database=QirmiziDB;User Id=test;Password=6hc9f2W@;";

        public MainContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MainContext>();
            optionsBuilder.UseSqlServer("Server=interalrentacar.mssql.somee.com;Database=interalrentacar;User Id=interalrentacar_SQLLogin_1;Password=wu2ahtk9k6;MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies().ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
            return new MainContext(optionsBuilder.Options);
        }
    }
}
