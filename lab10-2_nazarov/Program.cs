using System;

public class Exam
{
    public string Discipline { get; set; }
    public int StudentCount { get; set; }
    public double ExamDuration { get; set; }

    public Exam(string discipline, int studentCount, double examDuration)
    {
        Discipline = discipline;
        StudentCount = studentCount;
        ExamDuration = examDuration;
    }

    public double CalculateQuality()
    {
        return StudentCount / ExamDuration;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Экзамен по дисциплине: {Discipline}");
        Console.WriteLine($"Число студентов: {StudentCount}, Продолжительность экзамена: {ExamDuration} часа(ов)");
        Console.WriteLine($"Качество: {CalculateQuality()}");
    }
}

public class SpecialExam : Exam
{
    public int GradePercentage { get; set; }

    public SpecialExam(string discipline, int studentCount, double examDuration, int gradePercentage)
        : base(discipline, studentCount, examDuration)
    {
        GradePercentage = gradePercentage;
    }

    public new double CalculateQuality()
    {
        double baseQuality = base.CalculateQuality();
        return baseQuality * (100 - GradePercentage) / 100;
    }

    public new void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Процент двоек: {GradePercentage}%");
        Console.WriteLine($"Качество: {CalculateQuality()}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите информацию об экзамене (класс 1-го уровня):");
            Console.Write("Дисциплина: ");
            string discipline1 = Console.ReadLine();
            Console.Write("Число студентов: ");
            int studentCount1 = int.Parse(Console.ReadLine());
            Console.Write("Продолжительность экзамена (часы): ");
            double examDuration1 = double.Parse(Console.ReadLine());
            Exam exam1 = new Exam(discipline1, studentCount1, examDuration1);

            Console.WriteLine("Введите информацию о специальном экзамене (класс 2-го уровня):");
            Console.Write("Дисциплина: ");
            string discipline2 = Console.ReadLine();
            Console.Write("Число студентов: ");
            int studentCount2 = int.Parse(Console.ReadLine());
            Console.Write("Продолжительность экзамена (часы): ");
            double examDuration2 = double.Parse(Console.ReadLine());
            Console.Write("Процент двоек: ");
            int gradePercentage = int.Parse(Console.ReadLine());
            SpecialExam specialExam1 = new SpecialExam(discipline2, studentCount2, examDuration2, gradePercentage);

            Console.WriteLine("Информация об экзамене (класс 1-го уровня):");
            exam1.DisplayInfo();

            Console.WriteLine("Информация о специальном экзамене (класс 2-го уровня):");
            specialExam1.DisplayInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
