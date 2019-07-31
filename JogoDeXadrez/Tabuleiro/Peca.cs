using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QuantidadeMovimento { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = null;
            Cor = cor;
            QuantidadeMovimento = 0;
            this.tabuleiro = tabuleiro;

        }

        public void incrementarQteMovimentos()
        {
            QuantidadeMovimento++;
        }

        public abstract bool[,] movimentosPossiveis();
        
    }
}
