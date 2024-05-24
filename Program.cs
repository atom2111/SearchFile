using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Использование: utility.exe");
            return;
        }

        string directory = args[0];
        string extension = args[1];
        string searchText = args[2];

        SearchFiles(directory, extension, searchText);
    }

    static void SearchFiles(string directory, string extension, string searchText)
    {
        try
        {
            foreach (string file in Directory.GetFiles(directory, $"*.{extension}", SearchOption.AllDirectories))
            {
                if (FileContainsText(file, searchText))
                {
                    Console.WriteLine($"Текст найден в файле: {file}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    static bool FileContainsText(string filePath, string searchText)
    {
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(searchText))
                    {
                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Не удалось прочитать файл {filePath}: {ex.Message}");
        }
        return false;
    }
}
