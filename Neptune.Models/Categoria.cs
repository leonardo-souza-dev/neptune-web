﻿using System;
using System.Collections.Generic;

namespace Neptune.Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public int? IdCategoriaPai { get; private set; }
        public string Descricao { get; private set; }
        public bool Selecionada { get; private set; }
        public List<Categoria> Filhos { get; private set; } = new List<Categoria>();

        public Guid Guid { get; set; } = Guid.NewGuid();

        public Categoria(int id, int? idCategoriaPai, string descricao, bool selecionada)
        {
            Id = id;
            IdCategoriaPai = idCategoriaPai;
            Descricao = descricao;
            Selecionada = selecionada;
        }

        public void SetarSelecionada(bool selecao)
        {
            Selecionada = selecao;

            foreach (var filho in Filhos)
            {
                filho.Selecionada = selecao;
                foreach (var neto in filho.Filhos)
                {
                    neto.Selecionada = selecao;
                }
            }
        }

        public void AdicionarFilhos(List<Categoria> categorias)
        {
            Filhos.AddRange(categorias);
        }
    }
}
