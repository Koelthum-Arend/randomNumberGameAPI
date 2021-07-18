using ClassLibrary.GameDTO;
using ClassLibrary.Interfaces;
using ClassLibrary.Enums;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class PlayGame : IPlayGame
    {
        public bool correct = false;
        private IPlayer _player { get; set; }
        private IHints _hints { get; set; }
        private IValidate _validate { get; set; }
        private GameInfoDTO _gameInfo { get; set; }
        private IGenerateCode _code { get; set; }
        public PlayGame()
        {
            _player = new Player();
            _hints = new Hints();
            _validate = new Validate();
            _code = new GenerateCode();
            _gameInfo = new GameInfoDTO(_code);
    }
        public void RunGame()
        {
            while (_player.Turns >= 0)
            {
                if (_player.Turns == 5)
                {
                    Console.WriteLine("Welcome to Guess the mystery Code Game\nA mystery code has been generated and you have 5 turns to guess it!\nYou have 2 hints, good luck! ");
                    Console.WriteLine("Name: ");
                   _player.Name = Console.ReadLine();
                }

                Console.WriteLine("Crack the code: ");
                _player.userGuess = Console.ReadLine().ToLower();
                int _userCode;
                bool IsDigit = int.TryParse(_player.userGuess, out _userCode);


                if (_player.userGuess.Equals("quit"))
                {
                    Console.WriteLine($"Bye-Bye {char.ToUpper(_player.Name[0]) + _player.Name.Substring(1)}, better luck next time!\nThe mystery code was: {_gameInfo.GeneratedCode}");
                    _player.status = Status.QUIT;
                    break;
                }

                else if (_player.userGuess.Equals("help"))
                {
                    Console.WriteLine(Help());
                    _player.status = Status.HELP;
                }

                else if (_player.Turns == 0)
                {
                    Console.WriteLine($"Sorry {_player.Name}, you're all out of turns :(.\nThe mystery code was: {_gameInfo.GeneratedCode}\nBetter luck next time");
                }

                else if (_player.userGuess.Equals("hint"))
                {
                    _player.status = Status.HINT;
                    var divisibilityRange = _hints.checkDivisibitlyRange(_gameInfo.GeneratedCode);
                    switch (_player.Hints)
                    {
                        case 2:
                            var primality = _hints.IsPrime(divisibilityRange);

                            if (primality.Equals(Response.PRIME))
                            {
                                Console.WriteLine("The mystery code is a prime number.");
                            }

                            else if (primality.Equals(Response.NOT_PRIME))
                            {
                                Console.WriteLine("The mystery code is not a prime number.");
                            }

                            break;

                        case 1:
                            var parity = _hints.checkParity(_gameInfo.GeneratedCode);

                            if (parity.Equals(Response.EVEN))
                            {
                                Console.WriteLine("The mystery code is an even number");
                            }

                            else if (parity.Equals(Response.ODD))
                            {
                                Console.WriteLine("The mystery code is an odd number");
                            }

                            break;

                        case 0:
                            Console.WriteLine("Sorry, you're all out of hints");
                            break;
                    }
                    _player.Hints -= 1;
                }

                else if (IsDigit == true)
                {
                    var status = _validate.ExecuteValidation(_player.userGuess, _gameInfo.GeneratedCode);
                    switch (status)
                    {
                        case Status.CORRECT:
                            Console.WriteLine($"Congratulations {_player.Name}, you've cracked the code!\nThe mystery code was: {_gameInfo.GeneratedCode}");
                            _player.status = Status.CORRECT;
                            break;

                        case Status.TOO_HIGH:
                            Console.WriteLine($"Incorrect! Sorry {_player.Name}, your guess is too high");
                            _player.status = Status.INCORRECT;
                            break;

                        case Status.TOO_LOW:
                            Console.WriteLine($"Incorrect! Sorry {_player.Name}, your guess is too low");
                            _player.status = Status.INCORRECT;
                            break;
                    }
                }

                else
                {
                    _player.status = Status.INVALID;
                    Console.WriteLine("INVALID GUESS!\n");
                    Console.WriteLine(Help());
                }
                _player.Turns -= 1;
            }
        }

        public GameInfoDTO StartNewGame()
        {
            throw new NotImplementedException();
        }

        public string Help()
        {
            return "~~RANDOM NUMBER GAME~~";
        }
    }
}
