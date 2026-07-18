using JobTracker.Models;

namespace JobTracker.Services
{
    public class Dadosdecadastro
    {
        public PostDados cad()
        {
            PostDados cadastro = new PostDados();

            Console.WriteLine("Digite o nome da empresa:");
            cadastro.Empresa = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Digite o cargo da vaga:");
            cadastro.Cargo = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Digite a descrição:");
            cadastro.Descricoes = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Digite a data da candidatura:");
            string data = Console.ReadLine();
            cadastro.Data = DateTime.Parse(data!);
            Console.Clear();

            return cadastro;
        }
    }
}