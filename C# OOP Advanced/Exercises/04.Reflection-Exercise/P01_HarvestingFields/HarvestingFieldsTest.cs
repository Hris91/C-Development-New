 using System.Linq;
 using System.Reflection;
 using System.Text;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string input;

            while ((input = Console.ReadLine()) != "HARVEST")
            {
                Console.WriteLine(GetFieldInfo(fields, input));
            }

        }

        public static string GetFieldInfo(FieldInfo[] fields, string accessMod)
        {
            var sb = new StringBuilder();
            FieldInfo[] result;

            switch (accessMod)
            {
                case "public":
                    result = fields.Where(f => f.IsPublic).ToArray();
                    break;
                case "private":
                    result = fields.Where(f => f.IsPrivate).ToArray();
                    break;
                case "protected":
                    result = fields.Where(f => f.IsFamily).ToArray();
                    break;
                case "all":
                    result = fields;
                    break;
                default:
                    throw new ArgumentException("Invalid Command");
            }

            foreach (var field in result)
            {
                if (field.IsPublic) accessMod = "public";
                if (field.IsPrivate) accessMod = "private";
                if (field.IsFamily) accessMod = "protected";

                sb.AppendLine($"{accessMod} {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
