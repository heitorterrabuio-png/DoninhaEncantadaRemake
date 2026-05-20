namespace P2doVlad.Internal.Models
{
    public class Arma : ItemRPG
    {
        public Arma(string nome, double preco, int estoque)
            : base(nome, preco, estoque) { }

        public override string ExibirDetalhes()
        {
            return $"[ARMA] {Nome} | R$ {Preco} | Estoque: {Estoque}";
        }
    }
}
