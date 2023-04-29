using NewNumberGuesser.Extensions;
using NewNumberGuesser.GameModes;

namespace NewNumberGuesser
{
    internal class Program
    {
        private const int PLAYER_GUESSER = 1;
        private const int COMPUTER_GUESSER = 2;

        static void Main(string[] args)
        {
            var minNumber = 1;
            var maxNumber = 100;
            var allowedGuesses = 10;

            var manager = new GameManager(minNumber, maxNumber, allowedGuesses);

            ConsoleExt.WriteSpacedLine("Welcome to Number Guesser!");

            var gameMode = SelectGameMode();

            if(gameMode == PLAYER_GUESSER)
            {
                var playerGuesser = new PlayerGuesser();
                playerGuesser.RunGame(manager);
            }
            else if (gameMode == COMPUTER_GUESSER)
            {
                var computerGuesser = new ComputerGuesser();
                computerGuesser.RunGame(manager);
            }

            ConsoleExt.WriteSpacedLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static int SelectGameMode()
        {
            ConsoleExt.WriteSpacedLine($"Select your style of game.{Environment.NewLine}{GetOptions()}");
            var successful = int.TryParse(Console.ReadLine(), out var selectedOption);

            if (successful && (selectedOption == PLAYER_GUESSER || selectedOption == COMPUTER_GUESSER))
                return selectedOption;

            while (!successful || selectedOption < PLAYER_GUESSER || selectedOption > COMPUTER_GUESSER)
            {
                ConsoleExt.WriteSpacedLine("I'm sorry. Please try making your selection again.");
                ConsoleExt.WriteSpacedLine(GetOptions());
                successful = int.TryParse(Console.ReadLine(), out selectedOption);
            }

            return selectedOption;
        }

        private static string GetOptions()
        {
            return $"{PLAYER_GUESSER} - Guess the computer's number{Environment.NewLine}{COMPUTER_GUESSER} - The computer guesses your number";
        }
    }
}