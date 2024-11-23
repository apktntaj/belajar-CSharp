class Program
{
    static void Main(string[] args)
    {
        string[] questions = {
            "Siapa Tuhanmu?",
            "Apa Agamamu?",
            "Siapa Nabimu?",
        };

        string[] answers = {
            "Allah",
            "Islam",
            "Muhammad",
        };

        int score = 0;

        Console.WriteLine("");
        int i = 0;
        do
        {
            Console.WriteLine(questions[i]);
            string answer = Console.ReadLine();
            if (answer.ToLower() == answers[i].ToLower())
            {
                Console.WriteLine("Benar!");
                score+=10;
            }
            else
            {
                Console.WriteLine("Salah!");
            }
        } while (i < questions.Length);
        Console.WriteLine("Skor akhir: " + score);
    }
}