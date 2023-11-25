string filePath = "C:\\Users\\Filip\\source\\repos\\lab1\\lab1\\biblioteka.txt";
//Format pliku biblioteka.txt
//ID;autor;tytul;rok;czy_wypozyczona
List<string> linesList = new List<string>();
try
{
    linesList = new List<string>(File.ReadAllLines(filePath));
}
catch (FileNotFoundException)
{
    Console.WriteLine("Nieprawidlowy plik lub sciezka do pliku");
    return;
}

int book_id = linesList.Count();

while (true)
{
    Console.Clear();
    Console.WriteLine("Wybierz operacje na bazie biblioteki:\n1. Dodaj ksiazke\n2. Usun Ksiazke\n3. Przegladaj Ksiazki\n4. Zmiana statusu ksiazki\n5. Wyszukaj Ksiazki\n6. Zaktualizuj informacje o ksiazce\n7. Zapisz stan\n8. Wyjscie");
    int menuChoice = 0;
    try
    {
        menuChoice = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.WriteLine("\nNieprawidlowa opcja. Wcisinij dowolny przycisk");
        Console.ReadKey();
    }

    switch(menuChoice)
    {


        case 1:
            //Add
            Console.Clear();
            Console.WriteLine("Podaj autora:");
            string add_autor = Console.ReadLine();
            Console.WriteLine("Podaj tytul:");
            string add_tytul = Console.ReadLine();
            Console.WriteLine("Podaj rok:");
            int add_rok = 0;
            try
            {
                add_rok = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidlowo wprowadzony rok. Wcisnij dowolny przycisk");
                Console.ReadKey();
                break;
            }
            Console.WriteLine("0 jesli ksiazka jest w bibliotece\n1 jesli ksiazka jest wypozyczona:");
            string add_status = Console.ReadLine();


            object[] rekord_array = { book_id, add_autor, add_tytul, add_rok, add_status };
            book_id += 1;
            string rekord = string.Join(";", rekord_array);
            linesList.Add(rekord);
            break;


        case 2:
            //Delete
            Console.Clear();
            Console.WriteLine("Podaj identyfikator ksiazki ktora chcesz usunac");
            int remove_id = 0;
            try
            {
                remove_id = Convert.ToInt32(Console.ReadLine());
                linesList.RemoveAt(remove_id);
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidlowo wpisany identyfikator. Wcisnij dowolny przycisk");
                Console.ReadKey();
                break;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Nie ma takiej ksiazki. Wcisnij dowolny przycisk");
                Console.ReadKey();
                break;
            }

            //update IDs after deleting
            for (int id_update = 0; id_update < linesList.Count; id_update++)
            {
                string str = Convert.ToString(id_update + 1) + linesList[id_update].Remove(0, 1);
                Console.WriteLine(str);
                linesList[id_update] = str;
                Console.WriteLine(linesList[id_update]);
            }
            break;


        case 3:
            Console.Clear();
            //Look through
            foreach (string line in linesList)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nNacisnij dowolny przycisk zeby wrocic do menu:");
            Console.ReadKey();
            break;


        case 4:
            //borrow
            Console.Clear();
            Console.WriteLine("Podaj identyfikator ksiazki ktora chcesz wypozyczyc/oddac:");
            int borrow_id = 0;
            string working_book = "";
            try
            {
                borrow_id = Convert.ToInt32(Console.ReadLine());
                working_book = linesList[borrow_id];
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidlowo wpisany identyfikator. Wcisnij dowolny przycisk");
                Console.ReadKey();
                break;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Nie ma takiej ksiazki. Wcisnij dowolny przycisk");
                Console.ReadKey();
                break;
            }
            string[] working_book_array = working_book.Split(';');
            if (working_book_array[4] == "0")
            {
                working_book_array[4] = "1";
            }
            else working_book_array[4] = "0";

            working_book = string.Join(";", working_book_array);
            linesList[borrow_id] = working_book;

            break;


        case 5:
            //search
            Console.Clear();
            Console.WriteLine("Po czym chcesz wyszukiwac ksiazki?\n1. Autor\n2. Tytul\n3. Rok wydania");
            int search_criteria = 0;
            try
            {
                search_criteria = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidlowa opcja. Wcisnij dowolny przycisk");
                Console.ReadKey();
                break;
            }
            if (search_criteria==1 || search_criteria==2 || search_criteria==3)
            {
                Console.WriteLine("Podaj szukana fraze:");
                string search_query = Console.ReadLine();

                string[] search_array = new string[0];

                foreach (string line in linesList)
                {
                    if (line.Split(";")[search_criteria] == search_query)
                    {
                        Console.WriteLine(line);
                    }
                }
                Console.ReadKey();
                break;
            }
            else
            {
                Console.WriteLine("Nieprawidlowa opcja. Wcisnij dowolny przycisk");
                Console.ReadKey();
                break;
            }

        case 6:
            //alter
            Console.Clear();
            Console.WriteLine("Podaj identyfikator ksiazki ktora chcesz zmodyfikowac:");
            int alter_id = 0;
            string[] alter_array = new string[0];
            try
            {
                alter_id = Convert.ToInt32(Console.ReadLine());
                alter_array = linesList[alter_id].Split(";");
            }
            catch (FormatException)
            {
                Console.WriteLine("Nieprawidlowo wpisany identyfikator. Wcisnij dowolny przycisk");
                Console.ReadKey();
                break;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Nie ma takiej ksiazki. Wcisnij dowolny przycisk");
                Console.ReadKey();
                break;
            }


            Console.WriteLine("Podaj autora (Aktualnie " + alter_array[1] + "):");
            string alter_autor = Console.ReadLine();
            Console.WriteLine("Podaj tytul (Aktualnie " + alter_array[2] + "):");
            string alter_tytul = Console.ReadLine();
            Console.WriteLine("Podaj rok (Aktualnie " + alter_array[3] + "):");
            string alter_rok = Console.ReadLine();

            object[] rekord_alter_array = { alter_id, alter_autor, alter_tytul, alter_rok, alter_array[4] };
            string alter_rekord = string.Join(";", rekord_alter_array);

            linesList[alter_id] = alter_rekord;
            break;


        case 7:
            //save
            Console.Clear();
            File.WriteAllLines(filePath, linesList);
            Console.WriteLine("Zapisano stan aktualny do pliku biblioteka.txt. Wcisnij dowolny przycisk");
            Console.ReadKey();
            break;


        case 8:
            return;


        default:
            Console.WriteLine("\nNieprawidlowa opcja. Wcisnij dowolny przycisk");
            Console.ReadKey();
            break;
    }
}


