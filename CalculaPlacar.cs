using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPlacarGP_Mentes
{
    static class CalculaPlacar
    {
        public static long[] PlacarRandom(long size)
        {
            Console.WriteLine("------------------------------ " + DateTime.Now + " ---------------------");
            
            Console.WriteLine();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Random random = new Random();
            
            long[] vetor = new long[size];

            Console.WriteLine(" --> Criando placar Randomico de {0} posições.", size);

            for (int i = 0; i < size; i++)
            {
                vetor[i] = random.Next(2); // atribui 0 ou 1 aleatoriamente

            }

            Console.WriteLine($" --> Placar Criado tempo total: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine();

            stopwatch.Stop();

            return vetor;

        }

        public static void CalcularVencedorRandom()
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.Clear();
            Console.WriteLine("------------------------------ " + DateTime.Now + " ---------------------");
            Console.WriteLine();

            stopwatch.Start();

            Console.WriteLine("------------------------------ Executando placar randomico -------------------");
            Console.WriteLine();
            long totalPontos = 100000000;
            long[] placar = PlacarRandom(totalPontos);
            long contador = (totalPontos / 2) +1;
            bool teste = true;
            long player1=0;
            long player2=0;

            for (long i = 0; i < totalPontos; i++)
            {
                if (placar[i].Equals( 1))
                {
                    player1++;
                }
                else if (placar[i].Equals(0))
                {
                    player2++;
                }

                if (i >= contador ) 
                {
                    if (player1 >= contador && teste)
                    {
                        Console.WriteLine("Jogador 1 e o vencedor, calculando o placar");
                        Console.WriteLine();
                        contador = 0;
                        teste = false;
                    }
                    else if (player2 >= contador && teste)
                    {
                        Console.WriteLine("Jogador 2 e o vencedor, calculando o placar");
                        Console.WriteLine();
                        contador = 0;
                        teste = false;
                    }
                }
            }

            if ((player1 > player2) && !teste)
            {
                Console.WriteLine("Jogador 1 placar: {0}  X Jogador 2 placar: {1}", player1, player2);
            }
            else if ( (player1 < player2) && !teste)
            {
                Console.WriteLine("Jogador 2 placar: {0}  X Jogador 1 placar: {1}", player2, player1);
            }
            else
            {
                Console.WriteLine("Empate! -> " + " Jogador 1 placar: {0}  X Jogador 2 placar: {1}", player1, player2);
            }

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Tempo total: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine("------------------------------ " + DateTime.Now + " ---------------------");
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu principal");
            Console.ReadKey();
        }

        public static void CalcularVencedor(long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.Clear();
            Console.WriteLine("------------------------------ " + DateTime.Now + " ---------------------");
            Console.WriteLine();

            stopwatch.Start();

            Console.WriteLine("------------------------------ Executando placar randomico -------------------");
            Console.WriteLine();
            
            long[] placar = PlacarRandom(size);
            long contador = (size / 2) + 1;
            bool teste = true;
            long player1 = 0;
            long player2 = 0;

            for (long i = 0; i < size; i++)
            {
                if (placar[i].Equals(1))
                {
                    player1++;
                }
                else if (placar[i].Equals(0))
                {
                    player2++;
                }

                if (i >= contador)
                {
                    if (player1 >= contador && teste)
                    {
                        Console.WriteLine("Jogador 1 e o vencedor, calculando o placar");
                        Console.WriteLine();
                        contador = 0;
                        teste = false;
                    }
                    else if (player2 >= contador && teste)
                    {
                        Console.WriteLine("Jogador 2 e o vencedor, calculando o placar");
                        Console.WriteLine();
                        contador = 0;
                        teste = false;
                    }
                }
            }

            if ((player1 > player2) && !teste)
            {
                Console.WriteLine("Jogador 1 placar: {0}  X Jogador 2 placar: {1}", player1, player2);
            }
            else if ((player1 < player2) && !teste)
            {
                Console.WriteLine("Jogador 2 placar: {0}  X Jogador 1 placar: {1}", player2, player1);
            }
            else
            {
                Console.WriteLine("Empate! -> " + " Jogador 1 placar: {0}  X Jogador 2 placar: {1}", player1, player2);
            }

            stopwatch.Stop();

            Console.WriteLine();
            Console.WriteLine($"Tempo total: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine();
            Console.WriteLine("------------------------------ " + DateTime.Now + " ---------------------");
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu principal");
            Console.ReadKey();
        }

        public static void PlacarManualJogador()
        {
            Console.Clear();
            Console.WriteLine("------------------------------ Executando placar manual -------------------");
            Console.WriteLine(      "-------------------------- " + DateTime.Now + " --------------------------");
            Console.WriteLine();

            Console.WriteLine("Digite uma sequência de 0's para inserir pontos no jogador 1 (ou digite 'fim' para parar):");

            long[] player1 =  GravaPlacarJogador(1);

            Console.WriteLine("Digite uma sequência de 1's para inserir pontos no jogador 1 (ou digite 'fim' para parar):");

            long[] player2 = GravaPlacarJogador(2);


            if (player1.LongLength > player2.LongLength)
            {
                Console.WriteLine("Jogador 1 Venceu com placar: {0}  X Jogador 2 placar: {1}", player1.Length, player2.Length);
            }
            else if (player1.LongLength < player2.LongLength)
            {
                Console.WriteLine("Jogador 2 Venceu com placar: {0}  X Jogador 1 placar: {1}", player1.Length, player2.Length);
            }
            else
            {
                Console.WriteLine("Empate! -> " + " Jogador 1 placar: {0}  X Jogador 2 placar: {1}", player1.Length, player2.Length);
            }


            Console.WriteLine();
            Console.WriteLine("------------------------------ " + DateTime.Now + " ---------------------");
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu principal");
            Console.ReadKey();


        }

        static long[] GravaPlacarJogador(int numeroJogador)
        {
            List<long> vetor = new List<long>();
            

            while ( !((long)vetor.Count > (long.MaxValue - 1)))
            {
                string entrada = Console.ReadLine();

                if (entrada.ToUpper() == "FIM")
                {
                    break;
                }

                if((long)vetor.Count > (long.MaxValue - 1))
                {
                    Console.WriteLine("Valor maximo atingido para o jogador");
                    break;
                }

                int valor;
                if (!int.TryParse(entrada, out valor))
                {
                    Console.WriteLine("Entrada inválida. Digite um valor valido para o Jogador {0}", numeroJogador);
                }
                else
                {
                    if (valor > (numeroJogador -1))
                    {
                        Console.WriteLine("Entrada inválida para o Jogador {0} digite apernas {1}", numeroJogador, numeroJogador-1);
                    }
                    else
                    {
                        vetor.Add(valor);
                    }
                }
            }
            return vetor.ToArray();
        }
    }
}
