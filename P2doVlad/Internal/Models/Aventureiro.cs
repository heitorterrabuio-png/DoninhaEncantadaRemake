namespace P2doVlad.Internal.Models
{
    public class Aventureiro
    {
        public Guid Id { get; private set; }
        public int Idade { get; private set; }
        public string Raca { get; private set; }
        public string Nome { get; private set; }
        public string Classe { get; private set; }
        public double Dinheiro { get; private set; }
        public int Level { get; private set; }

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
