using z4;

Dictionary<string, List<Signer>> disks = new Dictionary<string, List<Signer>>();

List<string> songs=new List<string>();
songs.Add("Less Than Zero");
songs.Add("Sacrifice");
songs.Add("Take My Breath");
disks.Add("Disk 1", new List<Signer>());
disks["Disk 1"].Add(new Signer("The Weekend", songs));

disks.Add("Disk 2", new List<Signer>());
songs = new List<string>();
songs.Add("Borderline");
songs.Add("Why Won't They Talk To Me?");
disks["Disk 2"].Add(new Signer("Tame Impala", songs));

songs = new List<string>();
songs.Add("Good news");
songs.Add("Self Care");
disks["Disk 1"].Add(new Signer("Mac Miller", songs));


ShowDictionary(disks);
Console.WriteLine(new string('-', 10) + "\n\nВывод информации по диску" + new string('-', 10));
ShowDictionaryByDisk(disks, "Disk 1");
Console.WriteLine(new string('-', 30) + "\nДобавление новой песни\n");
AddSong(disks, "Disk 1", "The Weekend", "Low key");
ShowDictionary(disks);
Console.WriteLine(new string('-', 30));
DeleteSong(disks, "Disk 2", "Tame Impala", "Borderline");
ShowDictionaryByDisk(disks, "Disk 2");
Console.WriteLine(new string('-', 30));
AddDisk(disks, "Disk 3");
ShowDictionaryByDisk(disks, "Disk 3");
Console.WriteLine(new string('-', 30));
DeleteDisk(disks, "Disk 1");
ShowDictionary(disks);
Console.WriteLine(new string('-', 30));
InfoAboutSigner(disks, "Tame Impala");



static void ShowDictionary(Dictionary<string, List<Signer>> disks)
{
    foreach (var key in disks.Keys)
    {
        Console.WriteLine(key + ":");
        foreach (var signer in disks[key])
        {
            Console.WriteLine("\nSigner - " + signer.name+"\n\nSongs:");
            foreach (var song in signer.songs)
                Console.WriteLine(song);
            Console.WriteLine();
        }
        Console.WriteLine("\n");
    }
}

static void ShowDictionaryByDisk(Dictionary<string, List<Signer>> disks, string disk)
{
    if (disks.ContainsKey(disk))
    {
        Console.WriteLine(disk + ":");
        foreach (var signer in disks[disk])
        {
            Console.WriteLine("\nSigner - " + signer.name + "\n\nSongs:");
            foreach (var song in signer.songs)
                Console.WriteLine(song);
            Console.WriteLine();
        }
    }
    else
        Console.WriteLine("Такого диска нет.");
}

static void AddSong(Dictionary<string, List<Signer>> disks, string disk,string signername, string song)
{
    if (disks.ContainsKey(disk))
    {
        bool flag = false;
        foreach (var signer in disks[disk])
            if (signername == signer.name)
            {
                flag = true;
                signer.songs.Add(song);
            }
        if (!flag)
            disks[disk].Add(new Signer(signername, song));
        Console.WriteLine("Песня добавлена");
    }
    else
    {
        disks.Add(disk, new List<Signer>());
        disks[disk].Add(new Signer(signername,song));
    }
}
static void DeleteSong(Dictionary<string, List<Signer>> disks, string disk, string signername, string song)
{
    if (disks.ContainsKey(disk))
    {
        foreach (var signer in disks[disk])
            if (signername == signer.name)
                signer.songs.Remove(song);
        Console.WriteLine("Песня удалена");
    }
    else
    {
        Console.WriteLine("Такого диска нет");
    }
}

static void AddDisk(Dictionary<string, List<Signer>> disks, string key)
{
    if (!disks.ContainsKey(key))
    {
        disks.Add(key, new List<Signer>());
        Console.WriteLine("Диск Создан.");
    }
    else
        Console.WriteLine("Диск уже создан до этого момента..");
}

static void DeleteDisk(Dictionary<string, List<Signer>> disks, string key)
{
    if (disks.ContainsKey(key))
    {
        disks.Remove(key);
        Console.WriteLine("Диск удалён.");
    }
    else
        Console.WriteLine("Такого диска нет.");
}

static void InfoAboutSigner(Dictionary<string, List<Signer>> disks, string signername)
{
    bool flag = false;
    foreach(var disk in disks.Keys)
    {
        foreach(var signer in disks[disk])
        {
            if (signer.name == signername)
            {
                flag = true;
                Console.WriteLine(signername+"\nПесни:\n");
                foreach (var song in signer.songs)
                    Console.WriteLine(song);
                break;
            }
            if (flag)
                break;
        }
        if(!flag)
            Console.WriteLine("Такой исполнитель не найден");
    }
}