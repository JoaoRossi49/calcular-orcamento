
using System;
using DDP;

namespace DDP
{
    public class Item
    {
        private double valor{get;set;}
        private string descricao{get;set;}

        public double Valor { get => valor; set => valor = value; }
        public string Descricao { get => descricao; set => descricao = value; }

        public Item(double valor, string descricao){
            this.valor = valor;
            this.descricao = descricao;
        }
    }
}