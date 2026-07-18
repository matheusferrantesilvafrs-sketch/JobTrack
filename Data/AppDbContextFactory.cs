using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        var connectionString = "server=localhost;user=root;password=#Ma29032008*;database=jobtracker;port=3306;";

        optionsBuilder.UseMySql
        (
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );

        return new AppDbContext(optionsBuilder.Options);
    }
}
