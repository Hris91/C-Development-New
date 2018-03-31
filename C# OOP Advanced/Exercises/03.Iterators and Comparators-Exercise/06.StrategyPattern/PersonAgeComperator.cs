using System;
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class PersonAgeComperator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Age.CompareTo(y.Age);

            return result;
        }
    }
}
