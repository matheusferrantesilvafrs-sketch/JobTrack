using System.Data;
using JobTracker.Models;

RealizarCadastro cadastro = new RealizarCadastro();
List<Cadastro> perfilcad = new List<Cadastro>();


string opcoes = string.Empty;

bool menu = true;
while(menu)
{
    Console.Clear();
    Console.WriteLine("Bem-vindo ao sistema de JobTrack, o que você gostaria para hoje?");
    Console.WriteLine("1 - Cadastrar \n2 - Consultar cadastros \n3 - Excluir cadastro \n4 - sair");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Vamos começar o cadastro");
            Console.Clear();
             cadastro.cadastrarEmpresa();
             cadastro.cadastrarCargo();
             cadastro.cadastrarPlataforma();
             cadastro.DataCandidatura();
             cadastro.cadastrarLink();
             cadastro.cadastrarObservacoes();
             cadastro.cadastrarStatus();

            break;

        case "2":
            Console.WriteLine("O seus cadastros estão...");
            Console.WriteLine(perfilcad);
            break;

        case "3":
            Console.WriteLine("Qual cadastro você deseja excluir?");
            break;

        case "4":
            Console.WriteLine("Obrigado por usar o sistema :) ");
            menu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione alguma tecla para continuar");
    Console.ReadLine();
}
