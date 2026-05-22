namespace P2doVlad.Internal.Models
{
    public class Pocao : ItemRPG
    {
        private Pocao() : base() { Tipo = "Pocao"; }
        public Pocao(string nome, double preco, int estoque)
            : base(nome, preco, estoque) { }

        public override string ExibirDetalhes()
        {
            return $"[POÇÃO] {Nome} | R$ {Preco} | Estoque: {Estoque}";
        }
    }
}
