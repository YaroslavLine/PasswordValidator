using System.Text.RegularExpressions;

string selectedFilePath;

while (true)
{
    Console.WriteLine("\nEnter the path of the selected file:");
    selectedFilePath = Console.ReadLine()!;

    if (selectedFilePath != null && IsValidFilePath(selectedFilePath))
    {
        Console.WriteLine("Selected File: " + selectedFilePath);
    }
    else
    {
        Console.WriteLine("Invalid file path or file does not exist.");
        continue;
    }

    var lines = File.ReadAllLines(selectedFilePath!);

    if (lines == null || !lines.Any())
    {
        Console.WriteLine("Selected file is empty.");
        continue;
    }

    var validPasswordsCount = lines.Where(line => PasswordValidator.ValidatePassword(line)).Count();

    Console.WriteLine($"Count of valid passwords: {validPasswordsCount}");
    Console.WriteLine("Do you want to continue? y/n");

    var pressedKey = Console.ReadKey();
    if (pressedKey.KeyChar != 'y' || pressedKey.KeyChar != 'Y')
    {
        return;
    }
}

static bool IsValidFilePath(string filePath)
{
    try
    {
        if (!Regex.IsMatch(filePath, @"^[a-zA-Z]:\\"))
        {
            return false;
        }

        return File.Exists(filePath);
    }
    catch
    {
        return false;
    }
}