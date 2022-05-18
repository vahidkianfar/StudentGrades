using StudentGrades.Models;

while (true)
{
    try
    {
        //Console.Clear();
        Console.WriteLine("\n***Welcome to the Student Grades Application***\n");
        
        Console.Write("Please enter student name: ");
        var studentName = Console.ReadLine()!.Trim();
        
        //I use these IF statements just for this particular Menu to improve functionality.
        //But I have implemented these validations on SetName(), SetGrade(), and SetGroup() methods in Student class.
        if (!BackendSystem.CheckName(studentName))
            throw new ArgumentException("Name is not valid!");
                
        Console.Write("Please enter student grade: ");
        var studentGrade = char.Parse(Console.ReadLine()!.ToUpper());
        
        
        if (!BackendSystem.GradeSystem.ContainsKey(studentGrade))
            throw new Exception("Invalid grade, valid grades are A,B,C,D,E,F");
    
        Console.Write("Please enter student group: ");
        var studentGroup = int.Parse(Console.ReadLine()!);
        if (!BackendSystem.CheckGroup(studentGroup))
            throw new Exception("Invalid group number, valid group numbers are \"1,2,3,4,5\"");
    
        var student = new Student(studentName, studentGrade, studentGroup);
        Console.WriteLine("\nSelect a number to proceed:");
        Console.WriteLine("1. Upgrade Student grade");
        Console.WriteLine("2. Downgrade Student grade");
        Console.WriteLine("3. Get Student info");
        Console.WriteLine("4. Exit\n");
        Console.Write("Please enter your choice: ");
        var option = int.Parse(Console.ReadLine()!);
        switch (option)
        {
            case 1:
                student.UpgradeMark();
                break;
            case 2:
                student.DowngradeMark();
                break;
            case 3:
                Console.WriteLine("\n---> Details: {0}'s grade in math is \'{1}\' <------",
                    student.GetName(), student.GetGrade());
                break;
            case 4:
                Environment.Exit(0);
                break;
        }
        Console.WriteLine("\nPress any key to continue... or press \'q\' to exit");
        if (Console.ReadKey().Key == ConsoleKey.Q)
            Environment.Exit(0);
    }
    catch (Exception e)
    {
        Console.WriteLine("\n------> System Message: {0} <------" , e.Message);
        Console.WriteLine("\nPress any key to continue... or press \'q\' to exit");
        if (Console.ReadKey().Key == ConsoleKey.Q)
            Environment.Exit(0);
    }
}