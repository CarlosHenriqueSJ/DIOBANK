using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        private string Nome { get; set; }
        public Conta(TipoConta tipoConta, double credito, double saldo, string nome)
        {
            this.TipoConta = tipoConta;
            this.Credito = credito;
            this.Saldo = saldo;
            this.Nome = nome;
        }

        public bool Sacar(double ValorSaque)


        {
            if (this.Saldo - ValorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= ValorSaque;
            Console.WriteLine($"O saldo atual da conta de {this.Nome} é de {this.Saldo}");
            return true ;

        }

        public void Depositar (double ValorDeposito){




           this.Saldo += ValorDeposito;
           Console.WriteLine($"o salto atual da conta de {this.Nome} é {this.Saldo}");
       


    }
    
        public void Transferir(double ValorTransferencia, Conta ContaDestino){
           if (this.Sacar(ValorTransferencia))
           {
               ContaDestino.Depositar(ValorTransferencia);
           }
       }

        public override string ToString()
        {
           string retorno = $" TipoConta {this.TipoConta} | Nome {this.Nome} | ";
           retorno += $" Saldo {this.Saldo} | Crédito {this.Credito}";
           return retorno;
        }





    
    }

}