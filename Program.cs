// See https://aka.ms/new-console-template for more information

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using wordguesser;

Random rnd = new Random();
var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dictionary.txt");
var dictionary = DictionaryLoad.LoadDictionary(path);

Console.WriteLine("Write your name");
var name = Console.ReadLine();
Console.WriteLine("Write room ID");
var room = Console.ReadLine();

var chromeDriver = new SeleniumService($"https://jklm.fun/{room}");
chromeDriver.LoginWithName(name);
chromeDriver.SwitchToFrame();

chromeDriver.JoinGame();

while (true)
{
    if (chromeDriver.IsPlayerTurn())
    {
        var syllable = chromeDriver.GetSyllable();

        var words = ReturnAllPossibleWordsFromList(syllable);
        chromeDriver.SubmitWord(words[rnd.Next(0, words.Count)]);
    }

    Thread.Sleep(100);
}

List<string> ReturnAllPossibleWordsFromList(string syllable)
{
    var words = new List<string>();

    foreach (var item in dictionary)
    {
        if (item.ToLower().Contains(syllable.ToLower()))
        {
            words.Add(item);
        }
    }

    return words;
}
