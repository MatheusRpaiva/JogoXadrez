using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.Cor != this.Cor;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.Linhas, tabuleiro.Colunas];
            Posicao pos =  new Posicao(0,0);

            //N
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            while(tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(tabuleiro.peca(pos) != null && tabuleiro.peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Linha = pos.Linha - 1;
            }
            
            //L
            pos.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Coluna = pos.Coluna + 1;
            }

            

            //S
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Linha = pos.Linha + 1;
            }


           

            //O

            pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).Cor != Cor)
                {
                    break;
                }

                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }


        public override string ToString()
        {
            return "T";
        }
    }
}