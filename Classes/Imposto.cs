
using System;
using DDP;

namespace DDP{

    public class Imposto {

        public string descricao;        
        public double porcentagem;

        public string Descricao { get => descricao; set => descricao = value; }
        public double Porcentagem { get => porcentagem; set => porcentagem = value; }

        public virtual double calculaImposto(double valorInicial){
            return (valorInicial * this.porcentagem);
        }

    }

    public class ICMS : Imposto{
        public override double calculaImposto(double valorInicial){
            Porcentagem = 0.12;
            return base.calculaImposto(valorInicial);
        }
    }

    public class PIX : Imposto{
        public override double calculaImposto(double valorInicial){
            Porcentagem = 0.16;
            return base.calculaImposto(valorInicial);
        }
    }

    public class COFINS : Imposto{
        public override double calculaImposto(double valorInicial){
            Porcentagem = 0.18;
            return base.calculaImposto(valorInicial);
        }
    }

    public class ISS : Imposto{
        public override double calculaImposto(double valorInicial){
            Porcentagem = 0.11;
            return base.calculaImposto(valorInicial);
        }
    }
}
