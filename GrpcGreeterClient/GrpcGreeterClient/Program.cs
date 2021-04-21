using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
          
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient- my test message" });
            Console.WriteLine("Greeting: " + reply.Message);


             var resGetPersons = await client.GetPersonsAsync(
                              new RequestPersonModel());
            Console.WriteLine(".......... response from GetPersonsAsync-----------------");
            foreach (Person p in resGetPersons.Person)
            {
                Console.WriteLine("ID: " + p.Id + "  Name:" + p.FirstName + "  LastName:" + p.LastName + "  Age:" + p.Age);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
