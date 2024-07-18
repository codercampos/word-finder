namespace WordFinderApp;

/// <summary>
/// A class that finds words in a matrix of characters.
/// </summary>
public abstract class BaseWordFinder
{
    /// <summary>
    /// Defines the maximum size of the matrix.
    /// </summary>
    private const int MaxSize = 64;
    
    /// <summary>
    /// A 2D array that stores the matrix of characters.
    /// </summary>
    protected readonly char[,] Matrix;
    
    
    protected BaseWordFinder(IEnumerable<string> matrix)
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
        Matrix = new char[size, size];
        var row = 0;

        // Feel the matrix with the input values.
        foreach (var line in matrixInput)
        {
           for (var col = 0; col < line.Length; col++)
           {
               Matrix[row, col] = line[col];
           }

           row++;
        }
    }

    /// <summary>
    /// Processes the word stream and returns the top 10 most found words in the matrix.
    /// </summary>
    /// <returns>The top 10 most repeated words.</returns>
    public abstract IEnumerable<string> Find(IEnumerable<string> wordStream);
}