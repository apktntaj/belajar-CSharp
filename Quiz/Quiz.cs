using System;

  class Quiz
    {
        string[] questions =
        {
            "Siapa Tuhanmu?",
            "Apa Agamamu?",
            "Siapa Nabimu?",
        };

        string[] answers =
        {
            "Allah",
            "Islam",
            "Muhammad",
        };

        int score = 0;

        public void Start()
        {
            int i = 0;
            do
            {
                Console.WriteLine(questions[i]);
                string? answer = Console.ReadLine();
                answer ??= "";

                if (answer.ToLower() == answers[i].ToLower())
                {
                    Console.WriteLine("Benar!");
                    score+=10;
                }
                else
                {
                    Console.WriteLine("Salah!");
                }
                i++;
            } while (i < questions.Length);
            Console.WriteLine("Skor akhir: " + score);
        }
    
}