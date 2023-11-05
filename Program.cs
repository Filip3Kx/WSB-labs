while (true) {
    Console.WriteLine("Wybierz operacje na przesłanych liczbach:\n 1. Dodawanie \n 2. Odejmowanie \n 3. Mnożenie \n 4. Dzielenie\n 5. Wyjdź");
    int menuChoice = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Podaj liczbe A");
    float a = (float)Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Podaj liczbe B");
    float b = (float)Convert.ToDouble(Console.ReadLine());
    float c=0;

    switch (menuChoice)
    {
        case 1:
            c = a + b;
            break;
        case 2:
            c = a - b;
            break;
        case 3:
            c = a * b;
            break;
        case 4:
            if (b!=0)
            {
                c = a / b;
            }
            else
            {
                Console.WriteLine("Nie dziel przez 0");
            }
            break;
        case 5:
            return;
        default:
            Console.WriteLine("Nieodpowiednia operacja");
            break;
    }
    Console.WriteLine(c);
}
