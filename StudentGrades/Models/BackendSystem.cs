using System.Security.Authentication.ExtendedProtection;
using System.Text.RegularExpressions;

namespace StudentGrades.Models;

public static class BackendSystem
{
    private const string RegularExpression ="^((?![0-9-!@#$%^&*./?'_+=]).)*$";
    public static readonly Dictionary<char, int> GradeSystem = new()
    {
        { 'A', 1 },
        { 'B', 2 },
        { 'C', 3 },
        { 'D', 4 },
        { 'E', 5 },
        { 'F', 6 },
    };
    private static readonly int[] GroupSystem = { 1, 2, 3, 4, 5 };
    public static bool CheckName(string name) =>Regex.IsMatch(name, RegularExpression)
                                                && !string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name);
    public static bool CheckGroup(int group)=> GroupSystem.Contains(group);
}