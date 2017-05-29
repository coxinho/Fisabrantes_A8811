namespace Fisabrantes.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;


    internal sealed class Configuration : DbMigrationsConfiguration<Fisabrantes.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Fisabrantes.Models.ApplicationDbContext context)
        {
            // Configuration --- SEED
            //===================================================================
            // ############################################################################################
            // adiciona Funcionarios
            var Funcionarios = new List<Funcionarios> {
           new Funcionarios  {idFuncionario=1, Nome = "Fernando Sousa", DataNasc = new DateTime (1978,12,5), Rua ="", NumPorta = "", Localidade = "", CodPostal = "", NIF = "", DataEntClinica = new DateTime (2017,4,3), CatProfissional = ""  },
           new Funcionarios  {idFuncionario=2, Nome = "Sílvia Marques", DataNasc = new DateTime (1965,9,3), Rua ="", NumPorta = "", Localidade = "", CodPostal = ""  , NIF = "", DataEntClinica = new DateTime (2017,4,3), CatProfissional = ""  },
           new Funcionarios  {idFuncionario=3, Nome = "Susana Pereira", DataNasc = new DateTime (1980,10,22), Rua ="", NumPorta = "", Localidade = "", CodPostal = ""  , NIF = "", DataEntClinica = new DateTime (2017,4,3), CatProfissional = ""  },
           new Funcionarios  {idFuncionario=4, Nome = "Maria Gouveia", DataNasc = new DateTime (1976,5,7), Rua ="", NumPorta = "", Localidade = "", CodPostal = ""  , NIF = "", DataEntClinica = new DateTime (2017,4,3), CatProfissional = ""  },
           new Funcionarios  {idFuncionario=5, Nome = "Pedro Ferreira", DataNasc = new DateTime (1982,10,10), Rua ="", NumPorta = "", Localidade = "", CodPostal = ""  , NIF = "", DataEntClinica = new DateTime (2017,4,3), CatProfissional = ""  }

        };

            Funcionarios.ForEach(zz => context.Funcionarios.AddOrUpdate(z => z.Nome, zz));
            context.SaveChanges();


            // ############################################################################################
            // adiciona Utentes
            var Utentes = new List<Utentes> {
           new Utentes  {idUtente=1, Nome = "Paulo Dias", DataNasc = new DateTime (1988,3,5), NIF ="", Telefone = "", Morada = "", SNS = ""  },
           new Utentes  {idUtente=2, Nome = "Joana Lopes", DataNasc = new DateTime (1950,6,3), NIF ="", Telefone = "", Morada = "", SNS = ""  },
           new Utentes  {idUtente=3, Nome = "Lurdes Costa", DataNasc = new DateTime (1970,8,2), NIF ="", Telefone = "", Morada = "", SNS = ""  },
           new Utentes  {idUtente=4, Nome = "José Bernardo", DataNasc = new DateTime (1961,4,27), NIF ="", Telefone = "", Morada = "", SNS = ""  },
           new Utentes  {idUtente=5, Nome = "Jorge Santos", DataNasc = new DateTime (1940,7,20), NIF ="", Telefone = "", Morada = "", SNS = ""  }

        };

            Utentes.ForEach(dd => context.Utentes.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();

            // ############################################################################################
            // adiciona Consultas
            var Consultas = new List<Consultas> {
           new Consultas  {idConsulta = 1, DataConsulta =  new DateTime(2017,6,8), UtenteFK = 1, FisiatraFK = 2 },
           new Consultas  {idConsulta = 2, DataConsulta =  new DateTime(2017,6,18), UtenteFK = 4, FisiatraFK = 1 },
           new Consultas  {idConsulta = 3, DataConsulta =  new DateTime(2017,6,10), UtenteFK = 2, FisiatraFK = 3 },
           new Consultas  {idConsulta = 4, DataConsulta =  new DateTime(2017,6,14), UtenteFK = 1, FisiatraFK = 2 },
           new Consultas  {idConsulta = 5, DataConsulta =  new DateTime(2017,6,20), UtenteFK = 3, FisiatraFK = 3 },
           new Consultas  {idConsulta = 6, DataConsulta =  new DateTime(2017,6,17), UtenteFK = 5, FisiatraFK = 2 }
        };

            Consultas.ForEach(cc => context.Consultas.Add(cc));
            context.SaveChanges();

            //    // ############################################################################################
            //    // adiciona Prescricao
            //    var Prescricao = new List<Prescricoes> {
            //   new Prescricoes  {idPrescricao = 1, DataConsulta =  new DateTime(2017,6,8), Descricao = "", FuncionarioFK = 2 },
            //   new Prescricoes  {idPrescricao = 2, DataConsulta =  new DateTime(2017,6,18), Descricao = "", FuncionarioFK = 1 },
            //   new Prescricoes  {idPrescricao = 3, DataConsulta =  new DateTime(2017,6,10), Descricao = "", FuncionarioFK = 2 },
            //   new Prescricoes  {idPrescricao = 4, DataConsulta =  new DateTime(2017,6,14), Descricao = "", FuncionarioFK = 3 },
            //   new Prescricoes  {idPrescricao = 5, DataConsulta =  new DateTime(2017,6,20), Descricao = "", FuncionarioFK = 3 },
            //   new Prescricoes  {idPrescricao = 6, DataConsulta =  new DateTime(2017,6,17), Descricao = "", FuncionarioFK = 2 }
            //};

            //    Prescricao.ForEach(cc => context.Prescricao.Add(cc));
            //    context.SaveChanges();

        }
    }
}
