using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2doVlad.Internal.Models
{
    [Table("Aventureiros")]//@ anotação como eu faria em Spring.. -Heitor
    public class Aventureiro
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
        [Required(ErrorMessage = "O nome do herói não pode ficar em branco.")]
        public string Nome { get; internal set; }
        public string Raca { get; internal set; }
        public int Idade { get; internal set; }
        [Required(ErrorMessage = "A classe do aventureiro deve ser selecionada.")]
        public string Classe { get; internal set; }
        public double Dinheiro { get; internal set; }
        [Range(1, 100, ErrorMessage = "O nível do aventureiro não pode ser negativo ou zero, e nem maior que 100.")]
        public int Level { get; internal set; }

        public Aventureiro(string nome, string raca, string classe, int idade, double dinheiro, int level)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Raca = raca;
            Classe = classe;
            Idade = idade;
            Dinheiro = dinheiro;
            Level = level;
        }
        public string ExibirDetalhes()
        {
            return $"[AVENTUREIRO] {Nome} | Raça: {Raca} | Classe: {Classe} | Idade: {Idade} | Dinheiro: R$ {Dinheiro} | Level: {Level}";
        }
    }
}
