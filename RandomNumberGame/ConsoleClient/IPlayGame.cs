using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.GameDTO;
using ClassLibrary.Interfaces;

namespace ConsoleClient
{
    public interface IPlayGame
    {
        GameInfoDTO StartNewGame();
        IPlayer RunGame();
        string Help();
    }
}
