using System.Collections.Generic;
using System.Threading;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

public class JUPITER
{
    static List<Produto> Produtos = new List<Produto>();
    static string senhaAtual = "admin1";
    static bool senhaAlterada = false;



    public static void VenderProduto(int id, int quantidadeVenda)
    {
        Produto produto = Produtos.Find(x => x.Id == id);

        if (produto != null)
        {
            if (produto.Quantidade > quantidadeVenda)
            {
                produto.Quantidade = quantidadeVenda;
                Console.WriteLine($"Venda realizada: {quantidadeVenda} unidades de {produto.Nome}");
            }
            else
            {
                Console.WriteLine($"Estoque insuficiente para vender: {quantidadeVenda} unidades de {produto.Nome}.");
            }
        }
        else
        {
            Console.WriteLine("ID nao encontrado.");
        }
    }
    public static void ListarProdutos()

    {

        Console.Clear();
        Console.WriteLine("-----------LISTA DE PRODUTOS-----------");
        foreach (var produto in Produtos)
        {
            Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Quantidade: {produto.Quantidade}");

        }
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public static void Main()
    {
        string senha = "";
        bool produtos = false;
        while (true)
        {

            Console.WriteLine("--------------------------BEM-VINDO AO--------------------------");
            Console.WriteLine("");
            Console.WriteLine(Logo());

            if (senha == "")
            {
                Console.WriteLine("INFORME A SUA SENHA DE ADMINISTRADOR!");
                senha = Console.ReadLine();
                Console.Clear();
                if (senha != senhaAtual)
                {
                    Console.WriteLine("SENHA INCORRETA. ENCERRANDO PROGRAMA.");
                    Environment.Exit(0);
                }
            }
            else if (!produtos)
            {
                produtos = true;
                Console.WriteLine("----------------------ADICIONANDO OS PRODUTOS----------------------");
                Console.WriteLine(".");
                Thread.Sleep(1000);
                Console.WriteLine("..");
                Thread.Sleep(1000);
                Console.WriteLine("...");
                Thread.Sleep(1000);
                AdicionarProduto(1, "Caixa de Bolete", 10);
                AdicionarProduto(2, "Pirulitos un.", 30);
                AdicionarProduto(3, "Heineken", 6);
                AdicionarProduto(4, "Doce de leite", 20);
                AdicionarProduto(5, "Cigarro", 3);
                AdicionarProduto(6, "Paçoca", 15);
                AdicionarProduto(7, "Água 500ml", 10);
                AdicionarProduto(8, "Coca-cola 2Lt", 4);

                Console.Clear();
                Console.WriteLine("PRODUTOS ADICIONADOS!");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar......");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar...");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar..");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-----------PAINEL DE CONTROLE-----------");
                Console.WriteLine("");
                Console.WriteLine("[1] - Vender Produto");
                Console.WriteLine("[2] - Listar produtos");
                Console.WriteLine("[3] - Alterar Senha");
                Console.WriteLine("[4] - Fechar Caixa");

                int decisao = Convert.ToInt32(Console.ReadLine());

                switch (decisao)
                {
                    case 1:
                        VenderProdutoTela();
                        break;

                    case 2:
                        ListarProdutos();
                        break;
                    case 3:
                        AlterarSenha();
                        break;
                    case 4:
                        FecharCaixa();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcao invalida");
                        break;
                }




            }



        }
    }
    public static void VenderProdutoTela()
    {
        Console.Clear();
        Console.WriteLine("-----------VENDER PRODUTO-----------");
        ListarProdutos();
        Console.WriteLine("Digite o ID do produto para vender");
        int idProduto = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite a quantidade que deseja vender");
        int quantidadeVenda = Convert.ToInt32(Console.ReadLine());

        VenderProduto(idProduto, quantidadeVenda);

        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    public static void FecharCaixa()
    {
        Console.Clear();
        Console.WriteLine("-----------FECHANDO O CAIXA----------");
        Console.WriteLine("Digite a senha para fechar o caixa:");
        string senhaImput = Console.ReadLine();

        if (senhaImput == senhaAtual)
        {
            ListarProdutos();
            Console.WriteLine();
            Console.WriteLine("O caixa sera fechado em 20 segundos...");
            Thread.Sleep(20000);
            Console.Clear();
            Console.WriteLine("Caixa fechado com sucesso. Programa finalizado!");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Senha incorreta. Caixa nao sera fechado.");
            Thread.Sleep(2000);

        }
    }
    public static void AlterarSenha()
    {
        Console.Clear();
        Console.WriteLine("Digite sua senha atual: ");
        string senhaAtualImput = Console.ReadLine();

        if (senhaAtualImput == senhaAtual)
        {
            Console.Write("Digite a nova senha: ");
            string novaSenha = Console.ReadLine();
            senhaAtual = novaSenha;
            senhaAlterada = true;
            Console.WriteLine("Senha alterada.");
        }
        else
        {
            Console.WriteLine("Senha incorreta. Tente novamente.");

        }
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }





    public static string Logo()
    {
        string logo = "   JJJJJJJJ  U     U  PPPPPPP   II  TTTTTTTT  EEEEEEE  RRRRRRR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PPPPPPP   II     TT     EEEEE    RRRRRRR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR RR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR   RR\n";
        logo += " JJJJJJ       UUUUU   PP        II     TT     EEEEEEE  RR    RR\n";
        logo += "\n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";
        logo += "          33    33  00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          3333333   00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          33    33  00    00  00    00 00    00     \n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";

        return logo;
    }
    static void AdicionarProduto(int id, string nome, int quantidade)
    {
        Produto produto = new Produto(id, nome, quantidade);
        Produtos.Add(produto);
    }
}
class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }


    public Produto(int id, string nome, int quantidade)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;

    }
}
//-------------------

//1 - COLOCAR O ID DO PRODUTO E DIMINUIR A QUANTIDADE, SE O ID NÃO EXISTE, MOSTRAR UMA MENSAGEM DE ERRO
//2 - LISTAR OS PRODUTOS COM A QUANTIDADE ATUALIZADA
//3 - ALTERAR A SENHA, PARA ALTERAR DEVE PEDIR A SENHA ANTIGA, SE ESTIVER INCORRETO DAR UM AVISO
//4 - PARA FECHAR O CAIXA DEVE SER INSERIDO A SENHA ATUAL, MOSTRAR A LISTA DE PRODUTOS
//    COM A QUANTIDADE ATUALZIADA E DEPOIS DE 20 SEGUNDOS FINALIZAR O PROGRAMA