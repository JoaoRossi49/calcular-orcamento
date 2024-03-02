
using System;
using DDP;

namespace DDP
{
    public class Orcamento
    {
        private List<Item> itens{get;set;}
        private double valor{get;set;}

        public double Valor { get => valor; set => valor = value; }

        public Orcamento(List<Item> itens){
            foreach(var item in itens){
                Valor += item.Valor;
            }
        }

    }
}