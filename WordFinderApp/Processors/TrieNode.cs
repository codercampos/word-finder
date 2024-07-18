namespace WordFinderApp.Processors;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children = new();
    public bool IsEndOfWord = false;

    public void Insert(string word)
    {
        TrieNode current = this;
        foreach (char ch in word)
        {
            if (!current.Children.ContainsKey(ch))
            {
                current.Children[ch] = new TrieNode();
            }
            current = current.Children[ch];
        }
        current.IsEndOfWord = true;
    }
}