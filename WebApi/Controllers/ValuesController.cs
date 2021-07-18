using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleClient;
using ClassLibrary.Enums;
using ClassLibrary.Interfaces;
using ClassLibrary;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassLibrary.GameDTO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        protected readonly IPlayer _player;
        protected readonly IHints _hints;
        protected readonly IGenerateCode _generateCode;
        protected readonly IValidate _validate;
        protected readonly IPlayGame _playGame;
        protected readonly GameInfoDTO gameInfoDTO;

        public ValuesController(IPlayer Player, IValidate Validate, IHints Hints, IGenerateCode GeneratedCode, IPlayGame playGame)
        {
            _player = Player;
            _hints = Hints;
            _generateCode = GeneratedCode;
            _validate = Validate;
            _playGame = playGame;
        }


        [HttpGet]
        public GameInfoDTO GameInfo()
        {
            return gameInfoDTO;
        }

        //[HttpGet]
        //[Route("playerInfo")]
        //public IPlayer RetrievePlayerInfo(Guid guid)
        //{
            //try
            //{
            //    return _dictionary[guid];
            //}
            //catch (Exception e)
            //{
            //}

            //return default;
        //}

        [HttpPut]
        //public dynamic CreateNewPlayer(string name)
        //{
        //    var newPlayer = new Player(name);
        //    //Guid guid = Guid.NewGuid();
        //    newPlayer.guid = Guid.NewGuid();

            //_dictionary.Add(newPlayer.guid, newPlayer);

            //if (_dictionary.ContainsKey(newPlayer.guid))
            //{
            //   Console.WriteLine( _dictionary[newPlayer.guid]);
            //    return _dictionary[newPlayer.guid];
            //}
                
            //else
            //{
            //    Console.WriteLine("Error");
            //    return "Error";
            //}
        //}

        [HttpPost]
        public IPlayer UpdatePlayerInfo (Guid guid, string key)
        {

            return default;
        }
      

        //private IActionResult View(IPlayer player)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
