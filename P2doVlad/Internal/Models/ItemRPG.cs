using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2doVlad.Internal.Models
{
    [Table("Itens")]//@ anotação como eu faria em Spring.. -Heitor
    public abstract class ItemRPG
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();//Eu coloquei esse UUID para facilitar a identificação dos itens, mas ele não é necessário para o funcionamento do sistema. Ele vai facilitar a complementação com o Supabase, já que pretendo usar como id global. -Heitor
        [Required (ErrorMessage = "O nome do item não pode ficar em branco.")]
        public string Nome { get; internal set; }
        [Required(ErrorMessage = "O preço do item é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "Preço não pode ser negativo.")]
        public double Preco { get; internal set; }

        [Required(ErrorMessage = "O estoque do item é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "Estoque não pode ser negativo.")]
        public int Estoque { get; internal set; }
        [Required(ErrorMessage = "O tipo do item é obrigatório.")]

        [NotMapped]
        public string TipoTexto => this.GetType().Name;

        protected ItemRPG() { }
        protected ItemRPG(string nome, double preco, int estoque)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido.", nameof(nome));

            if (preco < 0)
                throw new ArgumentOutOfRangeException(nameof(preco), "Preço não pode ser negativo.");

            if (estoque < 0)
                throw new ArgumentOutOfRangeException(nameof(estoque), "Estoque não pode ser negativo.");

            Nome = nome;
            this.Preco = preco;
            this.Estoque = estoque;
        }
 
        public abstract string ExibirDetalhes();
    }
}
