using P2doVlad.Internal.Models;
using System.Collections.Generic;
using System.Linq;

namespace P2doVlad.Internal.Repositories
{
    public class ItemDAO
    {
        public List<ItemRPG> GetAllItems()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Itens.OrderBy(i => i.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar ao banco na nuvem.", ex);
            }
        }
    }
}
