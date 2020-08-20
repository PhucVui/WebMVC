using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWeb.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;

        public MockEmployeeRepository()
        {
            employees = new List<Employee>()
            {
               new Employee() 
               {
                   Id = 1,
                   FullName = "Duy Anh", 
                   Department = Department.Sale, 
                   Email="Duyanh@gmail.com", 
                   AvatarPath="images/nu1.png"
               },
                new Employee()
               {
                   Id = 2,
                   FullName = "Văn Tân",
                   Department = Department.IT,
                   Email="vantan@gmail.com",
                   AvatarPath="images/nu.jpg"
               },
                new Employee()
               {
                   Id = 3, 
                   FullName = "Hồng Sơn",
                   Department = Department.Payroll,
                   Email="hongson@gmail.com",
                   AvatarPath="images/nu4.jpg"
               }
            };
           
        }

        public Employee Create(Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employee.AvatarPath = "images/nu4.jpg";
            employees.Add(employee);
            return employee;
        }

        public bool Delete(int id)
        {
            var delete = Get(id);
            if(delete != null)
            {
                employees.Remove(delete);
                return true;
            }
            return false;
        }

        public Employee Edit(Employee employee)
        {
            var editEmployee = Get(employee.Id);
            editEmployee.FullName = employee.FullName;
            editEmployee.Email = employee.Email;
            editEmployee.Department = employee.Department;
            return editEmployee;
        }

        public Employee Get(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> Gets()
        {
            return employees;
        }
    }
}
