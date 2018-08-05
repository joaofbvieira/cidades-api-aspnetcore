using Cidades.Data.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Cidades.Data.Seed
{
    public class InicializadorBD
    {
        public static void Seed(ApiContext context, string arquivoCsv)
        {
            bool leuPrimeiraLinha = false;
            
            using (StreamReader reader = new StreamReader(arquivoCsv, Encoding.UTF8))
            {
                while (reader.Peek() >= 0)
                {
                    var linha = reader.ReadLine();
                    var campos = linha.Split(",");

                    if (!leuPrimeiraLinha)
                    {
                        leuPrimeiraLinha = true;
                    }
                    else
                    {
                        if (campos.Length > 1)
                        {
                            var cidade = new Domain.Entidades.Cidade();
                            cidade.ibge_id = Int32.Parse(campos[0]);
                            cidade.uf = campos[1];
                            cidade.name = campos[2];
                            cidade.capital = campos[3].Equals("true", StringComparison.InvariantCultureIgnoreCase);
                            cidade.lon = Decimal.Parse(campos[4]);
                            cidade.lat = Decimal.Parse(campos[5]);
                            cidade.no_accents = campos[6];
                            cidade.alternative_names = campos[7];
                            cidade.microregion = campos[8];
                            cidade.mesoregion = campos[9];

                            context.Cidades.Add(cidade);
                        }
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
