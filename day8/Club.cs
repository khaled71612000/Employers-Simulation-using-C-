using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9Task
{
    class Club
    {
        public int ClubID { get; set; }
        public string ClubName { get; set; }

        List<Employee> Members;
        public void AddMember(Employee emp)
        {
            if (emp != null)
            {
                Members?.Add(emp);
                emp.EmployeeLayOff += RemoveMember;
            }

        }

        public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
        {
            if (e.Cause != LayOffCause.retired && e.Cause != LayOffCause.resign)
            {
                if (sender is Employee emp)
                {
                    Members?.Remove(emp);
                    Console.WriteLine("Didnt get removed from club");
                }
            }
        }

    }
}