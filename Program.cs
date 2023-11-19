using System;
using System.IO;
using System.Collections.Generic;


Random rand = new Random();
int number = rand.Next(1, 101);
int wynik_i = 1;
int wynik=0;

//ranking
string filePath = "C:\\Users\\Filip\\source\\repos\\lab1\\lab1\\ranking.txt";
List<string> linesList = new List<string>(File.ReadAllLines(filePath));



for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Odgadnij losową liczbę");

    int guess = Convert.ToInt32(Console.ReadLine());

    if (guess > number)
    {
        Console.WriteLine("Większa");
        wynik_i++;
    }
    else if (guess < number)
    {
        Console.WriteLine("Mniejsza");
        wynik_i++;
    }
    else if (guess == number)
    {
        Console.WriteLine("Równa");
        wynik = wynik_i++;
    }
}


Console.Clear();

//Warunek wygranej/przegranej
if (wynik != 0)
{
    //update rankingu
    linesList.Add(Convert.ToString(wynik));
    linesList.Sort();
    File.WriteAllLines(filePath, linesList);

    int position = linesList.IndexOf(Convert.ToString(wynik));
    //output
    Console.WriteLine("Wygrales!");
    Console.WriteLine("Twoj wynik to " + Convert.ToString(wynik));
    Console.WriteLine("Twoja pozycja w rankingu to " + Convert.ToString(position+1));
    Console.WriteLine("Liczba do odgadniecia to " + Convert.ToString(number));
}
else
{
    Console.WriteLine("Przegrales");
    Console.WriteLine("Liczba do odgadniecia to " + Convert.ToString(number));
}


Console.WriteLine("\n\nRANKING:");
foreach (string line in linesList)
{
    Console.WriteLine(line);
}
