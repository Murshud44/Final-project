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
    public string Name { get; set; }
    public int EmployeeLimit { get; set; }
    public int CompanyId { get; set; }

    private List<Employee> employees = new List<Employee>();

    public Department(string name, int employeeLimit, int companyId)
    {
        if (string.IsNullOrEmpty(name) || employeeLimit <= 0 || companyId <= 0)
        {
            throw new ArgumentException("Name, employee limit, and company ID must be provided for creating a department.");
        }

        this.Id = Interlocked.Increment(ref lastId);
        this.Name = name;
        this.EmployeeLimit = employeeLimit;
        this.CompanyId = companyId;
    }

    public override string ToString()
    {
        return $"{this.Id}, {this.Name}";
    }

    public void AddEmployee(Employee employee)
    {
        if (employee.DepartmentId != 0 && employee.DepartmentId != this.Id)
        {
            throw new InvalidOperationException("The employee already belongs to another department.");
        }

        if (this.employees.Count >= this.EmployeeLimit)
        {
            throw new CapacityLimitException("The department has reached its employee capacity limit.");
        }

        employee.DepartmentId = this.Id;
        this.employees.Add(employee);
    }

    public void UpdateDepartment(string newName, int newEmployeeLimit)
    {
        if (string.IsNullOrEmpty(newName) || newEmployeeLimit <= 0)
        {
            throw new ArgumentException("New name and employee limit must be provided for updating a department.");
        }

        this.Name = newName;
        this.EmployeeLimit = newEmployeeLimit;
    }

    public void GetDepartmentEmployees()
    {
        Console.WriteLine($"Employees in department {this.Name}:");
        foreach (Employee employee in this.employees)
        {
            Console.WriteLine(employee);
        }
    }

    public static Department Create(string name, int employeeLimit, int companyId)
    {
        return new Department(name, employeeLimit, companyId);
    }
}

internal class Employee
{
    private string name;
    private string surname;
    private decimal salary;

    public Employee(string name, string surname, decimal salary)
    {
        this.name = name;
        this.surname = surname;
        this.salary = salary;
    }

    public int DepartmentId { get; internal set; }
}