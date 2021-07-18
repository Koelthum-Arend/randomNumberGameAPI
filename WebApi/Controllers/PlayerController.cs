using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBContexts;
using ClassLibrary;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        // allows us to speak to the database
        private DBContext _dbContext;

        public PlayerController(DBContext context)
        {
            _dbContext = context;
        }

        [HttpGet("info")]
        public IList<Player> Get()
        {
            // What to return?
            return (this._dbContext.Players.ToList());
        }

        [HttpDelete]
        public IList<Player> Delete(int primaryKey)
        {
            var p = this._dbContext.Players.Find(primaryKey);

            if (p == null)
            {
                return this._dbContext.Players.ToList();
            }
            this._dbContext.Players.Remove(p);
            this._dbContext.SaveChangesAsync();

            // What to return?
            return (this._dbContext.Players.ToList());
        }

        [HttpPut]
        public async Task<IList<Player>> AddPlayerAsync(string name)
        {
            var guid = System.Guid.NewGuid();
            var player = new Player(name, guid);

            await this._dbContext.Players.AddAsync(player);
            await this._dbContext.SaveChangesAsync();

            // What to return?
            return _dbContext.Players.ToList();
        }

        [HttpPost]
        public async Task<IList<Player>> UpdatePlayerInfo(string name)
        {

            // Retrieve entity by name
            var entity = _dbContext.Players.FirstOrDefault(item => item.Name == name);

            // Validate entity is not null
            if (entity != null)
            {
                // Make changes on entity
                entity.Name = "BITCHPLZ2";

                // Update entity in DbSet
                this._dbContext.Players.Update(entity);

                // Save changes in database
                await this._dbContext.SaveChangesAsync();
            }

            // What to return?
            return _dbContext.Players.ToList();
        }
    }
}