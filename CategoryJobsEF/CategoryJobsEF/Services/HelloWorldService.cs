using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryJobsEF.Services
{
    public class HelloWorldService: IHelloWorldService
    {
        public string Hello { get; set; }

        public HelloWorldService()
        {
            Hello = Guid.NewGuid().ToString();
        }

        public string GetHelloWorld()
        {
            return "Hello World " + Hello;
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloWorld();
    }
}
