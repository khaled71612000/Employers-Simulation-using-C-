using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9Task
{
    class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        List<Employee> Staff;

        public void AddStaff(Employee emp)
        {
            if (emp != null)
            {
                Staff?.Add(emp);
                emp.EmployeeLayOff += RemoveStaff;
            }
        }

        public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee emp)
            {
                Staff?.Remove(emp);
            }
        }

    }
}