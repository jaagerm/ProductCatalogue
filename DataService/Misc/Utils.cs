using System.Linq;

namespace DataService.Misc
{
    public static class Utils
    {
        public static string[] CommaSeparatedStringToArray(string csvString)
        {
            return csvString.Split(',').ToArray();
        }
    }
}
