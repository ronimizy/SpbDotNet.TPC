namespace ronimizy.SpbDotNet.TPC.Model.Employees;

public class Manager : Employee
{
    public ICollection<Employee> Employees { get; set; }
}