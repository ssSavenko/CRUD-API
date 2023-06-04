using CRUD_API.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Helpers
{
    public interface IItemHelper
    {
        Task Add(Item item);
    }

    public class ItemHelper : IItemHelper
    {
        public DBContextData db { get; set; }

        public ItemHelper(DBContextData db)
        {
            this.db = db;
        }

        public async Task Add(Item item)
        {
            db.Items.Add(item);
            await db.SaveChangesAsync();
        }
    }
}
