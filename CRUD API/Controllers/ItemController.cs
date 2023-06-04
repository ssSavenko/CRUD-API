using CRUD_API.Helpers;
using CRUD_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        public DBContextData db { get; set; }
        public IItemHelper itemHelper { get; set; }

        public ItemController(DBContextData db, IItemHelper itemHelper)
        {
            this.db = db;
            this.itemHelper = itemHelper;
        }

        // GET: ItemController/Get/5
        [HttpGet, Route("Get")]
        public async Task<ActionResult> Get(int id)
        {
            var res = await db.Items.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(res);
        }

        // GET: ItemController/List
        [HttpGet, Route("List")]
        public async Task<ActionResult> List()
        {
            var res = "[{\n\t\"id\": 2,\n\t\"name\": \"string\",\n\t\"description\": \"string\",\n\t\"price\": 0,\n\t\"onOffer\": true\n},\n{\n\t\"id\": 3,\n\t\"name\": \"string\",\n\t\"description\": \"string\",\n\t\"price\": 0,\n\t\"onOffer\": true\n},\n{\n\t\"id\": 4,\n\t\"name\": \"string\",\n\t\"description\": \"string\",\n\t\"price\": 0,\n\t\"onOffer\": true\n}]";
            return Ok(res);
        }

        [HttpPost, Route("Create")]
        public async Task Create(Item item)
        {
            db.Items.Add(item);
            await db.SaveChangesAsync();
        }

        [HttpPost, Route("Update")]
        public async Task Update(int id, Item item)
        {
            var itemBD = db.Items.Where(x => x.Id == id).FirstOrDefault();
            if (item != null)
            {
                itemBD.Name = item.Name;
                itemBD.Description = item.Description;
                itemBD.Price = item.Price;
                itemBD.OnOffer = item.OnOffer;

                db.Items.Update(itemBD);
                await db.SaveChangesAsync();
            }
        }

        [HttpPost, Route("Delete")]
        public async Task Delete(int id)
        {
            var itemBD = db.Items.Where(x => x.Id == id).FirstOrDefault();
            db.Items.Remove(itemBD);
        }
    }
}
