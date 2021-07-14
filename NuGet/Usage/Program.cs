using System;
using Newtonsoft.Json;

namespace Usage
{
    class Program
    {
        class Mascot
        {
            public string Name { get; init; }
            public string Team { get; init; }
            public string CatchPhrase { get; init; }
        }

        static void Main()
        {
            var mascot = new Mascot
            {
                Name = "NuGet Warrior",
                Team = "NuGet",
                CatchPhrase = "Where packages come to life"
            };

            string jsonString = JsonConvert.SerializeObject(mascot, Formatting.Indented);
            Console.WriteLine(jsonString);
        }
    }
}
