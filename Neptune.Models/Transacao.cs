﻿using System;

namespace Neptune.Domain
{
    public class Transacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string Descricao { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Valor { get; set; }
        public Conta Conta { get; set; }
        public int ContaId => Conta.Id;

        public Transacao(int id, DateTime data, string descricao, Categoria categoria, decimal valor, Conta conta)
        {
            Id = id;
            Data = data;
            Descricao = descricao;
            Categoria = categoria;
            Valor = valor;
            Conta = conta;
        }

        public Transacao()
        {
        }

        public Transacao ObterNovaTransacao()
        {
            Descricao = "descricao";
            Conta = new Conta(0, "selecionada", 0, true);
            Categoria = new Categoria(1, null, "sem categoria", true);

            return this;
        }

        public bool NovaTransacaoEhValida()
        {
            return !string.IsNullOrEmpty(Descricao) && ContaId > 0;
        }
    }
}
