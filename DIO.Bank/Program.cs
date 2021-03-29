﻿using System;
using System.Collections.Generic;
namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while(opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarConta();
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
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = intTryParce();

            Console.WriteLine("Digite o valor para o deposito: " );
            double valorDeposito = doubleTryParce();

            listaContas[indiceConta].Depositar(valorDeposito);
        
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = intTryParce();

            Console.WriteLine("Digite o valor para o saque: " );
            double valorSaque = doubleTryParce();

            listaContas[indiceConta].Sacar(valorSaque);

        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = intTryParce();

            Console.WriteLine("Digite o número da conta de destino");
            int indiceContaDestino = intTryParce();

            Console.WriteLine("Digite o valor a ser transferido");
            double valorTransferencia = doubleTryParce();

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        

        private static void ListarConta(){
            Console.WriteLine("Listar contas");
            if(listaContas.Count == 0){
                Console.WriteLine("Nunhum conta cadastrada");
                return;
            }
            for (int i = 0; i < listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 pra Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = intTryParce();

            Console.WriteLine("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = doubleTryParce();

            Console.WriteLine("Digite o credito: ");
            double entradaCredito = doubleTryParce();

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);
            listaContas.Add(novaConta);

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

        private static double doubleTryParce()
        {
            if (!double.TryParse(Console.ReadLine(), out double valorDouble))
            {
                Console.WriteLine("Digite apenas valores com inteiros ou com casas decimais.");
                Console.WriteLine("A operação será cancelada.");
                throw new ArgumentOutOfRangeException();
            }

            return valorDouble;
        }

        private static int intTryParce()
        {
            if (!int.TryParse(Console.ReadLine(), out int valorInt))
            {
                Console.WriteLine("Digite apenas valores com inteiros.");
                Console.WriteLine("A operação será cancelada.");
                throw new ArgumentOutOfRangeException();
            }

            return valorInt;
        }

    }
}
