namespace P2doVlad.Internal.Models
{
    public class Arma : ItemRPG
    {
        public string Raridade { get; set; }
        public Arma(string nome, double preco, int estoque, string raridade)
        : base(nome, preco, estoque)
        {
            Raridade = raridade;
        }

        public override string ExibirDetalhes()
        {
            return $"[ARMA] {Nome} | R$ {Preco} | Estoque: {Estoque} | Raridade: {Raridade}";
        }
    }
}
