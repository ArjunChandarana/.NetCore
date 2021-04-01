using AA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.DAL.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public string AddEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var res = _dbContext.Employees.Where(x => x.Name == employee.Name).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    _dbContext.Employees.Add(employee);
                    _dbContext.SaveChanges();
                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteEmployee(int id)
        {
            var entity = _dbContext.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Employees.Remove(entity);
                _dbContext.SaveChanges();
                return "deleted";
            }
            return "null";
        }

        public string EditEmployee(Employee employee)
        {
            try
            {
                var entity = _dbContext.Employees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = employee.Name;
                    entity.DepartmentId = employee.DepartmentId;
                    entity.Email = employee.Email;
                    entity.IsManager = employee.IsManager;
                    entity.PhoneNumber = employee.PhoneNumber;
                    entity.Salary = employee.Salary;
                    entity.Manager = employee.Manager;
                    _dbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Employee GetEmployee(int id)
        {
            var entity = _dbContext.Employees.Find(id);

            if (entity == null)
            {
                entity = new Employee();
            }
            return entity;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var entities = _dbContext.Employees.ToList();
            return entities;
        }

        public IEnumerable<Employee> GetManagers()
        {
            var entities = _dbContext.Employees.Where(e => e.IsManager == true).ToList();
            return entities;
        }
    }
}
