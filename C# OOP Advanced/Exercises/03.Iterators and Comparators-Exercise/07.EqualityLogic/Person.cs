using System;
using System.Collections.Generic;
using System.Text;

namespace _07.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var otherPerson = (Person) obj;

            if (otherPerson.Name == this.Name && otherPerson.Age == this.Age)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Age.GetHashCode();
        }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }
    }
}
