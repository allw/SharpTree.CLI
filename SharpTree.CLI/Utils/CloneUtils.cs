using System.Text.Json;

namespace SharpTree.CLI.Utils
{
    public class CloneUtils
    {
        public static T DeepClone<T>(T obj)
        {
            string content = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(content);
        }
    }
}
