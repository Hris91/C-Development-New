using System;
using System.Linq;

namespace _04.Telephony
{
    public class Program
    {
        public static void Main()
        {
            var phoneNumbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var websites = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            var smartphone = new Smartphone();

            phoneNumbers
                .ForEach(p => smartphone.AddNumber(p));

            websites
                .ForEach(w => smartphone.AddSite(w));

            smartphone.Print();
        }
    }
}