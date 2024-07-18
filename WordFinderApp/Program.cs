// See https://aka.ms/new-console-template for more information

using WordFinderApp;

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
List<string> wordsFound = [];

try
{
    WordFinder wordFinder = new WordFinder(matrix);
    wordsFound = wordFinder.Find(wordStream).ToList();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

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
