using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNumberGuesser
{
    /// <summary>
    /// An object representing the end result of a number guessing game
    /// </summary>
    internal class GameResult
    {
        /// <summary>
        /// Whether or not the player won the game
        /// </summary>
        public bool DidWinGame { get; }

        /// <summary>
        /// The number of guesses it took to win
        /// </summary>
        public int NumberOfGuesses { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="GameResult"/> class
        /// </summary>
        /// <param name="didWinGame"></param>
        /// <param name="numberOfGuesses"></param>
        public GameResult(bool didWinGame, int numberOfGuesses)
        {
            DidWinGame = didWinGame;
            NumberOfGuesses = numberOfGuesses;
        }
    }
}
