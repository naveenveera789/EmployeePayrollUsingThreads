﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollUsingThreads
{
    public class EmployeePayrollOperation
    {
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = payrollService; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<EmployeeDetails> employeePayrollDetailsList = new List<EmployeeDetails>();
        public void addEmployeeToPayroll(List<EmployeeDetails> employeePayrollDetailsList)
        {
            employeePayrollDetailsList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                this.addEmployeeToPayroll(employeeData);
                Console.WriteLine("Employee added: " + employeeData.EmployeeName);
            });
            Console.WriteLine(this.employeePayrollDetailsList.ToString());
        }
        public void addEmployeeToPayroll(EmployeeDetails emp)
        {
            employeePayrollDetailsList.Add(emp);
        }
        public void addEmployeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDetailsList)
        {
            employeePayrollDetailsList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                    this.addEmployeeToPayroll(employeeData);
                    Console.WriteLine("Employee added: " + employeeData.EmployeeName);
                });
                thread.Start();
            });
            Console.WriteLine(this.employeePayrollDetailsList.Count);
        }
        public int employeeCount()
        {
            return this.employeePayrollDetailsList.Count;
        }
    }
}