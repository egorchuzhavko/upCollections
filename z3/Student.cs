using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z3
{
    internal class Student : IComparable
    {
        private string name;
        private int group;
        private string mark1;
        private string mark2;
        private string mark3;

        public Student(string name, int group, string mark1, string mark2, string mark3)
        {
            this.name = name;
            this.group = group;
            this.mark1 = mark1;
            this.mark2 = mark2;
            this.mark3 = mark3;
        }

        public int CompareTo(object obj)
        {
            Student b = obj as Student;
            if (this.group == b.group) 
                return 0;
            else if (this.group > b.group) 
                return 1;
            else 
                return -1;
        }

        public static void WriteInOtherFileStudentsWithDoneSession(List<Student> students)
        {
            students.Sort();
            List<Student> list = new List<Student>();
            foreach (Student student in students)
            {
                if (student.mark1 == "good" & student.mark2 == "good" & student.mark3 == "good")
                    list.Add(student);
            }
            using(StreamWriter sw = new StreamWriter("newstudents.txt"))
            {
                foreach (Student student in list)
                    sw.WriteLine(student);
            }
        }

        public override string ToString()
        {
            return $"Имя: {name}\tГруппа: {group}\tОценки: {mark1}, {mark2}, {mark3}";
        }
    }
}
