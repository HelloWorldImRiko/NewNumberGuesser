namespace NewNumberGuesser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var minNumber = 1;
            var maxNumber = 100;
            var allowedGuesses = 10;

            var manager = new GameManager(minNumber, maxNumber, allowedGuesses);

            WriteLine("Welcome to Number Guesser!");
            WriteLine($"Try to guess my number between {manager.MinNumber} and {manager.MaxNumber}.");

            RunGame(manager);

            if (manager.TotalWins == 1)
                Console.WriteLine($"You won {manager.TotalWins} game against me!");
            else
                Console.WriteLine($"You won {manager.TotalWins} games against me!");

            WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void RunGame(GameManager manager)
        {
            var gameResult = PlayRound(manager);

            if(!gameResult.DidWinGame)
            {
                Console.WriteLine("Better luck next time!");
                return;
            }

            manager.UpdateWin(gameResult.NumberOfGuesses);
            var stillWinning = true;

            while(stillWinning)
            {
                Console.WriteLine("Try to beat me again with the same number of guesses or less!");
                var result = PlayRound(manager);
                stillWinning = result.DidWinGame;

                if(result.DidWinGame)
                    manager.UpdateWin(result.NumberOfGuesses);
            }
        }

        private static GameResult PlayRound(GameManager manager)
        {
            var selectedNumber = manager.GetNextRandomNumber();

            var hasWon = false;
            var guessesLeft = manager.AllowedGuesses;

            while(guessesLeft > 0 && hasWon == false) 
            {
                Console.WriteLine($"Guesses Remaining: {guessesLeft}");
                var guess = Console.ReadLine();

                if(int.TryParse(guess, out var parsedAnswer))
                {
                    if(parsedAnswer < manager.MinNumber || parsedAnswer > manager.MaxNumber)
                    {
                        WriteLine($"The number you guessed was outside my range of {manager.MinNumber} and {manager.MaxNumber}. Please try again.");
                        continue;
                    }

                    if (parsedAnswer > selectedNumber)
                        WriteLine($"You guessed {parsedAnswer}. That is too high.");
                    else if (parsedAnswer < selectedNumber)
                        WriteLine($"You guessed {parsedAnswer}. That is too low.");
                    else
                        hasWon = true;

                    guessesLeft--;
                }
                else
                {
                    WriteLine("Entry invalid. Please enter in a valid non-decimal number.");
                }
            }

            GameResult gameResult;

            if(hasWon)
            {
                var guessesToWin = manager.AllowedGuesses - guessesLeft;
                gameResult = new GameResult(hasWon, guessesToWin);
                WriteLine($"Congratulations! You've won in {guessesToWin} tries! My number was {selectedNumber}.");
            }
            else
            {
                gameResult = new GameResult(hasWon, 0);
                WriteLine($"Sorry! You did not guess my number. It was {selectedNumber}");
            }

            return gameResult;
        }

        private static void WriteLine(string text)
        {
            Console.WriteLine("");
            Console.WriteLine(text);
        }
    }
}