using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Lab3.Database;

public class DatabaseContextContextFactory : IDesignTimeDbContextFactory<PeopleDB>
{
    public PeopleDB CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PeopleDB>();
        optionsBuilder.UseSqlServer("Server=tcp:functionappserver.database.windows.net,1433;Initial Catalog=lab3dbfunctionapp;Persist Security Info=False;User ID=adam;Password={1@qwerty};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");

        return new PeopleDB(optionsBuilder.Options);
    }
}