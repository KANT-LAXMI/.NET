using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public  class Employee
    {

        [Key]
        public int EmpId { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public double Salary { get; set; } = 0;

        public Employee()
        {
        }

        public Employee(int empId, string firstName, string lastName,string department, string email, string password, double sal)
        {
            EmpId = empId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Salary = sal;
            Department = department;
        }


    }
}