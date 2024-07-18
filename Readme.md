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


