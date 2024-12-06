class Program
{
    static void Main()
    {
        int x = 5;
        Foo();

        static void Foo() => Console.WriteLine(x);
    }
}