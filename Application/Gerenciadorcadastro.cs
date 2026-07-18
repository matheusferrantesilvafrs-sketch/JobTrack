using JobTracker.Models;
using JobTracker.Services;

namespace JobTracker.Application
{
    public class Gerenciadorcadastro
    {
        private readonly CadastroService cadastroService;
        private readonly Dadosdecadastro cadastro;

        public Gerenciadorcadastro(CadastroService cadastroService)
        {
            this.cadastroService = cadastroService;
            cadastro = new Dadosdecadastro();
        }

        public async Task realizarcad()
        {
            PostDados novoCadastro = cadastro.cad();

            PostDados? cadastroCriado =
                await cadastroService.Criar(novoCadastro);

            if (cadastroCriado is null)
            {
                Console.WriteLine("Não foi possível realizar o cadastro.");
                return;
            }

            Console.WriteLine("Cadastro realizado com sucesso!");
        }
    }
}