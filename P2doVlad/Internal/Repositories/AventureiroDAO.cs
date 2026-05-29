using P2doVlad.Internal.Models;

namespace P2doVlad.Internal.Repositories
{
    public class AventureiroDAO
    {
        public void Salvar(Aventureiro aventureiro)
        {
            try
            {
                using var context = new AppDbContext();
                context.Aventureiros.Add(aventureiro);
                context.SaveChanges();
            }
            catch (Exception exINSERT)
            {
                throw new Exception("Erro ao salvar o aventureiro na nuvem. " + exINSERT);
            }
        }

        public List<Aventureiro> ListarTodos()
        {
            try
            {
                using var context = new AppDbContext();
                return context.Aventureiros.ToList();
            }
            catch (Exception exREAD)
            {
                throw new Exception("Erro ao conectar ao banco na nuvem para buscar aventureiros. " + exREAD);
            }
        }
        public void Atualizar(Aventureiro aventureiro)
        {
            try
            {
                using var context = new AppDbContext();
                var aventureiroExistente = context.Aventureiros.Find(aventureiro.Id);
                if (aventureiroExistente != null)
                {
                    aventureiroExistente.Nome = aventureiro.Nome;
                    aventureiroExistente.Raca = aventureiro.Raca;
                    aventureiroExistente.Classe = aventureiro.Classe;
                    aventureiroExistente.Idade = aventureiro.Idade;
                    aventureiroExistente.Dinheiro = aventureiro.Dinheiro;
                    aventureiroExistente.Level = aventureiro.Level;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Aventureiro não encontrado para ser atualizado.");
                }
            }
            catch (Exception exUPDATE)
            {
                throw new Exception("Erro ao atualizar o aventureiro na nuvem. " + exUPDATE);
            }
        }
        public void Deletar(Guid id)
        {
            try
            {
                using var context = new AppDbContext();
                var aventureiroExistente = context.Aventureiros.Find(id);
                if (aventureiroExistente != null)
                {
                    context.Aventureiros.Remove(aventureiroExistente);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Aventureiro não encontrado para ser deletado.");
                }
            }
            catch (Exception exDELETE)
            {
                throw new Exception("Erro ao deletar o aventureiro na nuvem. " + exDELETE);
            }
        }
    }
}