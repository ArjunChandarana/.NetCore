using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public bool  IsManager { get; set; }
        [Required]
      
        
        public int Manager { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }


    }
}
