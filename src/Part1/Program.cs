var input = File.ReadAllLines("./input.txt");

var total = 0;

foreach (var line in input)
{
    total += int.Parse(GetFirstNumber(line) + GetLastNumber(line));
}

Console.WriteLine(total);

static string GetFirstNumber(string line)
{
    return line.ToCharArray().First(char.IsDigit).ToString();
}

static string GetLastNumber(string line)
{
    return line.ToCharArray().Last(char.IsDigit).ToString();
}