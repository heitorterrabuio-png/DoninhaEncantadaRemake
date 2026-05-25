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
                using (var db = new AppDbContext())
                {
                    return db.Itens.OrderBy(i => i.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Erro na magia de clarividencia no banco Supabase na nuvem mística.", ex);
            }
        }
        public void SaveItem(ItemRPG item)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    db.Itens.Add(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar o item no Supabase.", ex);
            }
        }
        public void UpdateItem(ItemRPG item)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var itemExistente = db.Itens.Find(item.Id);
                    if (itemExistente != null)
                    {
                        itemExistente.Nome = item.Nome;
                        itemExistente.Preco = item.Preco;
                        itemExistente.Estoque = item.Estoque;
                        if (item is Arma armaDisparada && itemExistente is Arma armaNoBanco)
                        {
                            armaNoBanco.Raridade = armaDisparada.Raridade;
                        }

                        db.SaveChanges();
                    }

                    else
                    {
                        throw new Exception("Item não encontrado para ser usado o feitiço de trasmutação.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao transmutar o item no banco.", ex);
            }
        }
        public void DeleteItem(Guid itemId)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var itemExistente = db.Itens.Find(itemId);
                    if (itemExistente != null)
                    {
                        db.Itens.Remove(itemExistente);
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Item não encontrado para exclusão.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("O item resistiu à destruição no Supabase.", ex);
            }
        }
    }
}
