using AA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BAL
{
    public interface IEmployeeManager
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        string AddEmployee(Employee employee);
        string EditEmployee(Employee employee);
        string DeleteEmployee(int id);
        IEnumerable<Employee> GetManagers();
    }
}
