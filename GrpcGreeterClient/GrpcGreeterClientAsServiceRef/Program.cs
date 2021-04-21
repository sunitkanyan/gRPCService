using Grpc.Net.Client;
using System;

namespace GrpcGreeterClientAsServiceRef
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeter.GreeterClient client = new Greeter.GreeterClient(GrpcChannel.ForAddress("https://localhost:5001"));
            

            Console.WriteLine(".......... response from GetPersonsAsync-----------------");
            foreach (Person p in client.GetPersons(new RequestPersonModel()).Person)
            {
                Console.WriteLine("ID: " + p.Id + "  Name:" + p.FirstName + "  LastName:" + p.LastName + "  Age:" + p.Age);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
