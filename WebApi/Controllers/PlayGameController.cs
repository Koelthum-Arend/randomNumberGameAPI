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

        [HttpGet("hints")]
        public string GetHints()
        {
                var divisibilityRange = _hints.checkDivisibitlyRange(_gameInfo._generatedCode);
                switch (_player.Hints)
                {
                    case 2:
                        var primality = _hints.IsPrime(divisibilityRange);

                        if (primality.Equals(Response.PRIME))
                        {
                            Console.WriteLine("The mystery code is a prime number.");
                        }

                        else if (primality.Equals(Response.NOT_PRIME))
                        {
                            Console.WriteLine("The mystery code is not a prime number.");
                        }
                        //testing
                        break;

                    case 1:
                        var parity = _hints.checkParity(_gameInfo._generatedCode);

                        if (parity.Equals(Response.EVEN))
                        {
                            Console.WriteLine("The mystery code is an even number");
                        }

                        else if (parity.Equals(Response.ODD))
                        {
                            Console.WriteLine("The mystery code is an odd number");
                        }

                        break;

                    case 0:
                        Console.WriteLine("Sorry, you're all out of hints");
                        break;
                }
                _player.Hints -= 1;

                return default;
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
