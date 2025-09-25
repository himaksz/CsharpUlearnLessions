namespace Cond2;

public static class Cond2
{
    public static void Result()
    {
        var (x, y, z, a, b) = InputData();

        var pairs = new[]
        {
            new[] { x, y },
            new[] { x, z },
            new[] { y, z }
        };

        // Проверка, пролезет ли брус (каюсь, Rider предложил вариант такой)
        var canPass = pairs.Any(pair => (pair[0] <= a && pair[1] <= b) || (pair[0] <= b && pair[1] <= a));

        Console.WriteLine($"Брус {(canPass ? "пройдет" : "не пройдет")} через отверстие.");
    }

    private static (int x, int y, int z, int a, int b) InputData()
    {
        Console.WriteLine("Введите стороны бруса (x y z):");
        var sidesInput = Console.ReadLine()!.Split(' ');
        var x = int.Parse(sidesInput[0]);
        var y = int.Parse(sidesInput[1]);
        var z = int.Parse(sidesInput[2]);

        Console.WriteLine("Введите стороны отверстия (a b):");
        var holeInput = Console.ReadLine()!.Split(' ');
        var a = int.Parse(holeInput[0]);
        var b = int.Parse(holeInput[1]);

        return (x, y, z, a, b);
    }
}