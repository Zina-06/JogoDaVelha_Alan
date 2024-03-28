using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha_Alan
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matriz = new string[3, 3];
            string turno = "X";
            List<string> indexNumeros = new List<string> { };
            int index = 1;
            int tentativas = 0;

            //Menu de início
            Console.WriteLine("===========================================");
            Console.WriteLine("              JOGO DA VELHA");
            Console.WriteLine("      Feito por: Fernando 1º Termo");
            Console.WriteLine("===========================================");
            Console.ReadKey();
            Console.Clear();

            //Pergunta o nome dos jogadores
            Console.Write("Jogador 1: ");
            string jogador1 = Console.ReadLine();

            Console.Write("Jogador 2: ");
            string jogador2 = Console.ReadLine();

            string jogador = jogador1;
            Console.Clear();

            //Alimentando a matriz
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = index.ToString();
                    indexNumeros.Add(index.ToString());
                    index++;
                }
            }

            //Lendo a matriz
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($" [{matriz[i, j]}]");
                }
                Console.WriteLine();
            }

            //Pergunta a posição que o jogador quer jogar
            Console.Write($"Escolha a posição, {jogador}({turno}): ");
            string jogada = Console.ReadLine();
            while (!indexNumeros.Contains(jogada))
            {
                Console.Write("Jogada inválida. Tente novamente: ");
                jogada = Console.ReadLine();
            }
            Console.Clear();


            //Começo do jogo

            while (tentativas < 9)
            {
                //Substitui o valor em sua respectiva casa
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

                //Imprime a matriz
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.Write($" [{matriz[i, j]}] ");
                    }

                    Console.WriteLine();
                }

                //Checagem de vitória nas diagonais
                if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2] ||
                    matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
                {
                    Console.WriteLine("------------");
                    Console.WriteLine("Fim de jogo!");
                    Console.WriteLine("------------");
                    Console.WriteLine($"\nParabéns! O vencedor é: {jogador}({turno})");
                    break;
                }

                //Checagem de vitória nas linhas
                if (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2] ||
                    matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2] ||
                    matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2])
                {
                    Console.WriteLine("vitória");
                    break;
                }

                //Checagem de vitória nas colunas
                if (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0])
                {
                }

            }

            if (turno == "X")
                {
                    turno = "O";
                }
                else
                {
                    turno = "X";
                }


             if (jogador == jogador1)
             {
                 jogador = jogador2;
             }
             else
             {
                 jogador = jogador1;
             }

                Console.Write($"Escolha a posição, {jogador}({turno}): ");
                jogada = Console.ReadLine();


                while (!indexNumeros.Contains(jogada))
                {
                    Console.Write("Jogada inválida. Tente novamente: ");
                    jogada = Console.ReadLine();
                }

            tentativas++;
            Console.Clear();





            }
    }

    }
