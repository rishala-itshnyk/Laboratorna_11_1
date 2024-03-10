using System;
using System.IO;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть ім'я вихідного файлу:");
        string outputFileName = Console.ReadLine();

        Generate(outputFileName);
        Process(outputFileName);
        Print();

        Console.WriteLine("Операція завершена успішно.");
    }

    public static void Generate(string fileName)
    {
        try
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(fileName)))
            {
                Console.WriteLine("Введіть цілі числа (для завершення введення введіть 'exit'):");

                while (true)
                {
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                        break;

                    if (int.TryParse(input, out int number))
                    {
                        writer.Write(number);
                    }
                    else
                    {
                        Console.WriteLine($"Увага: Невірний формат числа: {input}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при генерації даних: {ex.Message}");
        }
    }

    public static void Process(string inputFileName)
    {
        try
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(inputFileName)))
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite("result.dat")))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();
                    double squareRoot = Math.Sqrt(number);
                    if (squareRoot % 1 == 0)
                    {
                        writer.Write(number);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при опрацюванні файлів: {ex.Message}");
        }
    }

    public static void Print()
    {
        try
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead("result.dat")))
            {
                Console.WriteLine("Результати обчислень:");

                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();
                    Console.WriteLine(number);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при виведенні результатів: {ex.Message}");
        }
    }
}
