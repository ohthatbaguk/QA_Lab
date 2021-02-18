using System;
using System.Collections.Generic;
using System.Linq;
using Homework2.BaseEntities;
using Homework2.Interface;
using Homework2.Models;

namespace Homework2.Report
{
    public class EmployeeReportGenerator : IReportGenerator
    {
        public void Report(List<BaseUser> employees)
        {
            var createEmp = employees.OfType<Employee>();
            var sortEmp = createEmp.OrderByDescending(employee => employee.Company.Name)
                .ThenByDescending(u => u.Company.Name)
                .ThenByDescending(u => u.Job.Salary);
            Console.WriteLine("UserId || Company Name || Users Full Name || Salary");
            foreach (var user in sortEmp)
            {
                Console.WriteLine($"{user.UserId} || {user.Company.Name} || {user.FullName} || {user.Job.Salary}");
            }
        }
    }
}