namespace Cond1;

public static class Cond1
{
    public static void Result()
    {
        /*
         * Заметил, что почему-то в этом проекте, который был на .NET 7 (делал в аудитории),
         * после распаковки и смены версии (дома за своим ПК) на последнюю (.NET 9) - полетел инпут через консоль,
         * почему-то когда начинаю писать, то текст наслаивается на выведенную строку,
         * поэтому я добавил "\n", вроде как помогло...
         * Может Rider просто решил затроллить, в JetBrain'овских IDE'шках в терминалах иногда бывают такие приколы...
         */ 
        Console.WriteLine("Введите фигуру (пешка, ладья, слон, конь, король, ферзь):\n");
        var piece = Console.ReadLine()!.ToLower();

        Console.WriteLine("Введите начальную клетку (например, a1):\n");
        var from = Console.ReadLine()!.ToLower();

        Console.WriteLine("Введите конечную клетку (например, h8):\n");
        var to = Console.ReadLine()!.ToLower();

        var isCorrect = IsCorrectMotion(piece, from, to);
        Console.WriteLine($"{piece} {from}-{to} корректный ход? {(isCorrect ? "Да" : "Нет")}");

    }

    private static bool IsCorrectMotion(string piece, string from, string to)
    {
        var fromX = from[0] - 'a';
        var fromY = from[1] - '1';
        var toX = to[0] - 'a';
        var toY = to[1] - '1';

        var dx = Math.Abs(toX - fromX);
        var dy = Math.Abs(toY - fromY);

        switch (piece)
        {
            case "ладья":
                return (dx == 0 && dy != 0) || (dy == 0 && dx != 0);
            case "слон":
                return dx == dy && dx != 0;
            case "конь":
                return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
            case "король":
                return (dx <= 1 && dy <= 1) && !(dx == 0 && dy == 0);
            case "пешка":
                var forwardMove = fromX == toX && ((fromY == 1 && dy <= 2) || dy == 1) && (toY > fromY);
                var captureMove = dx == 1 && dy == 1 && toY > fromY;
                return forwardMove || captureMove;
            case "ферзь":
                return ((dx == dy && dx != 0) || (dx == 0 && dy != 0) || (dy == 0 && dx != 0));
            default:
                Console.WriteLine("Неизвестная фигура!");
                return false;
        }
    }
}