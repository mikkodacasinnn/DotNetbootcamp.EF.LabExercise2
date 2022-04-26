using EmployeeRecruitment.Data;
using EmployeeRecruitment.Models;
using EmployeeRecruitment.Repositories;
using System;
using System.Collections.Generic;

namespace EmployeeRecruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper configurationHelper = ConfigurationHelper.Instance();
            var dbConnectionString = configurationHelper.GetProperty<string>("DbConnectionString");
            Console.WriteLine(dbConnectionString);

            using(RecruitmentContext context = new RecruitmentContext(dbConnectionString))
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(context);
                PositionRepository positionRepository = new PositionRepository(context);
                AnnualSalaryRepository annualSalaryRepository = new AnnualSalaryRepository(context);
                MonthlySalaryRepository monthlySalaryRepository = new MonthlySalaryRepository(context);
                EmployeeSkillRepository employeeSkillRepository = new EmployeeSkillRepository(context);

                Console.Write("Enter Employee Code: ");
                string id = Console.ReadLine();
                Employee emp = employeeRepository.FindById(id);
                
                if(emp is Employee)
                {
                    Console.WriteLine($"Employee Code: { emp.CEmployeeCode}");
                    Console.WriteLine($"First Name: { emp.VFirstName}");
                    Console.WriteLine($"Last Name: { emp.VLastName}");

                    Position pos = positionRepository.FindById(emp.CCurrentPosition);
                    Console.WriteLine($"Postion: { pos.VDescription}");

                    Console.WriteLine("================================");
                    IEnumerable<AnnualSalary> annualSalary = annualSalaryRepository.FindAll(emp.CEmployeeCode);
                    Console.WriteLine("Annual Salaries: ");
                    foreach (var salary in annualSalary)
                    {
                        Console.WriteLine($"Year: { salary.SiYear}, Salary: { salary.MAnnualSalary}");
                    }

                    Console.WriteLine("================================");
                    IEnumerable<MonthlySalary> monthSalaries = monthlySalaryRepository.FindAll(emp.CEmployeeCode);
                    Console.WriteLine("Monthly Salaries: ");
                    foreach (var salary in monthSalaries)
                    {
                        Console.WriteLine($"Salary: { salary.MMonthlySalary}, Pay Date: {salary.DPayDate}, Referral Bonus: {salary.MReferralBonus}");
                    }

                    Console.WriteLine("================================");
                    IEnumerable<dynamic> skills = employeeSkillRepository.FindAll(emp.CEmployeeCode);
                    Console.WriteLine("Employee Skills: ");
                    foreach (var skill in skills)
                    {
                        Console.WriteLine($"{skill.CSkillCode}");
                    }
                    Main(args);
                }
                else
                {
                    Console.WriteLine("ID NOT FOUND!");
                    Main(args);
                }
            }
        }
    }
}
