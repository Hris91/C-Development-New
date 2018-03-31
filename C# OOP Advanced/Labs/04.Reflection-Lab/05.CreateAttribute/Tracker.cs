using System;
using System.Reflection;

public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);

        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        foreach (var method in methods)
        {
            foreach (var attribute in method.GetCustomAttributes<SoftUniAttribute>())
            {
                Console.WriteLine(attribute.Name);
            }
        }
    }
}

