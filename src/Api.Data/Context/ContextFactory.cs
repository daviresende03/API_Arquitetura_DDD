using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var connectionString = "Server=localhost;Port=3306;DataBase=ApiDDD;Uid=root;Pwd=1";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext> ();
            optionsBuilder.UseMySql(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
