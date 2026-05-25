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
                throw new Exception("Erro ao conectar ao banco na nuvem para buscar aventureiros. " +  exREAD);
            }
        }

    }
}
