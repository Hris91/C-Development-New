using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    public class Student : Human
    {
        private string facultyNumbr;

        public Student(string firstName, string secondName, string facultyNumber) 
            : base(firstName, secondName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumbr; }
            private set
            {
                bool checkIfValid = true;

                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(value[i]))
                    {
                        checkIfValid = false;
                        break;
                    }
                     
                }
                if (value.Length < 5 || value.Length > 10 || !checkIfValid)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumbr = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append($"First Name: {base.FirstName}")
                .Append(Environment.NewLine).Append($"Last Name: {base.SecondName}")
                .Append(Environment.NewLine).Append($"Faculty number: {this.FacultyNumber}");
            return builder.ToString();
        }
    }
}
