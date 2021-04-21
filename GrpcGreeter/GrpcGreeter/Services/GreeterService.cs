using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcGreeter
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override async Task<ReplyPersonModel> GetPersons(RequestPersonModel req, ServerCallContext context)
        {
            List<Person> persons = new List<Person>() {

                new Person() { Id = 1, FirstName = "david", LastName = "totti", Age = 31 },
                new Person() { Id = 2, FirstName = "lebron", LastName = "maldini", Age = 32 },
                new Person() { Id = 3, FirstName = "leo", LastName = "zidan", Age = 33 },
                new Person() { Id = 4, FirstName = "bob", LastName = "messi", Age = 34 },
                new Person() { Id = 5, FirstName = "alex", LastName = "ronaldo", Age = 35 },
                new Person() { Id = 6, FirstName = "frank", LastName = "fabregas", Age = 36 }
                };
            ReplyPersonModel replyMod  = new ReplyPersonModel();
            replyMod.Person.AddRange(persons);

              return await Task.FromResult(replyMod);
        }
    }
}
