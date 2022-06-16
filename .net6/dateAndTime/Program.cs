DateTime dateTime = DateTime.Now;

DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now);
TimeOnly timeOnly = TimeOnly.FromDateTime(DateTime.Now);

Console.WriteLine(dateTime);
Console.WriteLine(dateOnly);
Console.WriteLine(timeOnly);