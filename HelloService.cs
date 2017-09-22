using Microsoft.AspNetCore.Mvc;

namespace Micro
{
    [Route("api/[controller]")]
    public class HelloService : Microservice
    {
        [HttpGet("/")]
        public string Hello() => "Hello World";

        [HttpGet]
        public string[] Values() => new[] {"value 1", "value 2"};

        public static void Main(string[] args) => Run<HelloService>(args);
    }
}
