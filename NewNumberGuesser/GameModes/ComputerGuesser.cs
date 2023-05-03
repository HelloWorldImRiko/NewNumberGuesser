using NewNumberGuesser.Extensions;

namespace NewNumberGuesser.GameModes
{
    /// <summary>
    /// A class holding functionality 
    /// for the computer to try and guess the player's number 
    /// </summary>
    public class ComputerGuesser
    {
        private const int TOO_HIGH_OPT = 1;
        private const int TOO_LOW_OPT = 2;
        private const int CORRECT_GUESS_OPT = 3;

        /// <summary>
        /// For the given <see cref="GameManager"/> instance, 
        /// plays a round where the computer tries to guess the player's number
        /// </summary>
        /// <param name="manager"></param>
        public void RunGame(GameManager manager) 
        {
            var rand = new Random();
            var minGuess = manager.MinNumber;
            var maxGuess = manager.MaxNumber + 1;
            var hasWon = false;
            var guessesRemaining = manager.AllowedGuesses;
            var currentGuess = 0;

            ConsoleExt.WriteSpacedLine($"Pick a number between {manager.MinNumber} and {manager.MaxNumber} and I will try to guess it in {manager.AllowedGuesses} tries.");
            ConsoleExt.WriteSpacedLine("Pick your number and I will start guessing! Press any key when you're ready.");
            Console.ReadKey();

            var options = GetOptions();

            while(!hasWon && guessesRemaining > 0)
            {
                currentGuess = rand.Next(minGuess, maxGuess);
                ConsoleExt.WriteSpacedLine($"I have {guessesRemaining} guesses left. My guess is {currentGuess}. Am I right?");
                ConsoleExt.WriteSpacedLine($"Enter a number:{Environment.NewLine}{options}");

                var enteredOption = GetPlayerResponse(currentGuess);

                if (enteredOption == TOO_HIGH_OPT)
                    maxGuess = currentGuess;
                else if (enteredOption == TOO_LOW_OPT)
                    minGuess = currentGuess + 1;
                else if (enteredOption == CORRECT_GUESS_OPT)
                    hasWon = true;

                guessesRemaining--;
            }

            if (hasWon)
                ConsoleExt.WriteSpacedLine($"I did it! I guessed your number of {currentGuess} in {manager.AllowedGuesses - guessesRemaining} attempt(s)!");
            else
                ConsoleExt.WriteSpacedLine("Dang! I wasn't able to guess your number. Better luck to me next time!");
        }

        private int GetPlayerResponse(int currentGuess)
        {
            var response = Console.ReadLine();
            var successfulSelection = int.TryParse(response, out var enteredOption);

            if (successfulSelection && enteredOption >= TOO_HIGH_OPT && enteredOption <= CORRECT_GUESS_OPT)
                return enteredOption;

            while(!successfulSelection || enteredOption < TOO_HIGH_OPT || enteredOption > CORRECT_GUESS_OPT)
            {
                ConsoleExt.WriteSpacedLine($"I did not understand your response. I guessed {currentGuess}. Please respond with the following:");
                var displayOptions = GetOptions();
                ConsoleExt.WriteSpacedLine(displayOptions);

                var newResponse = Console.ReadLine();
                successfulSelection = int.TryParse(newResponse, out enteredOption);
            }

            return enteredOption;
        }

        private string GetOptions()
        {
            return $"{TOO_HIGH_OPT} - You are too high{Environment.NewLine}" +
                $"{TOO_LOW_OPT} - You are too low{Environment.NewLine}{CORRECT_GUESS_OPT} - You are right!";
        }
    }
}
