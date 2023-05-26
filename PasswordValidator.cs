using System.Text.RegularExpressions;

public static class PasswordValidator
{
    public static bool ValidatePassword(string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            return false;
        }

        var condition = line.Split(':').FirstOrDefault();
        var password = line.Split(':').LastOrDefault()?.Trim();
        var letter = condition![0];

        var rangeFrom = condition.Split('-').FirstOrDefault()?.GetNumber();
        var rangeTo = condition.Split('-').LastOrDefault()?.GetNumber();
        
        var occurrences = password!.Count(x => x == letter);

        return occurrences >= rangeFrom && occurrences <= rangeTo;
    }

    static int GetNumber(this string lineWithNumbers)
    {
        var rangeMatches = Regex.Matches(lineWithNumbers, @"\d+").Select(x =>
        {
            int number;
            int.TryParse(x.Value, out number);
            return number;
        });

        int combinedNumber = 0;
        foreach (int number in rangeMatches)
        {
            combinedNumber = combinedNumber * 10 + number;
        }
        return combinedNumber;
    }
}