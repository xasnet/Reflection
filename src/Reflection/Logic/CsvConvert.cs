using System.Reflection;
using System.Text;

namespace Reflection.Logic;

public static class CsvConvert
{
    public static string SerializeObject<T>(T obj)
    {
        var type = typeof(T);
        var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
        var objProperties = type.GetFields(bindingFlags);

        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine(string.Join(",", objProperties.Select(p => p.Name)));
        stringBuilder.Append(string.Join(",", objProperties.Select(p => type.GetField(p.Name)!.GetValue(obj))));

        return stringBuilder.ToString();
    }

    public static T DeserializeObject<T>(string csvString)
    {
        var lines = csvString.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length != 2)
        {
            throw new Exception("Incorrect csv string");
        }

        var fields = lines[0].Split(",");
        var values = lines[1].Split(",");

        Type type = typeof(T);

        var obj = Activator.CreateInstance(type);

        for (var i = 0; i < fields.Length; i++)
        {
            var fieldName = fields[i].Trim();
            var fieldInfo = type.GetField(fieldName)!;

            if (fieldInfo.FieldType == typeof(int))
            {
                var isParsed = int.TryParse(values[i], out var val);

                fieldInfo.SetValue(obj, val);
            }
            else
            {
                fieldInfo.SetValue(obj, values[i]);
            }
        }

        return (T)obj!;
    }

}
