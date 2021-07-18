using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary.GameDTO
{
    public class GameInfoDTO
    {
        public int GeneratedCode { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public GameInfoDTO(IGenerateCode code)
        {
            MinRange = 0;
            MaxRange = 100;
            GeneratedCode = code.CreateCode(MinRange,MaxRange);
        }
    }
}
