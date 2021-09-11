using System;
using DataService.Infrastructure;

namespace DataService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ApplicationBootstrap().Run();
        }
    }
}
