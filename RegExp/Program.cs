using System.Text.RegularExpressions;

namespace RegExp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Matching any mr or ms or any other title and removing it from list
            string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
            string[] names = { "Mr. Virat Kohli", "Ms. Hande Ercel",
                         "Arjuna", "Mr. 360" };
            foreach (string name in names)
                Console.WriteLine(Regex.Replace(name, pattern, String.Empty));

            // 2. Matching duplicates in text
            string pattern1 = @"\b(\w+?)\s\1\b";
            string input = "This this is a nice day. What about this? This tastes good. I saw a a dog.";
            foreach (Match match in Regex.Matches(input, pattern1, RegexOptions.IgnoreCase))
                Console.WriteLine("{0} (duplicates '{1}') at position {2}",
                                  match.Value, match.Groups[1].Value, match.Index);

        }
    }
}
