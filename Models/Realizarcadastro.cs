using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracker.Models
{
    public class RealizarCadastro
    {      
        Cadastro cadastro = new Cadastro();
        List<string> perfilcad = new List<string>();

        public void cadastrarEmpresa()
        {
            Console.WriteLine("Digite o nome da empresa:");
            cadastro.Empresa = Console.ReadLine();
            perfilcad.Add(cadastro.Empresa); 
            Console.Clear();
        }

        public void cadastrarCargo()
        {
            Console.WriteLine("Digite o cargo da vaga:");
            cadastro.Cargo = Console.ReadLine();
            perfilcad.Add(cadastro.Cargo); 
            Console.Clear();
        }

        public void cadastrarPlataforma()
        {
            Console.WriteLine("Digite a plataforma que ofertou a vaga:");
            cadastro.Plataforma = Console.ReadLine();
            perfilcad.Add(cadastro.Plataforma); 
            Console.Clear();
            
        }

        public void DataCandidatura()
        {
            Console.WriteLine("Digite a data de candidatura:");
            string data = Console.ReadLine();
            cadastro.DataCandidatura  = DateTime.Parse(data);
            perfilcad.Add(data); 
            Console.Clear();
        }

        public void cadastrarLink()
        {
            Console.WriteLine("Digite o link da vaga:");
            cadastro.Link = Console.ReadLine();
            perfilcad.Add(cadastro.Link); 
            Console.Clear();
        }

        public void cadastrarObservacoes()
        {
            Console.WriteLine("Digite a observação para a vaga");
            cadastro.Observacoes = Console.ReadLine();
            perfilcad.Add(cadastro.Observacoes); 
            Console.Clear();
        }

        public void cadastrarStatus()
        {
            Console.WriteLine("Digite o status da candidatura:");
            cadastro.Status = Console.ReadLine();
            perfilcad.Add(cadastro.Status); 
            Console.Clear();
        }
        
    }
}