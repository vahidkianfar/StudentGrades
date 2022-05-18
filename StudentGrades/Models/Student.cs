namespace StudentGrades.Models;

public class Student
{
    /*is it a good idea to handle exceptions in getter/setter methods?
    SOMETHING LIKE THIS:*/
    
    //private string Name{get => Name; set => Name = value ?? throw new ArgumentNullException(nameof(value));}
    
    private string _name;
    private char _grade;
    private int _group;
    private string _secretNickName ="MySecretNickName";
    
    public Student(string name, char grade, int group)
    {
        SetName(name);
        SetGrade(grade);
        SetGroup(group);
    }
    public string GetName() => _name;
    public char GetGrade() => _grade;
    private void SetName(string name)
    {
        if (!BackendSystem.CheckName(name)) 
            throw new ArgumentException("Name is not valid!");
        _name = name.Trim();
    }
    
    private void SetGrade(char grade)
    {
        if (!BackendSystem.GradeSystem.ContainsKey(char.ToUpper(grade)))
            throw new Exception("Invalid grade, valid grades are A,B,C,D,E,F");
        _grade = char.ToUpper(grade);
    }

    private void SetGroup(int groupNumber)
    {
        if (!BackendSystem.CheckGroup(groupNumber))
            throw new Exception("Invalid group number, valid group numbers are \"1,2,3,4,5\"");
        _group = groupNumber;
    }

    public void UpgradeMark()
    {
        try
        {
            _grade = BackendSystem.GradeSystem.Where(x => x.Value == BackendSystem.GradeSystem[_grade] - 1)
                .Select(x => x.Key).First();
            Console.WriteLine("\n{0} 's grade has been upgraded to \'{1}'", _name, _grade);
        }
        catch (Exception)
        {
            throw new IndexOutOfRangeException("The grade is already the highest possible!");
        }
    }
    
    public void DowngradeMark()
    {
        try
        {
            _grade = BackendSystem.GradeSystem.Where(x => x.Value == BackendSystem.GradeSystem[_grade] + 1)
                .Select(x => x.Key).First();
            Console.WriteLine("\n{0} 's grade has been downgraded to \'{1}'", _name, _grade);
        }
        catch (Exception)
        {
            throw new IndexOutOfRangeException("The grade can't be lower than 'F'!");
        }
    }
}