using Cidades.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cidades.Application.Tests
{
    [TestClass]
    public class CidadesServiceTest
    {
        [TestMethod]
        public void ListarCapitais_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);

                var capitais = service.ListarCapitais();

                Assert.IsTrue(capitais.Count() > 0);
                Assert.IsTrue(capitais.Count() == 3);
            }
        }
        
        [TestMethod]
        public void ListarEstadosComMaisEMenosCidades_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);

                var result = service.ListarEstadosComMaiorEMenorQtdeDeCidades();

                Assert.IsTrue(result.UfComMenorNumeroDeCidades != null);
                Assert.IsTrue(result.UfComMenorNumeroDeCidades.UF == "RO");
                Assert.IsTrue(result.UfComMenorNumeroDeCidades.QuantidadeDeCidades == 2);

                Assert.IsTrue(result.UfComMaiorNumeroDeCidades != null);
                Assert.IsTrue(result.UfComMaiorNumeroDeCidades.UF == "MG");
                Assert.IsTrue(result.UfComMaiorNumeroDeCidades.QuantidadeDeCidades == 10);
            }
        }
        
        [TestMethod]
        public void ListarTodasAsCidades_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);

                var result = service.PesquisarCidades(null, null, null, null, null);

                Assert.IsTrue(result.Cidades.Count() > 0);
                Assert.IsTrue(result.Cidades.Count() == 22);
                Assert.IsTrue(result.QuantidadeCidades == result.Cidades.Count());
            }
        }
        
        [TestMethod]
        public void ListarCidades_FiltroPorUF_SC_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);

                var result = service.PesquisarCidades(null, null, "SC", null, null);

                Assert.IsTrue(result.Cidades.Count() > 0);
                Assert.IsTrue(result.Cidades.Count() == 3);

                Assert.IsTrue(result.Cidades.Any(c => c.NomeSemAcentuacao.Contains("Joinville")));
                Assert.IsTrue(result.Cidades.Any(c => c.NomeSemAcentuacao.Contains("Florianopolis")));
                Assert.IsTrue(result.Cidades.Any(c => c.NomeSemAcentuacao.Contains("Itapema")));

                Assert.IsTrue(result.QuantidadeCidades == result.Cidades.Count());
            }
        }
        
        [TestMethod]
        public void ListarCidades_FiltroPorIBGE_SemResultados_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);

                var result = service.PesquisarCidades(12345, null, null, null, null);

                Assert.IsTrue(result.Cidades.Count() == 0);
                Assert.IsTrue(result.QuantidadeCidades == result.Cidades.Count());
            }
        }

        [TestMethod]
        public void ListarCidades_FiltroPorIBGE_Joinville_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);

                var result = service.PesquisarCidades(4208302, null, null, null, null);

                Assert.IsTrue(result.Cidades.Count() == 1);
                Assert.IsTrue(result.QuantidadeCidades == result.Cidades.Count());
                Assert.IsTrue(result.Cidades.FirstOrDefault().Nome == "Itapema");
                Assert.IsTrue(result.Cidades.FirstOrDefault().Ibge == 4208302);
            }
        }

        [TestMethod]
        public void ListarCidades_FiltroPorNome_Mana_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);

                var result = service.PesquisarCidades(null, "Mana", null, null, null);

                Assert.IsTrue(result.Cidades.Count() == 3);
                Assert.IsTrue(result.QuantidadeCidades == result.Cidades.Count());

                Assert.IsTrue(result.Cidades.Any(c => c.Nome.Contains("Manacapuru")));
                Assert.IsTrue(result.Cidades.Any(c => c.Nome.Contains("Manaquiri")));
                Assert.IsTrue(result.Cidades.Any(c => c.Nome.Contains("Manaus")));
            }
        }

        [TestMethod]
        public void ListarCidades_FiltroPorMicroRegiao_Purus_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);

                var result = service.PesquisarCidades(null, null, null, "Purus", null);

                Assert.IsTrue(result.Cidades.Count() == 1);
                Assert.IsTrue(result.QuantidadeCidades == result.Cidades.Count());
                Assert.IsTrue(result.Cidades.FirstOrDefault().Ibge == 1302405);
            }
        }

        [TestMethod]
        public void ListarCidades_FiltroPorMesoRegiao_LesteSergipano_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);

                var result = service.PesquisarCidades(null, null, null, null, "Leste Sergipano");

                Assert.IsTrue(result.Cidades.Count() == 3);
                Assert.IsTrue(result.QuantidadeCidades == result.Cidades.Count());
                Assert.IsTrue(result.Cidades.Any(c => c.Ibge == 2806305));
                Assert.IsTrue(result.Cidades.Any(c => c.Ibge == 2806404));
                Assert.IsTrue(result.Cidades.Any(c => c.Ibge == 2806503));
            }
        }

        [TestMethod]
        public void ExcluirCidade_IbgeExistente_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);
                
                int qtdeCidadesOriginal = service.PesquisarCidades(null, null, null, null, null).QuantidadeCidades;

                service.RemoverCidade(3156403);

                int qtdeCidadesDepoisExclusao = service.PesquisarCidades(null, null, null, null, null).QuantidadeCidades;

                Assert.IsTrue((qtdeCidadesOriginal-1) == qtdeCidadesDepoisExclusao);
            }
        }

        [TestMethod]
        public void ExcluirCidade_IbgeInexistente_Test()
        {
            using (var context = Helpers.InicializadorBDParaTestes.ObterContextApiTestes())
            {
                Helpers.InicializadorBDParaTestes.Seed(context);

                var repository = new CidadeRepository(context);
                var service = new CidadesService(repository);

                int qtdeCidadesOriginal = service.PesquisarCidades(null, null, null, null, null).QuantidadeCidades;

                service.RemoverCidade(111);

                int qtdeCidadesDepoisExclusao = service.PesquisarCidades(null, null, null, null, null).QuantidadeCidades;

                Assert.IsTrue(qtdeCidadesOriginal == qtdeCidadesDepoisExclusao);
            }
        }



    }
}
