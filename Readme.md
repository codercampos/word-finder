# Word Finder

## Objective
The objective of this repository is to solve the following problem: Presented with a character matrix and a large stream of words, our task is to create a Class that searches the matrix to look for the words from a word stream. Words may appear horizontally (left to right) or vertically (top to bottom).

The search code must be implemented as a class with the following interface:

```csharp
public class 
{
    public WordFinder(IEnumerable<string> matrix)
    {
        // Implementation here
    }

    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        // Implementation here
    }
}
```

The WordFinder constructor receives a set of strings which represents a character matrix. The
matrix size does not exceed 64x64, all strings contain the same number of characters.

The "Find" method should return the top 10 most repeated words from the word stream found in the matrix. If no words are found, the "Find" method should return an empty set of strings. If any word in the word stream is found more than once within the stream, the search results count it only once.


## Notes
Initially, We created WordFinder class to solve the problem taking care of performance and good practices.

Assuming that this can be use in larger datasets, we implemented a second version of the WordFinder class that uses the Trie algorithm (more information: [here](https://www.geeksforgeeks.org/trie-insert-and-search/)) to improve the search performance.

We, as Software Engineers, should provide different options to solve a problem and decide with the team the best approach.

In this case:
- WordFinder class uses a simple algorithm to review each word in the matrix looking at each character available horizontally and vertically.
- TrieWordFinder class uses the Trie algorithm to improve the search performance.

## Test Information
- .NET SDK: 8.0
- C# 12.0
- Matrix size: 32x32
- Word stream: 'hello', 'world', 'test', 'alpha'