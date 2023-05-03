namespace NewNumberGuesser
{
    /// <summary>
    /// Class for managing the current state of the game
    /// </summary>
    public class GameManager
    {
        private Random _random;

        /// <summary>
        /// The min number that can be guessed for the Number Guesser
        /// </summary>
        public int MinNumber { get; }

        /// <summary>
        /// The max number that can be guessed for the number guesser
        /// </summary>
        public int MaxNumber { get;}

        /// <summary>
        /// The total number of allowed guesses that a player is allowed
        /// </summary>
        public int AllowedGuesses { get; private set; }

        /// <summary>
        /// The cumulative number of wins across multiple rounds of the Number Guesser game
        /// </summary>
        public int TotalWins { get; private set; }

        /// <summary>
        /// Instantiates a new instance of the <see cref="GameManager"/> class
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="allowedGuesses"></param>
        public GameManager( int min, int max, int allowedGuesses) 
        {
            MinNumber = min;
            MaxNumber = max;
            AllowedGuesses = allowedGuesses;
            _random = new Random();
        }

        /// <summary>
        /// Grabs a new random number between the <see cref="MinNumber"/> and <see cref="MaxNumber"/>
        /// </summary>
        /// <returns></returns>
        public int GetNextRandomNumber()
        {
            var randomNumber = _random.Next(MinNumber, MaxNumber + 1);
            return randomNumber;
        }

        /// <summary>
        /// Increments the <see cref="TotalWins"/> property and updates the <see cref="AllowedGuesses"/> property
        /// </summary>
        /// <param name="newAllowedGuesses">new number of allowed guesses for a round</param>
        public void UpdateWin(int newAllowedGuesses)
        {
            //The ++ adds 1 to the current value of TotalWins
            TotalWins++;
            AllowedGuesses = newAllowedGuesses;
        }
    }
}
