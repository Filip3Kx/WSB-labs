using SystemOceniana;
class Program
{
    static void Main(string[] args)
    {
        int menuChoice = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Dodaj studenta\n2. Dodaj przedmiot\n3. Przypisz ocene\n4. Przegladaj dane\n5. Wyjdz\n");
            menuChoice = Convert.ToInt32(Console.ReadLine());

            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    Student student = new Student();
                    Console.WriteLine("Podaj imie");
                    student.firstName = Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko");
                    student.lastName = Console.ReadLine();

                    Registrar.AddStudent(student);
                    break;
                case 2:
                    Console.Clear();
                    Subject subject = new Subject();
                    Console.WriteLine("Podaj nazwe przedmiotu");
                    subject.subjectName = Console.ReadLine();

                    Registrar.AddSubject(subject);
                    break;
                case 3:
                    Console.Clear();
                    Grade grade = new Grade();

                    Registrar.ShowAllStudents();
                    Console.WriteLine("Podaj ID studenta");
                    grade.indexNumber = Convert.ToInt32(Console.ReadLine());

                    Registrar.ShowAllSubjects();
                    Console.WriteLine("Podaj ID przedmiotu");
                    grade.subjectId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Podaj ocene (A-F)");
                    grade.grade = Convert.ToChar(Console.ReadLine());

                    Registrar.AssignGrade(grade);
                    break;
                case 4:
                    int searchChoice = 0;
                    Console.Clear();
                    Console.WriteLine("Przegladaj po\n 1. Uczniu\n 2. Przedmiocie");
                    searchChoice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (searchChoice)
                    {
                        case 1:
                            Registrar.ListGradesByStudent();
                            break;
                        case 2:
                            Registrar.ListGradesBySubject();
                            break;
                    }
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("\nNieprawidlowa opcja. Wcisnij dowolny przycisk");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

