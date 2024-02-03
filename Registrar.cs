using System.Collections.Generic;

namespace SystemOceniana;

public class Registrar
{
    public static void AddStudent(Student student)
    {
        string filePath = "..\\..\\..\\students_db.txt";
        List<string> linesList = new List<string>();
        linesList = new List<string>(File.ReadAllLines(filePath));
        student.indexNumber = linesList.Count();

        linesList.Add(student.indexNumber + ";" + student.firstName + ";" + student.lastName);
        File.WriteAllLines(filePath, linesList);
    }
    public static void AddSubject(Subject subject)
    {
        string filePath = "..\\..\\..\\subjects_db.txt";
        List<string> linesList = new List<string>();
        linesList = new List<string>(File.ReadAllLines(filePath));
        subject.subjectId = linesList.Count();

        linesList.Add(subject.subjectId + ";" + subject.subjectName);
        File.WriteAllLines(filePath, linesList);
    }

    public static void AssignGrade(Grade grade)
    {
        string filePath = "..\\..\\..\\grades_db.txt";
        List<string> linesList = new List<string>();
        linesList = new List<string>(File.ReadAllLines(filePath));
        grade.subjectId = linesList.Count();

        linesList.Add(grade.grade + ";" + grade.subjectId + ";" + grade.indexNumber);
        File.WriteAllLines(filePath, linesList);
    }

    public static void ShowAllStudents()
    {
        string filePath = "..\\..\\..\\students_db.txt";
        List<string> linesList = new List<string>();
        linesList = new List<string>(File.ReadAllLines(filePath));

        foreach (string line in linesList)
        {
            string lineTab = line.Replace(";", "\t");
            Console.WriteLine(lineTab);
        }
    }
    public static void ShowAllSubjects()
    {
        string filePath = "..\\..\\..\\subjects_db.txt";
        List<string> linesList = new List<string>();
        linesList = new List<string>(File.ReadAllLines(filePath));

        foreach (string line in linesList)
        {
            string lineTab = line.Replace(";", "\t");
            Console.WriteLine(lineTab);
        }
    }
    public static void ListGradesByStudent()
    {
        string subjectFilePath = "..\\..\\..\\subjects_db.txt";
        string studentsFilePath = "..\\..\\..\\students_db.txt";
        string gradesFilePath = "..\\..\\..\\grades_db.txt";

        var subjects = File.ReadAllLines(subjectFilePath)
                           .Select(line => line.Split(';'))
                           .ToDictionary(parts => parts[0], parts => parts[1]);

        var students = File.ReadAllLines(studentsFilePath)
                           .Select(line => line.Split(';'))
                           .ToDictionary(parts => parts[0], parts => parts[1]);

        var grades = File.ReadAllLines(gradesFilePath)
                         .Select(line => line.Split(';'))
                         .Select(parts => new
                         {
                             SubjectId = parts[1],
                             StudentId = parts[1],
                             Grade = parts[0]
                         });

        foreach (var student in students)
        {
            Console.WriteLine($"Student: {student.Value} (ID: {student.Key})");
            var studentGrades = grades.Where(g => g.StudentId == student.Key);

            foreach (var grade in studentGrades)
            {
                if (subjects.TryGetValue(grade.SubjectId, out var subjectName))
                {
                    Console.WriteLine($"\tSubject: {subjectName}, Grade: {grade.Grade}");
                }
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }

    public static void ListGradesBySubject()
    {
        string subjectFilePath = "..\\..\\..\\subjects_db.txt";
        string studentsFilePath = "..\\..\\..\\students_db.txt";
        string gradesFilePath = "..\\..\\..\\grades_db.txt";

        var subjects = File.ReadAllLines(subjectFilePath)
                           .Select(line => line.Split(';'))
                           .ToDictionary(parts => parts[0], parts => parts[1]);

        var students = File.ReadAllLines(studentsFilePath)
                           .Select(line => line.Split(';'))
                           .ToDictionary(parts => parts[0], parts => parts[1]);

        var grades = File.ReadAllLines(gradesFilePath)
                         .Select(line => line.Split(';'))
                         .Select(parts => new
                         {
                             SubjectId = parts[1],
                             StudentId = parts[1],
                             Grade = parts[0]
                         });

        foreach (var subject in subjects)
        {
            Console.WriteLine($"Subject: {subject.Value} (ID: {subject.Key})");
            var subjectGrades = grades.Where(g => g.SubjectId == subject.Key);

            foreach (var grade in subjectGrades)
            {
                if (students.TryGetValue(grade.StudentId, out var studentName))
                {
                    Console.WriteLine($"\tStudent: {studentName}, Grade: {grade.Grade}");
                }
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}