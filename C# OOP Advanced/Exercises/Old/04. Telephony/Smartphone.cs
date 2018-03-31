using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04.Telephony
{
    public class Smartphone : IBrowsable, ICallable
    {
        private List<string> phoneNumbers;
        private List<string> websites;

        public Smartphone()
        {
            this.phoneNumbers = new List<string>();
            this.websites = new List<string>();
        }

        public string Browse(string website)
        {
            return $"Browsing: {website}!";
        }

        public string Call(string phoneNumber)
        {
            return $"Calling... {phoneNumber}";
        }

        public void AddNumber(string number)
        {
            this.phoneNumbers.Add(number);
        }

        public void AddSite(string website)
        {
            this.websites.Add(website);
        }

        public void Print()
        {
            var regexNumbers = new Regex(@"^[0-9]+$");
            var regexSites = new Regex(@"^[^0-9]+$");

            foreach (var number in this.phoneNumbers)
            {
                if (regexNumbers.IsMatch(number))
                {
                    Console.WriteLine(Call(number));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var site in this.websites)
            {
                if (regexSites.IsMatch(site))
                {
                    Console.WriteLine(Browse(site));
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}