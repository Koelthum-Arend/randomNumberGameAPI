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
        int Id { get; set; }
        string Name { get; set; }
        string userGuess { get; set; }
        int Turns { get; set; }
        int Hints { get; set; }
        Status status { get; set; }
        Guid guid { get; set; }
    }
}
