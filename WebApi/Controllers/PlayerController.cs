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
        //c:\users\koelta01\documents\github\randomnumbergame\WebApi\Controllers\PlayerController.cs

        // api/Player/info
        [HttpGet("info")]
        public IList<Player> Get()
        {
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

            return (this._dbContext.Players.ToList());
        }

        [HttpPut]
        public async Task<IList<Player>> AddPlayerAsync(string name)
        {
            var guid = System.Guid.NewGuid();
            var player = new Player(name, guid);

            await this._dbContext.Players.AddAsync(player);
            await this._dbContext.SaveChangesAsync();

            return _dbContext.Players.ToList();

        }

        [HttpPost]
        public async Task<IList<Player>> UpdatePlayerInfo(int name)
        {
            var p = this._dbContext.Players.Find(name);
            //query database for row to be updated
            var query =
                from item in _dbContext.Players
                where item.Name.Equals(name)
                select item;

            foreach (Player item in query)
            {
                item.Hints -= 1;
                item.Turns -= 1;
            }

            try
            {
                await _dbContext.SaveChangesAsync();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return _dbContext.Players.ToList();
        }
    }
}