using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Online_Radio_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateTime = new DateTime(2017, 1, 1, 0, 0, 0);
            var n = int.Parse(Console.ReadLine());
            var songCounter = 0;
           
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                        .Split(new[] { ';'}, StringSplitOptions.RemoveEmptyEntries);

                var time = input[2]
                    .Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries)                    
                    .ToArray();


                int minutes = 0;
                int seconds = 0;

                var minutesAreValid = int.TryParse(time[0], out minutes);
                var secondsAreValid = int.TryParse(time[1], out seconds);

                if (input.Length != 3 || !minutesAreValid || !secondsAreValid)
                {
                    Console.WriteLine("Invalid song.");
                    continue;
                }
                try
                {
                    
                    var song = new Song(input[0], input[1], minutes, seconds);
                                       
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

               
                
                Console.WriteLine("Song added.");
                songCounter++;

                dateTime = dateTime.AddMinutes(minutes);
                dateTime = dateTime.AddSeconds(seconds);

            }
            Console.WriteLine($"Songs added: {songCounter}");
            Console.WriteLine($"Playlist length: {dateTime.Hour}h {dateTime.Minute}m {dateTime.Second}s");

        }
    }
}
