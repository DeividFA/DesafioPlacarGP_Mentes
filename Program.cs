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
                            "   2 - Executar Placar Random com valor pré definido\n" +
                            "   3 - Executar Placar Manual informando pontos de cada jogador\n" +
                            "   0 - Sair do Programa \n";
            return menu;
        }

        static void ProcessarOpcaoMenu(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    CalculaPlacar.CalcularVencedorRandom();
                    break;
                case "2":
                    TamnhoPlacarManual();
                    break;
                case "3":
                    CalculaPlacar.PlacarManualJogador();
                    break;
                case "0":
                    Console.WriteLine("Obrigado por utilizar o programa.");
                    break;
                default:
                    Console.WriteLine("Opção de menu inválida!");
                    break;
            }
        }

        private static void TamnhoPlacarManual()
        {
            Console.WriteLine("Digite o valor inteiro e positivo do placar randomico a ser criado (ou digite 'fim' para parar):");

            string entrada = Console.ReadLine();

            if (entrada.ToUpper().Trim() == "FIM")
            {
                return;
            }

            long valor;
            if (!long.TryParse(entrada, out valor))
            {
                Console.WriteLine("Entrada inválida. Digite um valor inteiro e positivo");
            }
            else
            {
                if (valor > 1)
                {
                    CalculaPlacar.CalcularVencedor(valor);
                }
                else
                {
                    Console.WriteLine("O valor informado deve ser maior que 1 'Um'");
                    Console.ReadKey();
                }
                
            }
        }    
    }
}
