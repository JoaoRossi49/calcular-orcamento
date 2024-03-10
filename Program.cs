
using System;

namespace DDP{

    class Program {
            static void Main(string[] args)
            {
                //Lista de itens que farão parte do orçamento
                var itens = new List<Item>{
                    new Item(25.14, "Caderno"),
                    new Item(2.20, "Desempenador de vidro"),
                    new Item(0.99, "Graxa em pó"),
                    new Item(11.25, "Saco de gelo 1kg"),
                    new Item(96.25, "Monitor"),
                    new Item(8.25, "Mouse Gamer"),
                    new Item(13.25, "Suco de laranja em pó")
                };

                //Novo orçamento utilizando lista de itens como atributo construtor
                Orcamento orcamento = new Orcamento(itens);

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
                
                void imprimeImpostos(Orcamento orcamento, List<Imposto> impostos){
                    Console.WriteLine("O orçamento informado possui os seguintes itens:" + Environment.NewLine);
                    List<Item> listaItens = orcamento.getListaItens();
                    foreach(var item in listaItens){
                        Console.WriteLine($"Item: {item.Descricao} ------ Valor: {item.Valor}");
                    }
                    Console.WriteLine($"O valor total do orçamento é: R${orcamento.Valor}" + Environment.NewLine);
                    Console.WriteLine("Os seguintes impostos deverão ser pagos: " + Environment.NewLine);            
                    foreach(Imposto imposto in impostos){
                        Console.WriteLine($"{imposto.Descricao} ---------- R${Math.Round((imposto.CalculaImposto(orcamento.Valor)),2)}");
                    }
                }
        
                void imprimeDescontos(Orcamento orcamento){
                    IDescontoHandler descontoPorQuantidade = new DescontoPorQuantidadeHandler();
                    IDescontoHandler descontoPorValorTotal = new DescontoPorValorTotalHandler();

                    descontoPorQuantidade.DefinirProximo(descontoPorValorTotal);

                    double descontoFinal = descontoPorQuantidade.CalcularDesconto(orcamento);

                    if (descontoFinal == 0)
                    {
                        Console.WriteLine("Nenhum desconto aplicado");
                    }
                    else
                    {   
                        double valorDesconto = orcamento.Valor * descontoFinal;
                        Console.WriteLine($"Desconto total aplicado: R${Math.Round((valorDesconto),2)}");
                    }
                }

                imprimeImpostos(orcamento, impostos);
                imprimeDescontos(orcamento);
        }
    }
}
