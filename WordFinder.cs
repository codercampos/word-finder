namespace WordFinderApp;

/// <summary>
/// A class that finds words in a matrix of characters.
/// </summary>
public class WordFinder
{
    /// <summary>
    /// Defines the maximum size of the matrix.
    /// </summary>
    private const int MaxSize = 64;
    
    /// <summary>
    /// A 2D array that stores the matrix of characters.
    /// </summary>
    private readonly char[,] _matrix;
    
    public WordFinder(IEnumerable<string> matrix)
    {
        // Let's avoid potential issues with multiple enumerations
        var matrixInput = matrix
            .Select(x => x.ToLower())
            .ToList();
        var size = matrixInput.Count;
        
        if (size > MaxSize || matrixInput.Any(row => row.Length != size || row.Length > MaxSize))
        {
            throw new ArgumentException($"the matrix should not exceed {MaxSize}x{MaxSize} size.");
        }
        
        if (matrixInput.Any(row => row.Length != size)) {
            throw new ArgumentException("All rows in the matrix must have the same length as the number of rows to form a square matrix.");
        }
        
        // Create the matrix with the size We need.
        _matrix = new char[size, size];
        var row = 0;

        // Feel the matrix with the input values.
        foreach (var line in matrixInput)
        {
           for (var col = 0; col < line.Length; col++)
           {
               _matrix[row, col] = line[col];
           }

           row++;
        }
    }
    
    /// <summary>
    /// Processes the word stream and returns the top 10 most found words in the matrix.
    /// </summary>
    /// <returns>The top 10 most repeated words.</returns>
    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        Console.WriteLine("Looking for the words in the matrix...");
        Console.WriteLine($"Started at: {DateTime.Now:O}");
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

        Console.WriteLine($"Started at: {DateTime.Now:O}");
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
        var n = _matrix.GetLength(0);
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
            if (col + word.Length > _matrix.GetLength(1)) return false;
            for (var i = 0; i < word.Length; i++)
            {
                if (_matrix[row, col + i] != word[i])
                    return false;
            }
        }
        else
        {
            // Ensure we do not go out of vertical bounds
            if (row + word.Length > _matrix.GetLength(0)) return false;
            for (var i = 0; i < word.Length; i++)
            {
                if (_matrix[row + i, col] != word[i])
                    return false;
            }
        }
        return true;
    }
}