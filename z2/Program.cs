int a = 2, b = 6;
Queue<int> fromAToB = new Queue<int>();
Queue<int> lessThenA = new Queue<int>();
Queue<int> moreThenB = new Queue<int>();
int number;
using (StreamReader reader = new StreamReader("file.txt"))
{
    string txt = reader.ReadLine();
    while (txt != null)
    {
        if (int.TryParse(txt.ToString(), out number))
            if (number < a)
                lessThenA.Enqueue(number);
            else if (number > b)
                moreThenB.Enqueue(number);
            else
                fromAToB.Enqueue(number);

        txt = reader.ReadLine();
    }
}
Console.WriteLine(string.Join(" ", fromAToB));
Console.WriteLine(string.Join(" ", lessThenA));
Console.WriteLine(string.Join(" ", moreThenB));