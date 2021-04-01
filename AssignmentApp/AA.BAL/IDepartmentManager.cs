using AA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.BAL
{
    public  interface IDepartmentManager
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int id);
        string AddDepartment(Department department);
        string EditDepartment(Department department);
        string DeleteDepartment(int id);
    }
}
