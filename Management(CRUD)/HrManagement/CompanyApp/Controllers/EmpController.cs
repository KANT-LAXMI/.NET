using BOL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Controllers
{
    public class EmpController : Controller
    {

        private readonly ILogger<EmpController> _logger;

        public EmpController(ILogger<EmpController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //ALL EMPLOYEES 
        public IActionResult AllEmp()
        {
            List<Employee> emp = new List<Employee>();
            emp = DBManager.GetAllEmployees(); 
            this.ViewData["employees"] = emp;
            return View();
        }

        //DELETE EMPLOYEE
        public IActionResult DeleteEmp(int empId)
        {
            bool status = DBManager.Delete(empId);
            this.ViewData["EmployeeId"] = empId;
            Console.WriteLine("Empid= " + empId);
            if (status)
            {
                Console.WriteLine("In If condition");
                return RedirectToAction("AllEmp");
            }
            else
            {
                return View();
            }
        }

        //GET VIEW OF ADD EMPLOYEE
        [HttpGet]
        public IActionResult AddEmp()
        {
            return View();
        }

        //ADD EMPLOYEE
        [HttpPost]
        public IActionResult AddEmp(int empId, string firstName, string lastName,string department, string email, string password, double sal)
        {
            Employee emp = new Employee();
            emp.EmpId = empId;
            emp.FirstName = firstName;
            emp.LastName = lastName;
            emp.Department = department;
            emp.Email = email;
            emp.Password = password;
            emp.Salary = sal;

           bool status= DBManager.Insert(emp);
            if(status)
            {
                return RedirectToAction("AllEmp");
            }
            else
            {
                return View();
            }
        }

        //GET SINGLE EMPLOYEE DETAILS
        [HttpGet]
        public IActionResult UpdateEmp(int empId)
        {
            Employee e = new Employee();
            e = DBManager.GetEmpDetails(empId);
            this.ViewBag.selectedEmp = e;
            return View();
        }

        //UPDATE EMPLOYEE DETAILS
        [HttpPost]
        public IActionResult UpdateEmp(int empId, string firstName, string lastName,string department, string email, string password, double sal)
        {
            Employee emp = new Employee();
            emp.EmpId = empId;
            emp.FirstName = firstName;
            emp.LastName = lastName;
            emp.Department = department;
            emp.Email = email;
            emp.Password = password;
            emp.Salary = sal;

            bool status=DBManager.Update(emp);
            if (status)
            {
                return RedirectToAction("AllEmp");
            }
            else
            {
                return View();
            }

        }

        //SHOW EMPLOYEE NAME
        public IActionResult EmpName()
        {
            List<Employee> emp = new List<Employee>();
            emp = DBManager.GetAllEmployees();
            this.ViewBag.selectedNames = emp;
            return View();
        }

        //SHOW EMPLOYEE DETAILS
        [HttpGet]
        public IActionResult ShowEmpDetails(int empId)
        {
            Employee emp = new Employee();
            emp = DBManager.GetEmpDetails(empId);
            this.ViewBag.selectedEmpName = emp;
            return View();

        }





    }
}
