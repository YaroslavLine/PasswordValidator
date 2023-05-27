using System.Text.RegularExpressions;

public static class FileHelper
{
    public static bool IsValidFilePath(string filePath)
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
}