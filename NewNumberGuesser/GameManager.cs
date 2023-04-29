using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNumberGuesser
{
    public class GameManager
    {
        private Random _random;

        public int MinNumber { get; }
        public int MaxNumber { get;}
        public int AllowedGuesses { get; private set; }
        public int TotalWins { get; private set; }

        public GameManager( int min, int max, int allowedGuesses) 
        {
            MinNumber = min;
            MaxNumber = max;
            AllowedGuesses = allowedGuesses;
            _random = new Random();
        }

        public int GetNextRandomNumber()
        {
            var randomNumber = _random.Next(MinNumber, MaxNumber + 1);
            return randomNumber;
        }

        public void UpdateWin(int newAllowedGuesses)
        {
            //The ++ adds 1 to the current value of TotalWins
            TotalWins++;
            AllowedGuesses = newAllowedGuesses;
        }
    }
}
