using Cidades.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cidades.Application.Tests.Helpers
{
    public class InicializadorBDParaTestes
    {
        public static void Seed(ApiContext context)
        {
            if (context.Cidades.Any())
                return;

            string arquivoCsv = "SeedData\\cidades_teste.csv";
            Data.Seed.InicializadorBD.Seed(context, arquivoCsv);
        }

        public static ApiContext ObterContextApiTestes()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "CidadesAPITest")
                .Options;

            return new ApiContext(options);
        }
    }
}
