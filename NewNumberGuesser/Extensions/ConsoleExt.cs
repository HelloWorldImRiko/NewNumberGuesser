namespace NewNumberGuesser.Extensions
{
    /// <summary>
    /// Convenience class providing extended functionality of the console
    /// </summary>
    public static class ConsoleExt
    {
        /// <summary>
        /// Writes out a blank line followed by a line of text
        /// </summary>
        /// <param name="text"></param>
        public static void WriteSpacedLine(string text)
        {
            Console.WriteLine("");
            Console.WriteLine(text);
        }
    }
}
