using System;
using System.Collections.Generic;
using System.Linq;
using Curso.Data.Operacoes;
using CursoEfCore.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CursoEfCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var manipula = new ManipulaDados();
            // InserirDados();
            // InserirDadosEmMassa();
            // ConsultarDados();
            // CadastrarPedido();
            manipula.consultaPedidoCarregamentoAdiantado();
            // AtualizarDados();
            // AtualizarDadosDesconectado();
            // RemoverRegistro();
        }


    }
}
