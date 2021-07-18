using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Enums;

namespace ClassLibrary.GameDTO
{
    public class PlayerDTO
    {
        //create interfaces 
        // create a class with all initialized data
        private string _Name { get; set; }
        private string _userGuess { get; set; }
        private int Turns { get; set; }
        private int Hints { get; set; }
        private Status Status {get; set;}

        public PlayerDTO(string Name, string userGuess)
        {
            _Name = Name;
            _userGuess = userGuess;
            Turns = 5;
            Hints = 2;
            Status = Status.READY;
        }
    }
}
