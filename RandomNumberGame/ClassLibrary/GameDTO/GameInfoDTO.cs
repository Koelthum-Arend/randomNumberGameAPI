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
        public int _generatedCode { get; set; }
        public int _minRange { get; set; }
        public int _maxRange { get; set; }

        public GameInfoDTO(IGenerateCode code)
        {
            _minRange = 0;
            _maxRange = 100;
            _generatedCode = code.CreateCode(_minRange,_maxRange);
        }
    }
}
