namespace P2doVlad.Internal.Models
{
    public class Venda
    {
        public string NomeItem { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }
    }
}
