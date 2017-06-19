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
                   new Funcionarios  {idFuncionario=1, Nome = "Fernando Sousa", DataNasc = new DateTime (1978,12,5), Rua ="Av. 25 de Abril", NumPorta = "3", Localidade = "Abrantes", CodPostal = "2200-299", NIF = "133765342", DataEntClinica = new DateTime (2017,4,3), CatProfissional = "M�dico Fisiatra"  },
                   new Funcionarios  {idFuncionario=2, Nome = "S�lvia Marques", DataNasc = new DateTime (1965,9,3), Rua ="Rua da Boavista", NumPorta = "17", Localidade = "Vale Zebrinho", CodPostal = "2205-411"  , NIF = "122443879", DataEntClinica = new DateTime (2017,4,3), CatProfissional = "M�dica Fisiatra"   },
                   new Funcionarios  {idFuncionario=3, Nome = "Susana Pereira", DataNasc = new DateTime (1980,10,22), Rua ="Rua das Larangeiras", NumPorta = "32", Localidade = "Sert�", CodPostal = "6101-909"  , NIF = "182544286", DataEntClinica = new DateTime (2017,4,3), CatProfissional = "Terapeuta da Fala"  },
                   new Funcionarios  {idFuncionario=4, Nome = "Maria Gouveia", DataNasc = new DateTime (1976,5,7), Rua ="Rua Prof. Prado Coelho", NumPorta = "40", Localidade = "Lisboa", CodPostal = "1600-656"  , NIF = "156222786", DataEntClinica = new DateTime (2017,4,3), CatProfissional = "Fisioterapeuta"  },
                   new Funcionarios  {idFuncionario=5, Nome = "Pedro Ferreira", DataNasc = new DateTime (1982,10,10), Rua ="Av. 5 de Outubro", NumPorta = "26", Localidade = "Entroncamento", CodPostal = "2330-084"  , NIF = "173342689", DataEntClinica = new DateTime (2017,4,3), CatProfissional = "Administrativo"  }

                };

            Funcionarios.ForEach(zz => context.Funcionarios.AddOrUpdate(z => z.Nome, zz));
            context.SaveChanges();


            // ############################################################################################
            // adiciona Utentes
            var Utentes = new List<Utentes> {
           new Utentes  {idUtente=1, Nome = "Paulo Dias", DataNasc = new DateTime (1988,3,5), NIF ="154647324", Telefone = "962434671", Morada = "Torres Novas", CodPostal = "2350-630", SNS = "395121876"  },
           new Utentes  {idUtente=2, Nome = "Joana Lopes", DataNasc = new DateTime (1950,6,3), NIF ="122845676", Telefone = "923654871", Morada = "Ponte de S�r", CodPostal = "7400-123", SNS = "395654890"  },
           new Utentes  {idUtente=3, Nome = "Lurdes Costa", DataNasc = new DateTime (1970,8,2), NIF ="133867453", Telefone = "931540761", Morada = "Abrantes", CodPostal = "2200-350", SNS = "395111453"  },
           new Utentes  {idUtente=4, Nome = "Jos� Bernardo", DataNasc = new DateTime (1961,4,27), NIF ="187231569", Telefone = "965214629", Morada = "Tramagal", CodPostal = "2200-332", SNS = "395275998"  },
           new Utentes  {idUtente=5, Nome = "Jorge Santos", DataNasc = new DateTime (1940,7,20), NIF ="144089327", Telefone = "913638510", Morada = "Tomar", CodPostal = "2304-909", SNS = "395003564"  }

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

            // ############################################################################################
            // adiciona Prescricao
            var Prescricao = new List<Prescricoes> {
           new Prescricoes  {idPrescricao = 1, Descricao = "Utente Paulo Dias - Fisioterapia Respirat�ra", ConsultaFK = 2 },
           new Prescricoes  {idPrescricao = 2, Descricao = "Eletroterapia - Pretende-se utilizar a eletricidade em tratamentos e estimula��o.", ConsultaFK = 2 },
           new Prescricoes  {idPrescricao = 3, Descricao = "Pretende-se o movimento com os m�sculos, articula��es, ligamentos, tend�es e estruturas do sistema nervoso central e perif�rico.", ConsultaFK = 2 },
           new Prescricoes  {idPrescricao = 4, Descricao = "Termoterapia - Deve utilizar-se o calor, ou o frio, como forma de tratar diversas patologias.", ConsultaFK = 2},
           new Prescricoes  {idPrescricao = 5, Descricao = "Fototerapia - indicado para o utente Jos�.", ConsultaFK = 2 },
           new Prescricoes  {idPrescricao = 6, Descricao = "Fisioterapia neurofuncional - Tratamento de dist�rbios neurol�gicos que envolvam ou n�o disfun��es motoras.", ConsultaFK = 2 }
         };

             Prescricao.ForEach(cc => context.Prescricao.Add(cc));
             context.SaveChanges();

        }
    }
}
