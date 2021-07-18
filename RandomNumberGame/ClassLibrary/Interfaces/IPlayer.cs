using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Enums;

namespace ClassLibrary.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        string userGuess { get; set; }
        int Turns { get; set; }
        int Hints { get; set; }
        Status status { get; set; }

        IDictionary<string, dynamic> PlayerDetails { get; set; }

        IDictionary<string, dynamic> addPlayerDetails(Status status);
        IDictionary<string, dynamic> updatePlayerDetails(int Turns, int Hints, Status status);
    }
}
