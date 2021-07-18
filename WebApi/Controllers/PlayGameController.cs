using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBContexts;
using ClassLibrary;
using ClassLibrary.Interfaces;
using ConsoleClient;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayGameController : ControllerBase
    {
        private DBContext _dbContext;
        private IHints _hints;
        private IPlayer _player;
        private IValidate _validate;
        private IGenerateCode _code;
        private IPlayGame _game;
        public PlayGameController(DBContext context, IHints hint, IPlayer player, IValidate validate, IGenerateCode code, IPlayGame game)
        {
            _dbContext = context;
            _hints = hint;
            _player = player;
            _validate = validate;
            _code = code;
            _game = game;
        }

        [HttpGet("playgame")]
        public async Task<IList<Player>> Play(string guess)
        {


            //var game = PlayGame(_player, _hints, _validate, _code);
            
            var game = _game.RunGame();
            game.userGuess = guess;

            return null;
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
    }
}
