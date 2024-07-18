// See https://aka.ms/new-console-template for more information
using WordFinderApp.Processors;
namespace WordFinderApp;

class Program
{
    static void Main(string[] _)
    {
        List<string> matrix =
        [
            "gfwhmkftbmofvjfxvgrljnlworldllra",
            "pvaoxomovvskebyjnlzscmoiiobnrqml",
            "ihfdtifuthljleawktbhhtaakdrucnjp",
            "hellohmsorhkajzkjcsvtjrkvtgphgkh",
            "mqxojasjrrhoecpnmisgjjdgzbuowtva",
            "agxncnmmxmpcbisrrtwijjfuayqtqykc",
            "jncpmckjqrtyfpsygqrhytscqcvjdzzr",
            "vwpsbiinshettsrppnapigupninhobsf",
            "wjgahqwtqlsstlntexkcdxxdlsqurqwb",
            "lgygqmwtbptdyuwnmojhzkiapekiagyz",
            "jqwwqroeudlzvairfoxvsqawnwnmfmbn",
            "nvfjgbesxbetyukkkjhrpfmrnhfussad",
            "ohdobmxtestgdhqvsqhhtsbcxfzsrlyr",
            "cvrbeqdoeloecdmdmfraqcmldpxzslse",
            "mfrwxxshlvcuwyulqsiqdilfktkfbwxb",
            "trjiaijoeccrlwflebroziitfhwuyiya",
            "xvzvdupbwornjjuegvgsncvsawwpajol",
            "wtpjfmgoxubfcsppgdscstnbhnaagknp",
            "qqdlmexdiecplhzqryqhzznkyfmvpnoh",
            "dlrtsxliiaqkovvhhzcyflrfqzfkjuta",
            "wcpfhfteyprdnwdljwemqlhtkhellobz",
            "ksucfcnweeypdpihkwkheryjfrhedxzr",
            "tocgworldslcvofcbtmsdsjerldqklgt",
            "vjwzjmyiaiwwzuaggpgdmlhmpmlrcypf",
            "xscbjknbyoioqlyaruoitwudvhspeljp",
            "sounedpoatlpxutafcadskqqtrenscxl",
            "fhvigfzvzcpnbscvgdcxobwvpddrwrjx",
            "ntungyqjgamswezjebzuwbmnplhlooky",
            "ykylprkphnmxlxueuudzrbnknqearqhz",
            "wbklxbyyfxbahwdjzntofxrssgldlnah",
            "eqtdvltitucnyijjckerxpmxfilpdeff",
            "cszipenoabiiaxmvccelxpagxbokegdz"
        ];

        List<string> wordStream = ["hello", "world", "test", "alpha"];
        
        try
        {
            // Let's use the basic word finder.
            BaseWordFinder wordFinder = new WordFinder(matrix);
            List<string> wordsFound = wordFinder.Find(wordStream).ToList();
            ProcessWordsFound(wordsFound);
            
            // Blank space to separate both tests
            Console.WriteLine("");
            
            // Let's use the trie word finder. This one is faster.
            // Tries efficiently store and search for strings over a fixed alphabet and are particularly useful for tasks involving prefixes.
            // More information: https://www.geeksforgeeks.org/trie-insert-and-search/
            wordFinder = new TrieWordFinder(matrix);
            wordsFound = wordFinder.Find(wordStream).ToList();
            ProcessWordsFound(wordsFound);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static void ProcessWordsFound(IList<string> wordsFound)
    {
        if (wordsFound.Any())
        {
            Console.WriteLine("Found words:");
            foreach (var word in wordsFound)
            {
                Console.WriteLine(word);
            }
        }
        else
        {
            Console.WriteLine("No words found.");
        }
    }
}