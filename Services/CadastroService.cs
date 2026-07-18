using System.Net.Http.Json;
using JobTracker.Models;

namespace JobTracker.Services
{
    public class CadastroService
    {
        private readonly HttpClient httpClient;

        public CadastroService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<PostDados?> Criar(PostDados novoCadastro)
        {
            HttpResponseMessage resposta =
                await httpClient.PostAsJsonAsync("dadoscad", novoCadastro);

            resposta.EnsureSuccessStatusCode();

            return await resposta.Content.ReadFromJsonAsync<PostDados>();
        }
    }
}