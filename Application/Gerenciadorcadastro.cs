using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using JobTracker.Models;

namespace JobTracker.Models
{

    public class Realizarcadastro
    {
        Dadosdecadastro cadastro = new Dadosdecadastro();

        AppDbContextFactory factory = new AppDbContextFactory();

        AppDbContext context = new AppDbContextFactory().CreateDbContext(Array.Empty<string>());

        string opcoes = string.Empty;

        bool menu = true;

        public void realizarcad()
        {
            Console.WriteLine("Vamos começar o cadastro");
            Console.Clear();
            Cadastro novoCadastro = cadastro.cad();
            context.Cadastros.Add(novoCadastro);
            context.SaveChanges();
        }

        public void mostrarcads()
        {
            Console.WriteLine("O seus cadastros estão...");
            foreach (Cadastro item in context.Cadastros)
                {
                    Console.WriteLine($"Id: {item.Id} \nEmpresa: {item.Empresa} \nCargo: {item.Cargo} \nPlataforma: {item.Plataforma} \nStatus: {item.Status} \nData: {item.DataCandidatura:d} \nLink: {item.Link} \nObservações: {item.Observacoes}");
                }
        }

        public void escluircads()
        {
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
                return;
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
        }

        public void editarcad()
        {
            Console.WriteLine("Qual cadastro você deseja editar?");
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
                return;
            }

            Console.WriteLine("Você tem certeza que deseja editar esse cadastro?");
            Console.WriteLine($"Id: {cadastroEncontrado.Id} \nEmpresa: {cadastroEncontrado.Empresa} \nCargo: {cadastroEncontrado.Cargo} \nPlataforma: {cadastroEncontrado.Plataforma} \nStatus: {cadastroEncontrado.Status} \nData: {cadastroEncontrado.DataCandidatura:d} \nLink: {cadastroEncontrado.Link} \nObservações: {cadastroEncontrado.Observacoes}");
            Console.WriteLine("Digite S para confirmar ou N para cancelar:");

            string opcao = Console.ReadLine().ToUpper();


            if (opcao == "S")
            {
                Console.WriteLine("Escreva a empresa:");
                cadastroEncontrado.Empresa = Console.ReadLine(); 
                Console.WriteLine("Escreva o cargo:");
                cadastroEncontrado.Cargo = Console.ReadLine();
                Console.WriteLine("Escreva a plataforma:"); 
                cadastroEncontrado.Plataforma = Console.ReadLine();
                Console.WriteLine("Escreva o Status:"); 
                cadastroEncontrado.Status = Console.ReadLine(); 
                Console.WriteLine("Escreva a data:");
                string data = Console.ReadLine();
                cadastroEncontrado.DataCandidatura = DateTime.Parse(data);
                Console.WriteLine("Escreva o link:");
                cadastroEncontrado.Link = Console.ReadLine(); 
                Console.WriteLine("Escreva a Observação:");
                cadastroEncontrado.Observacoes = Console.ReadLine(); 
                context.SaveChanges();
                Console.WriteLine("Cadastro editado com sucesso.");
            }
            else
            {
                Console.WriteLine("Edição cancelada.");
            }
            
        }

        public void sair()
        {
            Console.WriteLine("Obrigado por usar o sistema :) ");
        }
        
    }
}