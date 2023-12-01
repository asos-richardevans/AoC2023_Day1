using System.Diagnostics;

var input = File.ReadAllLines("./input.txt");
var numberStrings = new List<string>{ "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
var total = 0;
var sw = new Stopwatch();
sw.Start();
foreach (var line in input)
{
    total += GetNewNumber(line);
}
sw.Stop();
Console.WriteLine(sw.Elapsed);
Console.WriteLine(total);

int GetNewNumber(string line)
{
    var cn1 = GetFirstNumber(line);
    var cn2 = GetLastNumber(line);
    var sn1 = GetFirstStringNumber(line);
    var sn2 = GetLastStringNumber(line);
    var n1 = (cn1.Item2 < sn1.Item2 ? cn1.Item1 : sn1.Item1).ToString();
    var n2 = (cn2.Item2 > sn2.Item2 ? cn2.Item1 : sn2.Item1).ToString();
    return int.Parse(n1 + n2);
}

static (int,int) GetFirstNumber(string line)
{
    var c = line.ToCharArray().FirstOrDefault(char.IsDigit);
    var i = line.IndexOf(c);
    return (int.Parse(c.ToString()), i < 0 ? int.MaxValue : i);
}

static (int, int) GetLastNumber(string line)
{
    var c = line.ToCharArray().LastOrDefault(char.IsDigit);
    var i = line.LastIndexOf(c);
    return (int.Parse(c.ToString()), i < 0 ? int.MinValue : i);
}

(int, int) GetFirstStringNumber(string line)
{
    int lowestIndex = int.MaxValue;
    int number = 0;
    foreach (var numberString in numberStrings)
    {
        var i = line.IndexOf(numberString);
        if (i >= 0 && i < lowestIndex)
        {
            lowestIndex = i;
            number = numberStrings.IndexOf(numberString) + 1;
        }
    }
    return (number, lowestIndex);
}

(int, int) GetLastStringNumber(string line)
{
    int highestIndex = int.MinValue;
    int number = 0;
    foreach (var numberString in numberStrings)
    {
        var i = line.LastIndexOf(numberString);
        if (i >= 0 && i > highestIndex)
        {
            highestIndex = i;
            number = numberStrings.IndexOf(numberString) + 1;
        }
    }
    return (number, highestIndex);
}