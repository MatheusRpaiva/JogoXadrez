﻿using tabuleiro;

namespace xadrez
{

    class Peao : Peca
    {

        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Posicao pos)
        {
            return tabuleiro.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.Linhas, tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (tabuleiro.posicaoValida(p2) && livre(p2) && tabuleiro.posicaoValida(pos) && livre(pos) && QuantidadeMovimento == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //// #jogadaespecial en passant
                //if (Posicao.Linha == 3)
                //{
                //    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                //    if (tabuleiro.posicaoValida(esquerda) && existeInimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulneravelEnPassant)
                //    {
                //        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                //    }
                //    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                //    if (tabuleiro.posicaoValida(direita) && existeInimigo(direita) && tabuleiro.peca(direita) == partida.vulneravelEnPassant)
                //    {
                //        mat[direita.Linha - 1, direita.Coluna] = true;
                //    }
                //}
            }
            else
            {
                pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (tabuleiro.posicaoValida(p2) && livre(p2) && tabuleiro.posicaoValida(pos) && livre(pos) && QuantidadeMovimento == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //// #jogadaespecial en passant
                //if (Posicao.Linha == 4)
                //{
                //    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                //    if (tabuleiro.posicaoValida(esquerda) && existeInimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulneravelEnPassant)
                //    {
                //        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                //    }
                //    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                //    if (tabuleiro.posicaoValida(direita) && existeInimigo(direita) && tabuleiro.peca(direita) == partida.vulneravelEnPassant)
                //    {
                //        mat[direita.Linha + 1, direita.Coluna] = true;
                //    }
                //}
            }

            return mat;
        }
    }
}