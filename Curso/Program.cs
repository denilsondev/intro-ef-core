using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using CursoEfCore.Domain;
using CursoEfCore.ValueObjects;

namespace CursoEfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // InserirDados();
            // InserirDadosEmMassa();
            ConsultarDados();
        }

        private static void ConsultarDados()
        {
            using var db = new Data.ApplicationContext();
            // var consultaPorSintaxe = (from c in db.Clientes where c.Id>0 select c).ToList();
            var consultaPorMetodo = db.Clientes.ToList();
            System.Console.WriteLine(consultaPorMetodo);
        }

        private static void InserirDadosEmMassa()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    Nome = "Denilson carvalho",
                    CEP = "00000000",
                    Cidade = "Osasco",
                    Estado = "SP",
                    Telefone = "11986379127"
                },
                new Cliente
                {
                    Nome = "Cliente Teste",
                    CEP = "00000000",
                    Cidade = "Osasco",
                    Estado = "SP",
                    Telefone = "11986379127"
                },
            };

            using var db = new Data.ApplicationContext();
            db.AddRange(clientes);

            var registros = db.SaveChanges();
            System.Console.WriteLine($"Total Registro(s): {registros}");
        }

        private static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "12345678",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();
            db.Produtos.Add(produto);

            int registros = db.SaveChanges();
            System.Console.WriteLine($"Total Registro(s): {registros}");
        }
    }
}
