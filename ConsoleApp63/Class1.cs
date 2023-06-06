using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp63;
public class Department
{
    private static int lastId = 0;
public int Id { get; }
public string Name { get; }
public string Surname { get; }
public decimal Salary { get; }
public int DepartmentId { get; set; }

public Employee(string name, string surname, decimal salary)
{
    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || salary <= 0)
    {
        throw new ArgumentException("Name, surname, and salary must be provided for creating an employee.");
    }

    this.Id = Interlocked.Increment(ref lastId);
    this.Name = name;
    this.Surname = surname;
    this.Salary = salary;
}

public override string ToString()
{
    return $"{this.Id}, {this.Name}, {this.Surname}";
}

public static Employee Create(string name, string surname, decimal salary)
{
    return new Employee(name, surname, salary);
}

}
