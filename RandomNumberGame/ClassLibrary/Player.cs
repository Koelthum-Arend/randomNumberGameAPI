using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Enums;
using ClassLibrary.Interfaces;
namespace ClassLibrary
{
    public class Player : IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string userGuess { get; set; }
        public int Turns { get; set; }
        public int Hints { get; set; }
        public Status status { get; set; }
        public Guid guid { get; set; }

        //public IDictionary<string, dynamic> PlayerDetails { get; set; }
        //var dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        public Player(string name, Guid newGuid)
        { 
            Name = name;
            //this.userGuess = userGuess;
            Turns = 5;
            Hints = 2;
            status = Status.READY;
            guid = newGuid; 
        }

        public Player()
        {
            Turns = 5;
            Hints = 2;
        }
        //public IDictionary<string, dynamic> addPlayerDetails(Status status)
        //{
        //    PlayerDetails.Add("Name", Name);
        //    PlayerDetails.Add("Turns Remaining", Turns);
        //    PlayerDetails.Add("Hints Remaining", Hints);
        //    PlayerDetails.Add("Status", status);

        //    return PlayerDetails;
        //}

        //public IDictionary<string, dynamic> updatePlayerDetails(int Turns, int Hints, Status status)
        //{
        //    if (PlayerDetails.ContainsKey("Turns Remaining"))
        //        PlayerDetails["Turns Remaining"] = Turns;

        //    if (PlayerDetails.ContainsKey("Hints Remaining"))
        //        PlayerDetails["Hints Remaing"] = Hints;

        //    if (PlayerDetails.ContainsKey("Status"))
        //        PlayerDetails["Status"] = status;

        //    return PlayerDetails;
        //}
    }
}
