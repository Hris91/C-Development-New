using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        var type = Type.GetType(classToInvestigate);

        var fields = type.GetFields(
            BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {classToInvestigate}");

        Object classInstance = Activator.CreateInstance(type, new object[]{ });
     
        foreach (var field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
        {              
            var fieldName = field.Name;
            var fieldValue = field.GetValue(classInstance);

            sb.AppendLine($"{fieldName} = {fieldValue}");
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();

        Type type = Type.GetType(className);

        var fields = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
           
        foreach (var property in properties)
        {
            if (property.GetMethod?.IsPrivate == true)
            {
                sb.AppendLine($"{property.GetMethod.Name} have to be public!");
            }        
        }

        foreach (var property in properties)
        {
            if (property.SetMethod?.IsPublic == true)
            {
                sb.AppendLine($"{property.SetMethod.Name} have to be private!");
            }        
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type type = Type.GetType(className);

        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in methods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string investigateClass)
    {
        Type type = Type.GetType(investigateClass);

        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        var sb = new StringBuilder();

        foreach (var property in methods.Where(p => p.Name.StartsWith("get")).ToArray())
        {
            sb.AppendLine($"{property.Name} will return {property.ReturnType.FullName}");
        }

        foreach (var property in methods.Where(p => p.Name.StartsWith("set")).ToArray())
        {
            sb.AppendLine($"{property.Name} will set field of {property.GetParameters().First().ParameterType}");
        }

        return sb.ToString().TrimEnd();
    }
}

