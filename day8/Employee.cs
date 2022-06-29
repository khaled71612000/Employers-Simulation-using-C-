using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9Task
{
    class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void onEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            Console.WriteLine("Employee ID {0} is layed off because of {1}", this.EmployeeID, e.Cause);
            EmployeeLayOff?.Invoke(this, e);

        }

        public int EmployeeID { get; set; }
        public DateTime BirthDate { get; set; }
        public int VacationStock { get; set; }
        public bool RequestVacation(DateTime from, DateTime to)
        {
            if (from.CompareTo(to) > 0) { return false; }
            int requested = to.Subtract(from).Days;
            VacationStock -= requested;

            if (VacationStock < 0)
            {
                onEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.vacation });
            }
            return VacationStock >= 0;
        }

        public void EndOfYearOperation()
        {
            DateTime retirement = BirthDate.AddYears(60);

            if (DateTime.Now.CompareTo(retirement) > 0)
            {
                onEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.retired });
            }
        }
    }

    public enum LayOffCause
    {
        retired,
        vacation,
        target,
        resign
    }

    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }
    }


    class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }
        public bool CheckTarget(int Quota)
        {
            if (AchievedTarget < Quota)
            {
                onEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.target });
            }
            return AchievedTarget >= Quota;
        }

        protected override void onEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if (e.Cause == LayOffCause.target || e.Cause == LayOffCause.retired)
            {
                base.onEmployeeLayOff(e);
            }
        }
    }

    class BoardMember : Employee
    {
        public void Resign()
        {
            onEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.resign });
        }

        protected override void onEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            if (e.Cause == LayOffCause.resign)
            {
                base.onEmployeeLayOff(e);
            }
        }
    }

}
