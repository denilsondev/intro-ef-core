

using System;
using System.Collections.Generic;
using CursoEfCore.Domain;
using CursoEfCore.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Curso.Data.Operacoes
{
    public class ManipulaDados
    {
        public void RemoverRegistro()
        {
            using var db = new CursoEfCore.Data.ApplicationContext();
            // var cliente = db.Clientes.Find(5);
            var cliente = new Cliente { Id = 6 };
            //db.Clientes.Remove(cliente);
            //db.Remove(cliente);
            db.Entry(cliente).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void AtualizarDadosDesconectado()
        {
            using var db = new CursoEfCore.Data.ApplicationContext();

            var cliente = new Cliente
            {
                Id = 1
            };
            var clienteDesconectado = new
            {
                Nome = "Cliente Desconectado Passo 3",
                Telefone = "147854221"
            };

            db.Attach(cliente);
            db.Entry(cliente).CurrentValues.SetValues(clienteDesconectado);

            // db.Clientes.Update(cliente);
            db.SaveChanges();
        }
        public void AtualizarDados()
        {
            using var db = new CursoEfCore.Data.ApplicationContext();
            var cliente = db.Clientes.Find(1);
            cliente.Nome = "Cliente alterado Passo 2";

            // db.Clientes.Update(cliente);
            db.SaveChanges();
        }
        public void consultaPedidoCarregamentoAdiantado()
        {
            using var db = new CursoEfCore.Data.ApplicationContext();
            var pedidos = db
                            .Pedidos
                            .Include(pedidos => pedidos.Itens)
                            .ThenInclude(pedidos => pedidos.Produto)
                            .ToList();

            System.Console.WriteLine(pedidos.Count);
        }


        public void CadastrarPedido()
        {
            using var db = new CursoEfCore.Data.ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault();
            var produto = db.Produtos.FirstOrDefault();

            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                Observacao = "Pedido teste",
                Status = StatusPedido.Analise,
                TipoFrete = TipoFrete.SemFrete,
                Itens = new List<PedidoItem>
                {
                    new PedidoItem
                    {
                        ProdutoId = produto.Id,
                        Desconto = 0,
                        Quantidade = 1,
                        Valor = 10,
                    }
                }
            };

            db.Pedidos.Add(pedido);
            db.SaveChanges();
        }

        public void ConsultarDados()
        {
            using var db = new CursoEfCore.Data.ApplicationContext();
            // var consultaPorSintaxe = (from c in db.Clientes where c.Id>0 select c).ToList();
            var consultaPorMetodo = db.Clientes.ToList();
            System.Console.WriteLine(consultaPorMetodo);
        }

        public void InserirDadosEmMassa()
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

            using var db = new CursoEfCore.Data.ApplicationContext();
            db.AddRange(clientes);

            var registros = db.SaveChanges();
            System.Console.WriteLine($"Total Registro(s): {registros}");
        }

        public void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "12345678",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new CursoEfCore.Data.ApplicationContext();
            db.Produtos.Add(produto);

            int registros = db.SaveChanges();
            System.Console.WriteLine($"Total Registro(s): {registros}");
        }
    }
}