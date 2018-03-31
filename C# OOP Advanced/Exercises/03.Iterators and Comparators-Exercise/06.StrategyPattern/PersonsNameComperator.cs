
using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class PersonsNameComperator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Name.Length.CompareTo(y.Name.Length);

            if (result == 0)
            {
                result = x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
            }
            
            return result;
        }
    }
}
