using z3;

List<Student> students = new List<Student>();

using (StreamReader sr = new StreamReader("input.txt"))
{
    while (!sr.EndOfStream)
    {
        var temp = sr.ReadLine().Split(",");
        students.Add(new Student(temp[0], Convert.ToInt32(temp[1]), temp[2], temp[3], temp[4]));
    }
}

Student.WriteInOtherFileStudentsWithDoneSession(students);