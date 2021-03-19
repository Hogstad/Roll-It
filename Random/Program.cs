using System;

namespace RollIT
{
    class Program
    {
        static void Main(string[] args)
        {
            //modul 3
            var Angelica = new Person {Id = 1, FirstName = "Angelica", LastName = "Hovde", Modul = 3};
            var Erik = new Person {Id = 2, FirstName = "Erik", LastName = "Isaksen", Modul = 1};
            var Flemming = new Person {Id = 3, FirstName = "Flemming", LastName = "Hogstad", Modul = 3};
            var Henrik = new Person {Id = 4, FirstName = "Henrik", LastName = "Thuve", Modul = 3};
            var Kristian = new Person {Id = 5, FirstName = "Kristian", LastName = "Nordmann", Modul = 3};
            var Mikael = new Person {Id = 6, FirstName = "Mikael", LastName = "Karlsen", Modul = 3};
            var Sigve = new Person {Id = 7, FirstName = "Sigve", LastName = "Lockertsen", Modul = 3};
            var Sindre = new Person {Id = 8, FirstName = "Sindre", LastName = "Sagen", Modul = 3};
            var Sondre = new Person {Id = 9, FirstName = "Sondre", LastName = "Eriksen", Modul = 3};
            var Stian = new Person {Id = 10, FirstName = "Stian", LastName = "Andreassen", Modul = 3};
            var Theodor = new Person {Id = 11, FirstName = "Theodor", LastName = "Berg", Modul = 3};
            var Tobias = new Person {Id = 12, FirstName = "Tobias", LastName = "Tofsland", Modul = 3};

            //modul 2
            //modul 1

            var app = new RNP(Angelica, Erik, Henrik, Kristian, Mikael, Sigve, Sondre, Stian, Theodor);
            Console.WriteLine(app.WelcomeMessage);
            while (true)
            {
                Console.Write(app.CommandPrompt);
                var command = Console.ReadLine();
                var response = app.HandleCommand(command);
                Console.WriteLine(response);
            }
        }
    }
}
