namespace P2doVlad.Internal.Models
{
    public class Arma : ItemRPG
    {
        private Arma() : base() { Tipo = "Arma"; }
        public Arma(string nome, double preco, int estoque)
            : base(nome, preco, estoque) { }

        public override string ExibirDetalhes()
        {
            return $"[ARMA] {Nome} | R$ {Preco} | Estoque: {Estoque}";
        }
    }
}
