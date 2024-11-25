static class Acronym
{
    public static void Run(string sentence)
    {
        string[] words = sentence.Split(' ');
        string acronym = "";
        foreach (string word in words)
        {
            acronym += word[0];
        }
        Console.WriteLine(acronym.ToUpper());
    }
}

