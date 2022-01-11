﻿using Neptune.Web.Data;
using System.Collections.Generic;

namespace Neptune.Web.ViewModel
{
    public class Conta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal SaldoInicial { get; set; }

        private bool _ativo;
        public bool Ativo 
        { 
            get 
            {
                return _ativo;
            } 
            set
            {
                _ativo = value;
                AtualizarTransacoesMes();
            }
        }

        private readonly PagesService _pagesService;

        public Conta(PagesService pagesService)
        {
            _pagesService = pagesService;
        }


        public void AdicionarInteressado(IInteressado interessado)
        {
            Interessados.Add(interessado);
        }

        public void AtualizarTransacoesMes()
        {
            //_pagesService.ObterTransacoesMesPage();
        }

        public List<IInteressado> Interessados { get; set; } = new ();

        public Conta(int id, string nome, bool ativo)
        {
            Id = id;
            Nome = nome;
            Ativo = ativo;
        }

        public Conta(ContaResponse contaResponse)
        {
            Id = contaResponse.Id;
            Nome = contaResponse?.Nome;
            SaldoInicial = contaResponse.SaldoInicial;
        }
    }
}
