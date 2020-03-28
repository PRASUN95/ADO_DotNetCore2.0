using Common.Model;

namespace EmployeeDataManagement
{
    public interface IEmployeeDbManager
    {
        string getName();
        Employee GetEmployee(string Id);
        Respone getAllEmployee();
    }
}
