using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    public class Worker : Human
    {
        private decimal weeklySalary;
        private decimal workHoursPerDay;
       
        public Worker(string firstName, string secondName , decimal weeklySalary, decimal workHoursPerDay) 
            : base(firstName, secondName)
        {
            this.WeeklySalary = weeklySalary;
            this.WorkHoursPerDay = workHoursPerDay;         
        }

        public decimal WeeklySalary
        {
            get { return this.weeklySalary; }
            private set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weeklySalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal SalaryPerHour
        {
            get
            {
                var hoursPerWeek = this.WorkHoursPerDay * 5;
                var salaryPerHour = this.WeeklySalary / hoursPerWeek;
                return salaryPerHour;
            }           
          
        }


        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append($"First Name: {base.FirstName}")
                .Append(Environment.NewLine).Append($"Last Name: {base.SecondName}")
                .Append(Environment.NewLine).Append($"Week Salary: {this.WeeklySalary:f2}")
                .Append(Environment.NewLine).Append($"Hours per day: {this.WorkHoursPerDay:f2}")
                .Append(Environment.NewLine).Append($"Salary per hour: {SalaryPerHour:f2}");

            return builder.ToString();
        }
    }
}
