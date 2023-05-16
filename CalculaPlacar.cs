using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public static string CalcularVencedorRandom()
        {
            long totalPontos = 100000000;
            long[] placar = PlacarRandom(totalPontos);
            // para saber matematicamente quem e o vencedor com isso posso decidir se encerro o loop
            long contador = (totalPontos / 2) + 1;
            long player1=0;
            long player2=0;

            for (long i = 0; i < totalPontos; i++)
            {
                if (placar[i].Equals(1))
                {
                    player1++;
                }
                else if (placar[i].Equals(0))
                {
                    player2++;
                }

                if (i > contador ) 
                {
                    if (player1 > contador)
                    {
                        return "Jogador 1 Venceu";
                    }
                    else if (player2 > contador )
                    {
                        return "Jogador 2 Venceu";
                    }
                }
            }

            return "Empate! ";
        }

        public static string CalcularVencedor(long size)
        {
            long[] placar = PlacarRandom(size);
            bool teste = true;
            // para saber matematicamente quem e o vencedor com isso posso decidir se encerro o loop
            long contador = (size / 2) + 1; 
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
                        contador = 0;
                        teste = false;
                    }
                    else if (player2 >= contador && teste)
                    {
                        contador = 0;
                        teste = false;
                    }
                }
            }

            if ((player1 > player2) && !teste)
            {
                return "Jogador 1 Venceu ";
            }
            else if ((player1 < player2) && !teste)
            {
                return "Jogador 2 Venceu";
            }
            else
            {
                return "Empate! ";
            }
        }

        public static string PlacarManualJogador()
        {
            long[] player1 =  GravaPlacarJogador(1);
            long[] player2 = GravaPlacarJogador(2);

            if (player1.LongLength > player2.LongLength)
            {
                return "Jogador 1 Venceu ";
            }
            else if (player1.LongLength < player2.LongLength)
            {
                return "Jogador 2 Venceu ";
            }
            else
            {
                return "Empate! ";
            }
        }

        static long[] GravaPlacarJogador(int numeroJogador)
        {
            List<long> vetor = new List<long>();
            Console.WriteLine("Digite uma sequência de {0}'s para inserir pontos no jogador {1}" +
                " (ou digite 'fim' para parar):",(numeroJogador -1), numeroJogador);

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
                    if (valor != (numeroJogador -1))
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

        public static string IdentificaVencedor(long size)
        {
            //usando consulta Linq para buscar os dados
            //precisei dar uma lida na documentação
            long[] placar = PlacarRandom(size);

            long jogador1 = placar.Count(x => x == 0);
            long jogador2 = placar.Count(x => x == 1);

            if (jogador1 > jogador2)
            {
                return "Jogador 1 Venceu";
            }
            else if (jogador1 < jogador2)
            {
                return "Jogador 2 Venceu";
            }
            else
            {
                return "Empate! ";
            }
        }

        public static string ProcuraVencedor(long size)
        {
            //pelo que entendi quando estava estudando no domindo essa seria uma consulta usando generic
            long[] placar = PlacarRandom(size);

            long jogador1 = Array.FindAll(placar, x => x == 0).LongLength;
            long jogador2 = Array.FindAll(placar, x => x == 1).LongLength;

            if (jogador1 > jogador2)
            {
                return "Jogador 1 Venceu";
            }
            else if (jogador1 < jogador2)
            {
                return "Jogador 2 Venceu";
            }
            else
            {
                return "Empate! ";
            }
        }
    }
}
