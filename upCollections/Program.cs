using System.Text.RegularExpressions;

Stack<char>letters=new Stack<char>();
Regex regex = new Regex(@"[уеёыаоэяию]");

using(StreamReader sr = File.OpenText("file.txt"))
{
    foreach(char c in sr.ReadToEnd())
    {
        if (regex.Matches(Convert.ToString(c)).Count > 0)
            letters.Push(c);
    }
}

for(int i = letters.Count - 1; i >= 0; i--)
{
    Console.WriteLine(letters.Pop());
}