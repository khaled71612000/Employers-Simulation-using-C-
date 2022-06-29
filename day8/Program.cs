using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            emp1.EmployeeID = 1;
            emp1.BirthDate = DateTime.Now;
            emp1.VacationStock = 50;

            Employee emp2 = new Employee();
            emp2.EmployeeID = 2;
            emp2.BirthDate = DateTime.Now;
            emp2.VacationStock = 0;

            Employee emp3 = new Employee();
            emp3.EmployeeID = 3;
            emp3.BirthDate = new DateTime(1950, 10, 10);

            SalesPerson sales = new SalesPerson();
            sales.EmployeeID = 4;
            sales.BirthDate = DateTime.Now;
            sales.VacationStock = -1;
            sales.AchievedTarget = 5;


            BoardMember elbigboss = new BoardMember();
            elbigboss.EmployeeID = 5;
            elbigboss.BirthDate = new DateTime(1940, 10, 10);
            elbigboss.VacationStock = -1;

            Department dept = new Department();
            dept.DeptName = "ayhaga";
            dept.DeptID = 6;

            Club club = new Club();
            club.ClubName = "club bta3 el ay haga";
            club.ClubID = 7;



            dept.AddStaff(emp1);
            dept.AddStaff(emp2);
            dept.AddStaff(emp3);
            dept.AddStaff(sales);
            dept.AddStaff(elbigboss);

            club.AddMember(emp1);
            club.AddMember(emp2);
            club.AddMember(emp3);
            club.AddMember(sales);
            club.AddMember(elbigboss);


            emp1.EndOfYearOperation();
            emp1.RequestVacation(DateTime.Now, DateTime.Now.AddDays(2));

            emp2.EndOfYearOperation();
            emp2.RequestVacation(DateTime.Now, DateTime.Now.AddDays(2));

            emp3.EndOfYearOperation();


            sales.EndOfYearOperation();
            sales.RequestVacation(DateTime.Now, DateTime.Now.AddDays(2));
            sales.CheckTarget(20);

            elbigboss.EndOfYearOperation();
            elbigboss.RequestVacation(DateTime.Now, DateTime.Now.AddDays(2));
            elbigboss.Resign();


            Console.ReadLine();
        }
    }
}