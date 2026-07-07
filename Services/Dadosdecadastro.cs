using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracker.Models
{
    public class Dadosdecadastro
    {      
              
        public Cadastro cad()
        {

            Cadastro cadastro = new Cadastro();

            Console.WriteLine("Digite o nome da empresa:");
            cadastro.Empresa = Console.ReadLine();
            Console.Clear();
    

       
            Console.WriteLine("Digite o cargo da vaga:");
            cadastro.Cargo = Console.ReadLine();
            Console.Clear();
        

    
            Console.WriteLine("Digite a plataforma que ofertou a vaga:");
            cadastro.Plataforma = Console.ReadLine(); 
            Console.Clear();
            
        

       
            Console.WriteLine("Digite a data de candidatura:");
            string data = Console.ReadLine();
            cadastro.DataCandidatura  = DateTime.Parse(data);
            Console.Clear();
        

       
            Console.WriteLine("Digite o link da vaga:");
            cadastro.Link = Console.ReadLine(); 
            Console.Clear();
        
        
            Console.WriteLine("Digite a observação para a vaga");
            cadastro.Observacoes = Console.ReadLine(); 
            Console.Clear();
        

       
            Console.WriteLine("Digite o status da candidatura:");
            cadastro.Status = Console.ReadLine(); 
            Console.Clear();

            return cadastro;
        }
        
    }
}