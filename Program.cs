using System.Data;
using JobTracker.Models;

RealizarCadastro cadastro = new RealizarCadastro();

AppDbContextFactory factory = new AppDbContextFactory();

AppDbContext context = factory.CreateDbContext(args);

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
            Cadastro novoCadastro = cadastro.cad();
            context.Cadastros.Add(novoCadastro);
            context.SaveChanges();
            break;

        case "2":
            Console.WriteLine("O seus cadastros estão...");
            foreach (Cadastro item in context.Cadastros)
                {
                    Console.WriteLine($"Id: {item.Id} \nEmpresa: {item.Empresa} \nCargo: {item.Cargo} \nPlataforma: {item.Plataforma} \nStatus: {item.Status} \nData: {item.DataCandidatura:d} \nLink: {item.Link} \nObservações: {item.Observacoes}");
                }
            break;

        case "3":
            Console.WriteLine("Qual cadastro você deseja excluir?");
            int ID = Convert.ToInt32(Console.ReadLine());

            Cadastro cadastroEncontrado = null;

            foreach (Cadastro item in context.Cadastros)
            {
                if (ID == item.Id)
                {
                    cadastroEncontrado = item;
                    break;
                }
            }

            if (cadastroEncontrado == null)
            {
                Console.WriteLine("Cadastro não encontrado.");
                break;
            }

             Console.WriteLine("Você tem certeza que deseja excluir esse cadastro?");
             Console.WriteLine($"Id: {cadastroEncontrado.Id} \nEmpresa: {cadastroEncontrado.Empresa} \nCargo: {cadastroEncontrado.Cargo} \nPlataforma: {cadastroEncontrado.Plataforma} \nStatus: {cadastroEncontrado.Status} \nData: {cadastroEncontrado.DataCandidatura:d} \nLink: {cadastroEncontrado.Link} \nObservações: {cadastroEncontrado.Observacoes}");
             Console.WriteLine("Digite S para confirmar ou N para cancelar:");

             string opcao = Console.ReadLine().ToUpper();

            if (opcao == "S")
            {
                context.Cadastros.Remove(cadastroEncontrado);
                context.SaveChanges();
                Console.WriteLine("Cadastro excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Exclusão cancelada.");
            }
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

