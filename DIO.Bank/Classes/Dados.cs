using System;
using System.IO;
using System.Collections.Generic;
namespace DIO.Bank
{
    public class Dados
    {
        public List<Conta> contas = new List<Conta>();
        private string caminho = "Dados/dados.txt";
        
        public Dados(){
            if(!File.Exists(caminho)){
                StreamWriter write = new StreamWriter(caminho, true);
            }
        }
        public void AdicionarConta(string conta){
            using(StreamWriter write = new StreamWriter(@caminho, true))
            {
                write.WriteLine(conta);
            }
            contas.RemoveRange(0, contas.Count);
            adicionarLista(conta);
        }
        
        public void alterarContas(){
            using(StreamReader alterar = new StreamReader(@caminho, true)){
                var arquivo = ConfigurationSettings.AppSettings["Caminho"].ToString();
            }
            

        }
        public void listarContas(){
            try
            {
                using (StreamReader ler = new StreamReader(caminho))
                {
                    String linha;
                    while ((linha = ler.ReadLine()) != null)
                    {
                        adicionarLista(linha);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void adicionarLista(string conta){
            if(!string.IsNullOrEmpty(conta)){
                contas.Add(quebrarLinha(conta));
            }
        }

        private Conta quebrarLinha(string linha){
            string[] l = linha.Split(",");
            TipoConta tipoConta = (TipoConta)int.Parse(l[0]);
            double saldo = double.Parse(l[2]);
            double credito = double.Parse(l[3]);
            string nome = l[1];
            Conta item = new Conta(tipoConta, saldo, credito, nome);
            return item;
        }
    }
}