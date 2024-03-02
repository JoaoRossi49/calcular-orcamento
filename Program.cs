
using System;

namespace DDP{

    class Program {
            static void Main(string[] args)
            {
                //Lista de itens que farão parte do orçamento
                var itens = new List<Item>{
                    new Item(25.14, "Caderno"),
                    new Item(250, "Desempenador de vidro"),
                    new Item(842.99, "Graxa em pó"),
                    new Item(11.25, "Saco de gelo 1kg")
                };

                //Novo orçamento utilizando lista de itens como atributo construtor
                Orcamento orc = new Orcamento(itens);

                //Objetos imposto e atribuição de descrição
                Imposto icms = new ICMS();
                icms.Descricao = "ICMS";
                Imposto pix = new PIX();
                pix.Descricao = "PIX";
                Imposto cofins = new COFINS();
                cofins.Descricao = "COFINS";
                Imposto iss = new ISS();
                iss.Descricao = "ISS";
                

                //Criação de lista contendo objetos imposto
                var impostos = new List<Imposto>{
                    icms,
                    pix,
                    cofins,
                    iss
                };

                //Percorremos a lista, calculando o valor de cada imposto
                
                Console.WriteLine("O orçamento informado possui os seguintes itens:" + Environment.NewLine);

                foreach(var item in itens){
                    Console.WriteLine($"Item: {item.Descricao} ------ Valor: {item.Valor}");
                }

                Console.WriteLine($"O valor total do orçamento é: R${orc.Valor}" + Environment.NewLine);

                Console.WriteLine("Os seguintes impostos deverão ser pagos: " + Environment.NewLine);
                
                foreach(Imposto imposto in impostos){
                    Console.WriteLine($"{imposto.Descricao} ---------- R${Math.Round((imposto.calculaImposto(orc.Valor)),2)}");
                }
                

            }
    }

}
