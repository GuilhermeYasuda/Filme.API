namespace FilmeApi.API.Models
{
    public sealed class Filme : EntityBase
    {
        public string Titulo { get; private set; }
        public string Genero { get; private set; }
        public DateTimeOffset DtLancamento { get; private set; }
        public double Avaliacao { get; private set; }

        // Construtor privado para forçar o uso do método de criação e para ORM Framework
        private Filme()
        {
            Titulo = string.Empty;
            Genero = string.Empty;
        }

        private Filme(string titulo, string genero, DateTimeOffset dtLancamento, double avaliacao)
        {
            Titulo = titulo;
            Genero = genero;
            DtLancamento = dtLancamento;
            Avaliacao = avaliacao;
        }

        public static Filme Create(string titulo, string genero, DateTimeOffset dtLancamento, double avaliacao)
        {
            ValidarInputs(titulo, genero, dtLancamento, avaliacao);
            return new Filme(titulo, genero, dtLancamento, avaliacao);
        }

        public void Update(string titulo, string genero, DateTimeOffset dtLancamento, double avaliacao)
        {
            ValidarInputs(titulo, genero, dtLancamento, avaliacao);

            Titulo = titulo;
            Genero = genero;
            DtLancamento = dtLancamento;
            Avaliacao = avaliacao;

            AtualizarDataUltimaAlteracao();
        }

        private static void ValidarInputs(string titulo, string genero, DateTimeOffset dtLancamento, double avaliacao)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título não pode ser nulo ou vazio.", nameof(titulo));

            if (string.IsNullOrWhiteSpace(genero))
                throw new ArgumentException("Gênero não pode ser nulo ou vazio.", nameof(genero));

            if (dtLancamento > DateTimeOffset.UtcNow)
                throw new ArgumentException("Data de lançamento não pode estar no futuro.", nameof(dtLancamento));

            if (avaliacao < 0 || avaliacao > 10)
                throw new ArgumentException("Avaliação deve estar entre 0 e 10.", nameof(avaliacao));
        }
    }
}