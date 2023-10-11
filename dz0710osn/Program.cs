

using System;
using System.Collections.Generic;
using System.IO;

class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int BirthYear { get; set; }
    public string ExamName { get; set; }
    public int Score { get; set; }

    public override string ToString()
    {
        return $"{LastName} {FirstName} ({BirthYear}), Экзамен, по которому поступали: {ExamName}, Балл: {Score}";
    }
}

class Program
{
    static void Main(string[] args)

    {
        Console.WriteLine("Задание 1");
        //Создать словарь для студентов.
        Dictionary<string, Student> students = new Dictionary<string, Student>();


        ReadStudents(students);

        bool fl = true;
        while (fl)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("a.Новый студент");
            Console.WriteLine("b.Удалить студента");
            Console.WriteLine("c. Сортировать по баллам");


            Console.Write("Выберите пункт: ");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "a":
                    AddNewStudent(students);
                    break;
                case "b":
                    RemoveStudent(students);
                    break;
                case "c":
                    SortStudents(students);
                    break;

                default:
                    Console.WriteLine("Несуществующий вариант.");
                    break;
            }
        }
    }

    static void ReadStudents(Dictionary<string, Student> students)
    {
        string filePath = "C:\\Users\\cl\\source\\repos\\тестик\\TextFile.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 5)
                {
                    Student student = new Student
                    {
                        LastName = parts[0].Trim(),
                        FirstName = parts[1].Trim(),
                        BirthYear = int.Parse(parts[2].Trim()),
                        ExamName = parts[3].Trim(),
                        Score = int.Parse(parts[4].Trim())
                    };
                    students.Add($"{student.LastName} {student.FirstName}", student);
                }
            }
        }
        else
        {
            Console.WriteLine("Файл не найден");
        }
    }

    static void AddNewStudent(Dictionary<string, Student> students)
    {
        Console.WriteLine("Enter student's information:");
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine().Trim();
        Console.Write("First Name: ");
        string firstName = Console.ReadLine().Trim();
        Console.Write("Birth Year: ");
        int birthYear = int.Parse(Console.ReadLine().Trim());
        Console.Write("Exam Name: ");
        string examName = Console.ReadLine().Trim();
        Console.Write("Score: ");
        int score = int.Parse(Console.ReadLine().Trim());

        Student student = new Student
        {
            LastName = lastName,
            FirstName = firstName,
            BirthYear = birthYear,
            ExamName = examName,
            Score = score
        };

        students.Add($"{student.LastName} {student.FirstName}", student);
        Console.WriteLine("Новый студент был успешно добавлен!");
    }

    static void RemoveStudent(Dictionary<string, Student> students)
    {
        Console.Write("Введите фамилию: ");
        string lastName = Console.ReadLine().Trim();
        Console.Write("Введите имя: ");
        string firstName = Console.ReadLine().Trim();

        string key = $"{lastName} {firstName}";
        if (students.ContainsKey(key))
        {
            students.Remove(key);
            Console.WriteLine("Студент удален!");
        }
        else
        {
            Console.WriteLine("Студент не найден");
        }
    }

    static void SortStudents(Dictionary<string, Student> students)
    {
        List<Student> sortedStudents = new List<Student>(students.Values);
        sortedStudents.Sort((s1, s2) => s1.Score.CompareTo(s2.Score));

        Console.WriteLine("Сортировка студентов:");

        foreach (Student student in sortedStudents)
        {
            Console.WriteLine(student);
        }
    }
}

