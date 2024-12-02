class Program
{
    static void Main(string[] args)
    {
        var now = DateTime.Now.Second;

        Console.WriteLine("Start");

        TaskManager.Run();

        Console.WriteLine($"\nTime taken: {DateTime.Now.Second - now}s");
    }
}