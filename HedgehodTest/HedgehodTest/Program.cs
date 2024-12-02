class Hedgehogs
{
    public static int MinMeetings(int[] hedgehogs, int desiredcolor)
    {
        if (hedgehogs.Length != 3) throw new ArgumentException("Array must contain 3 elements");
        if (desiredcolor < 0 || desiredcolor > 2) throw new ArgumentException("Desire color must be 0 - (red), 1 - (green), or 2 - (blue)");
        int other1 = (desiredcolor + 1) % 3;
        int other2 = (desiredcolor + 2) % 3;

        // Якщо всі вже цільового кольору
        if (hedgehogs[other1] == 0 && hedgehogs[other2] == 0) return 0;

        // Якщо одна з інших груп нульова — неможливо
        if (hedgehogs[other1] == 0 || hedgehogs[other2] == 0) return -1;

        int meetings = 0;

        while (hedgehogs[other1] > 0 && hedgehogs[other2] > 0)
        {
            // Зустріч зменшує кількість інших кольорів на 2
            hedgehogs[desiredcolor] += 2;
            hedgehogs[other1]--;
            hedgehogs[other2]--;
            meetings++;
        }

        // Якщо залишились "зайві" їжаки одного кольору, це неможливо

        int total = hedgehogs[0] + hedgehogs[1] + hedgehogs[2];
        return (hedgehogs[desiredcolor] == total) ? meetings : -1;
    }
    static void Main(string[] args)
    {
        int[] hedgehogs = { 8, 1, 8 };
        int desiredColor = 1;
        Console.WriteLine(MinMeetings(hedgehogs, desiredColor));
    }
}