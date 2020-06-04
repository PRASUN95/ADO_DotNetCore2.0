using Common.Model;
using System.Threading.Tasks;

namespace EmployeeDataManagement
{
    public interface IEmployeeDbManager
    {
        string getName();
        Task<Employee> GetEmployee(string Id);
        Task<Respone> getAllEmployee();
        Task<Respone> DeleteEmployee(string Id);
    }
}
