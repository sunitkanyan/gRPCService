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

            Console.WriteLine("Press any key try product.proto...");
            Console.ReadKey();


            Console.WriteLine("Starting product proto...");

            ProductService.ProductServiceClient productClient = new ProductService.ProductServiceClient(GrpcChannel.ForAddress("https://localhost:5001"));

            Console.WriteLine(".......... response from productClient get all-----------------");

            foreach (Product product  in productClient.GetAll(new Empty()).Products)
            {
                Console.WriteLine("ID: " + product.ProductId + "  Name:" + product.Name + "  Value:" + product.Value + "  Amount:" + product.Amount+"  brand: "+product.Brand);
            }

            Console.WriteLine(".......... response end-----------------");

            Console.WriteLine("Press any key to exit... to add a product");
            Console.ReadKey();

            Product newpro = new Product() { ProductId = 11, Name = "ProductTest", Value = 12, Amount = 13, Brand = "abc" };

            productClient.InsertAsync(newpro);

            //check 

            Console.WriteLine(".......... response from productClient get all-----------------");

            foreach (Product product in productClient.GetAll(new Empty()).Products)
            {
                Console.WriteLine("ID: " + product.ProductId + "  Name:" + product.Name + "  Value:" + product.Value + "  Amount:" + product.Amount + "  brand: " + product.Brand);
            }

            Console.WriteLine(".......... response end-----------------");

            Console.WriteLine("Press any key to... to remove product ");
            Console.ReadKey();

            

            productClient.DeleteAsync(new ProductId() { Id=0});

            //check
            Console.WriteLine(".......... response from productClient get all-----------------");

            foreach (Product product in productClient.GetAll(new Empty()).Products)
            {
                Console.WriteLine("ID: " + product.ProductId + "  Name:" + product.Name + "  Value:" + product.Value + "  Amount:" + product.Amount + "  brand: " + product.Brand);
            }

            Console.WriteLine(".......... response end-----------------");


            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();


        }
    }
}
