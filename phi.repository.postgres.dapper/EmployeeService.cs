using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phi.Repository.Postgres.Dapper
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbService _dbService;

        public EmployeeService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            var result = await _dbService.Insert<int>("INSERT INTO public.employee (id,name, age, address, mobile_number) VALUES (@Id, @Name, @Age, @Address, @MobileNumber)", employee);
            return true;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            var employeeList = await _dbService.GetAll<Employee>("SELECT * FROM public.employee", new { }); // TODO Check for SQL injection
            return employeeList;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var updateEmployee = await _dbService.Update<int>("Update public.employee SET name=@Name, age=@Age, address=@Address, mobile_number=@MobileNumber WHERE id=@Id", employee);
            return employee;
        }

        public async Task<bool> DeleteEmployee(int key)
        {
            var deleteEmployee = await _dbService.Delete<int>("DELETE FROM public.employee WHERE id=@Id", new { id = key });
            return true;
        }
    }
}
