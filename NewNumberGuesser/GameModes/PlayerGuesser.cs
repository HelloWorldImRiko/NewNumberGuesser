using NewNumberGuesser.Extensions;

namespace NewNumberGuesser.GameModes
{
    /// <summary>
    /// A class holding functionality
    /// for the computer to pick a random number and make the player guess said number
    /// </summary>
    public class PlayerGuesser
    {
        /// <summary>
        /// For the given <see cref="GameManager"/> instance,
        /// plays multiple rounds of the game where the player tries to guess the computer's number
        /// </summary>
        /// <param name="manager"></param>
        public void RunGame(GameManager manager)
        {
            ConsoleExt.WriteSpacedLine($"Try to guess my number between {manager.MinNumber} and {manager.MaxNumber}.");

            var gameResult = PlayRound(manager);

            if (!gameResult.DidWinGame)
            {
                Console.WriteLine("Better luck next time!");
                return;
            }

            manager.UpdateWin(gameResult.NumberOfGuesses);
            var stillWinning = true;

            while (stillWinning)
            {
                Console.WriteLine("Try to beat me again with the same number of guesses or less!");
                var result = PlayRound(manager);
                stillWinning = result.DidWinGame;

                if (result.DidWinGame)
                    manager.UpdateWin(result.NumberOfGuesses);
            }

            if (manager.TotalWins == 1)
                Console.WriteLine($"You won {manager.TotalWins} game against me!");
            else
                Console.WriteLine($"You won {manager.TotalWins} games against me!");
        }

        private GameResult PlayRound(GameManager manager)
        {
            var selectedNumber = manager.GetNextRandomNumber();

            var hasWon = false;
            var guessesLeft = manager.AllowedGuesses;

            while (guessesLeft > 0 && hasWon == false)
            {
                Console.WriteLine($"Guesses Remaining: {guessesLeft}");
                var guess = Console.ReadLine();

                if (int.TryParse(guess, out var parsedAnswer))
                {
                    if (parsedAnswer < manager.MinNumber || parsedAnswer > manager.MaxNumber)
                    {
                        ConsoleExt.WriteSpacedLine($"The number you guessed was outside my range of {manager.MinNumber} and {manager.MaxNumber}. Please try again.");
                        continue;
                    }

                    if (parsedAnswer > selectedNumber)
                        ConsoleExt.WriteSpacedLine($"You guessed {parsedAnswer}. That is too high.");
                    else if (parsedAnswer < selectedNumber)
                        ConsoleExt.WriteSpacedLine($"You guessed {parsedAnswer}. That is too low.");
                    else
                        hasWon = true;

                    guessesLeft--;
                }
                else
                {
                    ConsoleExt.WriteSpacedLine("Entry invalid. Please enter in a valid non-decimal number.");
                }
            }

            GameResult gameResult;

            if (hasWon)
            {
                var guessesToWin = manager.AllowedGuesses - guessesLeft;
                gameResult = new GameResult(hasWon, guessesToWin);
                ConsoleExt.WriteSpacedLine($"Congratulations! You've won in {guessesToWin} tries! My number was {selectedNumber}.");
            }
            else
            {
                gameResult = new GameResult(hasWon, 0);
                ConsoleExt.WriteSpacedLine($"Sorry! You did not guess my number. It was {selectedNumber}");
            }

            return gameResult;
        }
    }
}
