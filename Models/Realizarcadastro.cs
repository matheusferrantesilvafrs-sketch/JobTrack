using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracker.Models
{
    public class RealizarCadastro
    {      
        Cadastro cadastro = new Cadastro();
        List<Cadastro> perfilcad = new List<Cadastro>();

        public void cadastrarEmpresa()
        {
            Console.WriteLine("Digite o nome da empresa:");
            cadastro.Empresa = Console.ReadLine();
            Console.Clear();
        }

        public void cadastrarCargo()
        {
            Console.WriteLine("Digite o cargo da vaga:");
            cadastro.Cargo = Console.ReadLine();
            Console.Clear();
        }

        public void cadastrarPlataforma()
        {
            Console.WriteLine("Digite a plataforma que ofertou a vaga:");
            cadastro.Plataforma = Console.ReadLine(); 
            Console.Clear();
            
        }

        public void DataCandidatura()
        {
            Console.WriteLine("Digite a data de candidatura:");
            string data = Console.ReadLine();
            cadastro.DataCandidatura  = DateTime.Parse(data);
            Console.Clear();
        }

        public void cadastrarLink()
        {
            Console.WriteLine("Digite o link da vaga:");
            cadastro.Link = Console.ReadLine(); 
            Console.Clear();
        }

        public void cadastrarObservacoes()
        {
            Console.WriteLine("Digite a observação para a vaga");
            cadastro.Observacoes = Console.ReadLine(); 
            Console.Clear();
        }

        public void cadastrarStatus()
        {
            Console.WriteLine("Digite o status da candidatura:");
            cadastro.Status = Console.ReadLine(); 
            Console.Clear();
        }
        
        public void cad()
        {
            string cadfeito = string.Empty;
            cadastro.cadfeito = Console.WriteLine($""); 
            perfilcad.Add(cadastro);
        }
        
    }
}