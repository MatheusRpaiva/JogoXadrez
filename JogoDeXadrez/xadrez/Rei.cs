using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
        {
            this.partida = partida;
        }


        private bool podeMover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QuantidadeMovimento == 0;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.Linhas, tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            //N
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //NE
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //L
            pos.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //SE

            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //S
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //SO
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //O

            pos.definirValores(Posicao.Linha , Posicao.Coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //NO

            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            // #jogadaespecial Roque

            if(QuantidadeMovimento == 0 && !partida.xeque)
            {
                // #Roque Pequeno
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if(tabuleiro.peca(p1)==null && tabuleiro.peca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                    
                }
                // #Roque grande
                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna -2] = true;
                    }

                }

            }



            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
