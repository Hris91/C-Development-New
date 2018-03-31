using System;

public class Program
{
    public static void Main()
    {
        Spy spy = new Spy();

        var result = spy.StealFieldInfo("Hacker", "username", "password");
        var result1 = spy.AnalyzeAcessModifiers("Hacker");
        var result2 = spy.RevealPrivateMethods("Hacker");
        var result3 = spy.CollectGettersAndSetters("Hacker");

        Console.WriteLine(result + Environment.NewLine);
        Console.WriteLine(result1 + Environment.NewLine);
        Console.WriteLine(result2 + Environment.NewLine);
        Console.WriteLine(result3 + Environment.NewLine);    
    }
}

