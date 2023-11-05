Random rand = new Random();
int number = rand.Next(1, 100);

for (int i = 0; i<10; i++)
{
    Console.WriteLine("Odgadnij losową liczbę");

    int guess = Convert.ToInt32(Console.ReadLine());

    if (guess>number)
    {
        Console.WriteLine("Większa");
    }
    else if (guess<number)
    {
        Console.WriteLine("Mniejsza");
    }
    else if (guess == number)
    {
        Console.WriteLine("Równa");
    }
}
Console.WriteLine(number);
