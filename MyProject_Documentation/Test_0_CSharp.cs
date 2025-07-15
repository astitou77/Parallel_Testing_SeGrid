using System;
using System.Collections.Generic;
using Utils = EmployeeApp.Utilities;

namespace EmployeeApp{

// 🧾 Constants and Enums
public static class Constants
{
    public const int MaxEmployees = 100;
}

public enum Department
{
    HR,
    Engineering,
    Marketing,
    Sales
}

// 🏗️ Abstract and Static Classes
public abstract class Person
{
    public abstract void DisplayInfo();
}

public static class Logger
{
    public static void Log(string message)
    {
        Console.WriteLine($"[LOG]: {message}");
    }
}

// 👔 Main Class with Inheritance
public class Employee : Person
{
    // 🔐 Private Fields
    private int _id;
    private string _name;

    // 🧰 Properties with Getters/Setters
    public int ID
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public Department Dept { get; set; }

    // 🏗️ Constructor
    public Employee(int id, string name, Department dept)
    {
        ID = id;
        Name = name;
        Dept = dept;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Employee ID: {ID}, Name: {Name}, Department: {Dept}");
    }
}

// 📦 Record Type
public record Contractor(string Name, string Agency);

// 📐 Struct Type
public struct Project
{
    public string Title;
    public int DurationWeeks;

    public Project(string title, int durationWeeks)
    {
        Title = title;
        DurationWeeks = durationWeeks;
    }

    public void Show()
    {
        Console.WriteLine($"Project: {Title}, Duration: {DurationWeeks} weeks");
    }
}

// 🛠 Utility Namespace
namespace Utilities
{
    public static class Helpers
    {
        public static string FormatName(string name) => name.ToUpper();
    }
}

// 🚀 Main Program
class Program
{
    static void Mainzzzzzzzzzzz(string[] args)
    {
        // 🌱 Variables and Collections
        List<Employee> employees = new();
        Dictionary<int, string> employeeLookup = new();

        // 👷 Adding employees using loop
        for (int i = 1; i <= 3; i++)
        {
            string name = $"Employee{i}";
            var emp = new Employee(i, Utils.Helpers.FormatName(name), (Department)(i % 4));
            employees.Add(emp);
            employeeLookup.Add(emp.ID, emp.Name);
        }

        // 🧾 Displaying employee info with foreach
        foreach (var emp in employees)
        {
            emp.DisplayInfo();
        }

        // 🔎 Using switch
        int lookupId = 2;
        switch (employeeLookup.ContainsKey(lookupId))
        {
            case true:
                Console.WriteLine($"Found: {employeeLookup[lookupId]}");
                break;
            case false:
                Console.WriteLine("Employee not found.");
                break;
        }

        // 🛠 Working with struct and record
        Project project = new("AI Migration", 12);
        project.Show();

        Contractor contractor = new("Alice", "TechStaff");
        Console.WriteLine($"Contractor: {contractor.Name} from {contractor.Agency}");

        // 📣 Logger usage
        Logger.Log("Program executed successfully.");

        // 🔚 If-Else Example
        if (employees.Count > Constants.MaxEmployees)
            Console.WriteLine("Employee limit exceeded.");
        else
            Console.WriteLine("Employee count is within limit.");
    }
}

}
