namespace P2doVlad.Internal.Models
{
    public abstract class ItemRPG
    {
        public Guid Id { get; private set; } = Guid.NewGuid();//Eu coloquei esse UUID para facilitar a identificação dos itens, mas ele não é necessário para o funcionamento do sistema. Ele vai facilitar a complementação com o Supabase, já que pretendo usar como id global. -Heitor
        public string Nome { get; private set; }

        private double preco;
        public double Preco
        {
            get => preco;
            set
            {
                if (value < 0)
                    throw new Exception("Preço não pode ser negativo.");
                preco = value;
            }
        }

        private int estoque;
        public int Estoque
        {
            get => estoque;
            set
            {
                if (value < 0)
                    throw new Exception("Estoque não pode ser negativo.");
                estoque = value;
            }
        }

        public string Tipo { get; protected set; }

        protected ItemRPG() { }
        protected ItemRPG(string nome, double preco, int estoque)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Nome inválido.");

            Nome = nome;
            Preco = preco;
            Estoque = estoque;
        }

        public abstract string ExibirDetalhes();
    }
}
