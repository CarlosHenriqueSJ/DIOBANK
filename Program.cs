using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listContas= new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {

                switch(opcaoUsuario)
                {case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			
            }
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
            }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            if (listContas.Count == 0)
            {
                
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
                Console.Write($"#{i} - ");
				Console.WriteLine(conta);
			}

            // testei funcionamento do foreach, mas retire porque precisava  saber o índice.
           // foreach (Conta conta in listContas)
           // {
           //     Console.WriteLine(conta);
                
           // }
        }

        private static void InserirConta()
        {
            Console.WriteLine("inserindo uma nova conta");
            Console.Write("Digite 1 para conta de pessoa Fisica e 2 para conta de pessoa juridica: ");
            int _tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string _nome = Console.ReadLine();

           Console.Write("Digite o saldo inicial: ");
			double _saldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double _credito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)_tipoConta,
										saldo: _saldo,
										credito: _credito,
										nome: _nome);

			listContas.Add(novaConta);

        }

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Bank a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    
    
    }
}
