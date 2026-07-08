
class Program
{
    static void Main(String[] args)
    {
        int age = 20;
        Console.WriteLine("int: " + age);

        long population = 8000000000L;
        Console.WriteLine("long: " + population);

        float percentage = 85.5f;
        Console.WriteLine("float: " + percentage);

        double pi = 3.1415926535;
        Console.WriteLine("double: " + pi);

        decimal salary = 50000.75m;
        Console.WriteLine("decimal: " + salary);

        char grade = 'A';
        Console.WriteLine("char: " + grade);

        string name = "Kartik";
        Console.WriteLine("string: " + name);

        bool isStudent = true;
        Console.WriteLine("bool: " + isStudent);

        ConditionalStatment p = new ConditionalStatment();
        p.displayed();

    }

}