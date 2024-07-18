namespace WordFinderApp.Processors;

public class WordFinder(IEnumerable<string> matrix) : BaseWordFinder(matrix)
{
    public override IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        var initialTime = DateTime.Now;
        Console.WriteLine("==============================");
        Console.WriteLine("Looking for the words in the matrix...");
        Console.WriteLine("==============================");
        Console.WriteLine($"Started at: {initialTime:O}");
        
        var foundWords = new Dictionary<string, int>();
        foreach (var word in wordStream.Distinct())
        {
            // Make sure that the word we are looking is in lowercase.
            var count = FindWordOccurrences(word.ToLower());
            if (count > 0)
            {
                foundWords[word] = count;
            }
        }

        var endTime = DateTime.Now;
        Console.WriteLine($"Finished at: {endTime:O}");
        Console.WriteLine($"Total time: {(endTime - initialTime).TotalMicroseconds} ms");
        Console.WriteLine("==============================");
        return foundWords.OrderByDescending(kvp => kvp.Value)
            .Take(10)
            .Select(kvp => kvp.Key);
    }
    
    /// <summary>
    /// This helper sums the occurrences of a word found horizontally and vertically.
    /// </summary>
    /// <param name="word">The word we need to lookup into the matrix.</param>
    /// <returns>The number of occurrences found.</returns>
    private int FindWordOccurrences(string word)
    {
        return FindWordInDirection(word, true) + FindWordInDirection(word, false);
    }

    /// <summary>
    /// Finds the occurrences of a word in a specified direction.
    /// </summary>
    private int FindWordInDirection(string word, bool isHorizontal)
    {
        var count = 0;
        var n = Matrix.GetLength(0);
        var m = word.Length;

        if (isHorizontal)
        {
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j <= n - m; j++)
                {
                    if (IsMatch(i, j, word, isHorizontal))
                    {
                        count++;
                    }
                }
            }
        }
        else
        {
            for (var i = 0; i <= n - m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (IsMatch(i, j, word, isHorizontal))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
    
    /// <summary>
    /// Checks if a word matches in the specified direction starting from the given position.
    /// </summary>
    private bool IsMatch(int row, int col, string word, bool isHorizontal)
    {
        if (isHorizontal)
        {
            // Ensure we do not go out of horizontal bounds
            if (col + word.Length > Matrix.GetLength(1)) return false;
            for (var i = 0; i < word.Length; i++)
            {
                if (Matrix[row, col + i] != word[i])
                    return false;
            }
        }
        else
        {
            // Ensure we do not go out of vertical bounds
            if (row + word.Length > Matrix.GetLength(0)) return false;
            for (var i = 0; i < word.Length; i++)
            {
                if (Matrix[row + i, col] != word[i])
                    return false;
            }
        }
        return true;
    }
}