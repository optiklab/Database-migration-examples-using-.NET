namespace Phi.Repository.Postgres.Dapper
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(Employee employee);
        Task<List<Employee>> GetEmployeeList();
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int key);
    }
}
