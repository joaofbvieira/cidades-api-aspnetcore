using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cidades.Data.Context
{
    public class ApiContextFactory : IDesignTimeDbContextFactory<ApiContext>
    {
        public ApiContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApiContext>();

            //builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CidadesAPI;User Id=sa;Password=smart;");

            return new ApiContext(builder.Options);
        }
    }
}
