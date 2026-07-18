namespace JobTracker.Models
{
    public class PostDados
    {
        public int ID { get; set; }

        public string Empresa { get; set; } = string.Empty;

        public string Cargo { get; set; } = string.Empty;

        public DateTime Data { get; set; }

        public string Descricoes { get; set; } = string.Empty;
    }
}