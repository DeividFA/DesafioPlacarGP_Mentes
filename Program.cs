using System;
using System.Diagnostics;

namespace DesafioPlacarGP_Mentes
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("************************ Bem vindo ao Desafio GP' Mentes ****************************");
                Console.WriteLine();
                Console.WriteLine(MostrarMenu());
                opcao = OpcaoMenu();
                ProcessarOpcaoMenu(opcao);
            } while (opcao != "0");
        }

        private static string OpcaoMenu()
        {
            string opcao;
            Console.Write("Opção desejada: ");
            opcao = Console.ReadLine();
            return opcao;
        }

        static string MostrarMenu()
        {
            string menu = "   Escolha uma opção:\n\n" +
                            "   1 - Executar Placar Random \n" +
                            "   2 - Executar Placar Random com valor pré definido Modelo I - Consulta simples\n" +
                            "   3 - Executar Placar Manual informando pontos de cada jogador\n" +
                            "   4 - Executar Placar Random com valor pré definido Modelo II - Consulta LINQ\n" +
                            "   5 - Executar Placar Random com valor pré definido Modelo III - Consulta Generic's\n" +
                            "   0 - Sair do Programa \n";
            return menu;
        }

        static void ProcessarOpcaoMenu(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    {
                        CabecalhoPadrao("Placar Randomico de 100 milhoes de posições");
                        var retorno = CalculaPlacar.CalcularVencedorRandom();
                        Rodape(retorno);
                    }
                    break;
                case "2":
                    TamnhoPlacarManual();
                    break;
                case "3":
                    {
                        CabecalhoPadrao("Executando Placar Manual para cada Jogador");
                        var retorno = CalculaPlacar.PlacarManualJogador();
                        Rodape(retorno);
                    }
                    break;
               case "4":
                    {
                        IdentificaVencedor();
                    }
                    break;
                case "5":
                    {
                        IdentificaVencedor2();
                    }
                    break;
                case "0":
                    Console.WriteLine("Obrigado por utilizar o programa.");
                    break;
                default:
                    Console.WriteLine("Opção de menu inválida!");
                    break;
            }
        }

        private static void IdentificaVencedor()
        {
            CabecalhoPadrao("Placar Manual Modelo II");
            
            string retorno;

            Console.WriteLine("Digite o valor inteiro e positivo do placar randomico a ser criado (ou digite 'fim' para parar):");

            string entrada = Console.ReadLine();

            if (entrada.ToUpper().Trim() == "FIM")
            {
                return;
            }

            long valor;
            if (!long.TryParse(entrada, out valor))
            {
                retorno = "Entrada inválida. Digite um valor inteiro e positivo";
            }
            else
            {
                if (valor > 1)
                {
                   retorno =  CalculaPlacar.IdentificaVencedor(valor);
                }
                else
                {
                    retorno = "O valor informado deve ser maior que 1 'Um'";
                }

            }

            Rodape(retorno);

        }

        private static void IdentificaVencedor2()
        {
            CabecalhoPadrao("Placar Manual Modelo II");

            string retorno;

            Console.WriteLine("Digite o valor inteiro e positivo do placar randomico a ser criado (ou digite 'fim' para parar):");

            string entrada = Console.ReadLine();

            if (entrada.ToUpper().Trim() == "FIM")
            {
                return;
            }

            long valor;
            if (!long.TryParse(entrada, out valor))
            {
                retorno = "Entrada inválida. Digite um valor inteiro e positivo";
            }
            else
            {
                if (valor > 1)
                {
                    retorno = CalculaPlacar.ProcuraVencedor(valor);
                }
                else
                {
                    retorno = "O valor informado deve ser maior que 1 'Um'";
                }

            }

            Rodape(retorno);

        }

        private static void TamnhoPlacarManual()
        {
            CabecalhoPadrao("Tamanho Randomico Manual I");
            string retorno;
            Console.WriteLine("Digite o valor inteiro e positivo do placar randomico a ser criado (ou digite 'fim' para parar):");

            string entrada = Console.ReadLine();

            if (entrada.ToUpper().Trim() == "FIM")
            {
                return;
            }

            long valor;
            if (!long.TryParse(entrada, out valor))
            {
                retorno = "Entrada inválida. Digite um valor inteiro e positivo";
            }
            else
            {
                if (valor > 1)
                {
                    retorno = CalculaPlacar.CalcularVencedor(valor);
                }
                else
                {
                    retorno = "O valor informado deve ser maior que 1 'Um'";
                }
                
            }
            Rodape(retorno);
        }

        private static void Rodape(string retorno)
        {
            Console.WriteLine("--------> " + retorno);
            Console.WriteLine();
            Console.WriteLine("------------------------------ " + DateTime.Now + " ---------------------");
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu principal");
            Console.ReadKey();
        }

        private static void CabecalhoPadrao(string nomeFuncao)
        {
            Console.Clear();
            Console.WriteLine("************************ Bem vindo ao Desafio GP' Mentes ****************************");
            Console.WriteLine();
            Console.WriteLine("------------------------------ " + DateTime.Now + " ---------------------");
            Console.WriteLine();        
            Console.WriteLine("------------------------------ Executando placar " + nomeFuncao+ " -------------------");
            Console.WriteLine();
        }
    }
}
