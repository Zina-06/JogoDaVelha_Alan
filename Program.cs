using System;
using System.Collections.Generic;

namespace JogoDaVelha_Alan
{
    class Program
    {
        static void Main(string[] args)
        {
            bool jogarNovamente = true;

            while (jogarNovamente)
            {
                JogoDaVelha();

                Console.Write("\nDeseja jogar novamente? (s/n): ");
                char resposta = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (resposta != 's' && resposta != 'S')
                    jogarNovamente = false;

                Console.Clear();
            }

            Console.WriteLine("Obrigado por jogar!");
            Console.ReadKey();
        }

        static void JogoDaVelha()
        {
            string[,] matriz = new string[3, 3];
            string turno = "X";
            List<string> indexNumeros = new List<string>();
            int index = 1;
            int tentativas = 1;
            menuInicio();
            string jogada;

            // Pergunta o nome dos jogadores
            Console.Write("Jogador 1: ");
            string jogador1 = Console.ReadLine();
            Console.Write("Jogador 2: ");
            string jogador2 = Console.ReadLine();
            string jogador = jogador1;
            Console.Clear();

            // Alimentando a matriz
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = index.ToString();
                    indexNumeros.Add(index.ToString());
                    index++;
                }
            }

            // Lendo a matriz
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($" [{matriz[i, j]}]");
                }
                Console.WriteLine();
            }

            // Pergunta a posição que o jogador quer jogar
            jogada = jogadaCheck(turno, indexNumeros, jogador);

            // Começo do jogo
            while (tentativas < 10)
            {
                // Substitui o valor em sua respectiva casa
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (matriz[i, j] == jogada && indexNumeros.Contains(jogada))
                        {
                            matriz[i, j] = turno;
                            indexNumeros.Remove(jogada);
                        }
                    }
                }

                // Imprime a matriz
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.Write($" [{matriz[i, j]}] ");
                    }
                    Console.WriteLine();
                }
                
                // Checagem de vitória nas diagonais
                if ((matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2]) ||
                    (matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0]))
                {
                    vitoria(turno, jogador);
                    return;
                }

                // Checagem de vitória nas linhas
                for (int i = 0; i < 3; i++)
                {
                    if (matriz[i, 0] == matriz[i, 1] && matriz[i, 1] == matriz[i, 2])
                    {
                        vitoria(turno, jogador);
                        return;
                    }
                }

                // Checagem de vitória nas colunas
                for (int j = 0; j < 3; j++)
                {
                    if (matriz[0, j] == matriz[1, j] && matriz[1, j] == matriz[2, j])
                    {
                        vitoria(turno, jogador);
                        return;
                    }
                }

                    tentativas++;

                // Alternância de turnos
                altTurnos(ref turno, jogador1, jogador2, ref jogador);

                // Checa se a jogada é válida
                jogada = jogadaCheck(turno, indexNumeros, jogador);

                if(tentativas == 9)
                {
                    Console.WriteLine("Empato");
                }
            }
            
        }

        private static void altTurnos(ref string turno, string jogador1, string jogador2, ref string jogador)
        {
            turno = (turno == "X") ? "O" : "X";
            jogador = (jogador == jogador1) ? jogador2 : jogador1;
        }

        private static string jogadaCheck(string turno, List<string> indexNumeros, string jogador)
        {
            string jogada;
            Console.Write($"Escolha a posição, {jogador}({turno}): ");
            jogada = Console.ReadLine();

            while (!indexNumeros.Contains(jogada))
            {
                Console.Write("Jogada inválida. Tente novamente: ");
                jogada = Console.ReadLine();
            }
            Console.Clear();
            return jogada;
        }

        private static void vitoria(string turno, string jogador)
        {
            Console.WriteLine("------------");
            Console.WriteLine("Fim de jogo!");
            Console.WriteLine("------------");
            Console.WriteLine($"\nParabéns! O vencedor é: {jogador}({turno})");
        }

        private static void menuInicio()
        {

            //Menu de início
            Console.WriteLine("===========================================");
            Console.WriteLine("              JOGO DA VELHA");
            Console.WriteLine($"      Feito por: Fernando 1° Termo");
            Console.WriteLine("===========================================");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
