using System;
using System.Threading.Tasks;

namespace RDToBigQueryFunction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            Console.WriteLine("Hello Gurizada!");

            var function = new Function();

            await function.InsertJsonIntoBigQuery();
        }
    }
}
