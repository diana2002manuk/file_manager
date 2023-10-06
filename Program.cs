using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        FileManager fileManager = new FileManager();
        fileManager.Run();
    }
}

class FileManager
{
    public void Run()
    {
        Console.Write("Введите путь к папке: ");
        string folderPath = Console.ReadLine();

        if (Directory.Exists(folderPath))
        {
            Console.WriteLine("Содержимое папки:");
            ListContents(folderPath);

            Console.WriteLine("\n1. Создать файл");
            Console.WriteLine("2. Создать папку");
            Console.Write("Выберите действие (1/2): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateFile(folderPath);
            }
            else if (choice == "2")
            {
                CreateFolder(folderPath);
            }
        }
        else
        {
            Console.WriteLine("Папка не существует.");
        }
    }

    public void ListContents(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath);
        string[] directories = Directory.GetDirectories(folderPath);

        Console.WriteLine("Файлы:");
        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file));
        }

        Console.WriteLine("\nПапки:");
        foreach (string directory in directories)
        {
            Console.WriteLine(Path.GetFileName(directory));
        }
    }

    public void CreateFile(string folderPath)
    {
        Console.Write("Введите имя файла: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(folderPath, fileName);
        File.Create(filePath).Close();
        Console.WriteLine($"Файл '{fileName}' успешно создан.");
    }

    public void CreateFolder(string folderPath)
    {
        Console.Write("Введите имя папки: ");
        string folderName = Console.ReadLine();
        string folderPathToCreate = Path.Combine(folderPath, folderName);
        Directory.CreateDirectory(folderPathToCreate);
        Console.WriteLine($"Папка '{folderName}' успешно создана.");
    }
}