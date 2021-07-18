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

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        protected readonly IPlayer _player;
        //protected readonly IHints _hints;
        //protected readonly IGenerateCode _generateCode;
        //protected readonly IValidate _validate;

        public ValuesController(IPlayer Player, IValidate Validate, IHints Hints, IGenerateCode GeneratedCode)
        {
            _player = Player;
            //_hints = Hints;
            //_generateCode = GeneratedCode;
            //_validate = Validate;
        }

        [HttpGet]
        public IPlayer Index()
        {
            _player.Turns = 5;
            Console.WriteLine(_player.Turns);
            return _player;
       }

        //private IActionResult View(IPlayer player)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
