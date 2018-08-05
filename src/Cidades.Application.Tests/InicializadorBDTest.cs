using Cidades.Data.Context;
using Cidades.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cidades.Application.Tests
{
    [TestClass]
    public class InicializadorBDTest
    {
        [TestMethod]
        public void PopularBdComArquivoCsv_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);
                Assert.IsTrue(context.Cidades.Count() > 0);
            }

        }
    }
}
