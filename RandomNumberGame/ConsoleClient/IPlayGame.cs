using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.GameDTO;

namespace ConsoleClient
{
    public interface IPlayGame
    {
        GameInfoDTO StartNewGame();
        void RunGame();
        string Help();
    }
}
