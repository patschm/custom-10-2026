using Bogus;

namespace Link;

internal class Program
{
    static void Main(string[] args)
    {
        List<Person> people = CreateList(1000);

        //Console.WriteLine("Geef eerste letter voornaam:");
       // string fl = Console.ReadLine().ToUpper();
        //var list = people.Where(FirstnameStartsWithA);
        //var list = people.Where( p => p.Firstname.StartsWith(fl));

        var projection = people.Select(p => new  { First = p.Firstname, Last = p.Lastname });

        foreach(var p in projection)
        {
            Console.WriteLine($"{p.First} {p.Last}");
        }

        //foreach (Person p1 in list)
        //{
        //    Console.WriteLine(p1);
        //}
    }

    static bool FirstnameStartsWithA(Person p)
    {
        return p.Firstname.StartsWith("A");
    }


    static bool FirstnameStartsWithJ(Person p)
    {
        return p.Firstname.StartsWith("J");
    }


    private static List<Person> CreateList(int v)
    {
        var faker = new Faker<Person>("nl");
       return  faker.RuleFor(p => p.Firstname, f => f.Name.FirstName())
            .RuleFor(p => p.Lastname, f => f.Name.LastName())
            .RuleFor(p => p.Age, f => f.Random.Int(0, 123))
            .Generate(v)
            .ToList();
    }

    private class Per
    {
        public string First { get; set; }
        public string Last { get; set; }
    }
}
