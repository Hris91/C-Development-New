using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    public class Human
    {
        private string firstName;
        private string secondName;

        public Human(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            protected set 
            {
                if (Char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                if (value.Length < 4)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                this.firstName = value;
            }
        }

        public string SecondName
        {
            get { return this.secondName; }
            protected set
            {
                if (Char.IsLower(value[0]))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }
                this.secondName = value;
            }
        }
    }
}
