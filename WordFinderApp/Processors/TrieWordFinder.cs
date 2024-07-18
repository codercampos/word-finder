namespace WordFinderApp.Processors;

public class TrieWordFinder(IEnumerable<string> matrix) : BaseWordFinder(matrix)
{
    private readonly TrieNode _root = new();

    public override IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        var initialTime = DateTime.Now;
        Console.WriteLine("==============================");
        Console.WriteLine("Looking for the words in the matrix using trie...");
        Console.WriteLine("==============================");
        Console.WriteLine($"Started using trie at: {initialTime:O}");
        
        foreach (var word in wordStream)
        {
            _root.Insert(word.ToLower());
        }

        var foundWords = new Dictionary<string, int>();

        // Search in every possible direction
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                CollectWords(i, j, true, foundWords);
                CollectWords(i, j, false, foundWords);
            }
        }

        var endTime = DateTime.Now;
        Console.WriteLine($"Finished using trie at: {endTime:O}");
        Console.WriteLine($"Total time: {(endTime - initialTime).TotalMicroseconds} ms");
        Console.WriteLine("==============================");
        return foundWords.OrderByDescending(kvp => kvp.Value)
            .Take(10)
            .Select(kvp => kvp.Key);
    }

    private void CollectWords(int row, int col, bool isHorizontal, Dictionary<string, int> foundWords)
    {
        TrieNode node = _root;
        string word = "";
        int length = isHorizontal ? Matrix.GetLength(1) : Matrix.GetLength(0);
        int limit = isHorizontal ? length - col : length - row;

        for (int i = 0; i < limit; i++)
        {
            char currentChar = isHorizontal ? Matrix[row, col + i] : Matrix[row + i, col];
            if (!node.Children.TryGetValue(currentChar, out var child))
                break;

            node = child;
            word += currentChar;

            if (node.IsEndOfWord)
            {
                foundWords.TryAdd(word, 0);
                foundWords[word]++;
            }
        }
    }
}