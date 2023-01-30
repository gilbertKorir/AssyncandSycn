// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
namespace AssyncAwaitDemo
{
    class Program 
    {
        static async Task Main(string[] args)
        {
            var startTime = DateTime.Now;
            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready");

            var taskBread = ToastBreadAsync(2);
            var taskBacon = FryBaconAsync(3);
            var taskEggs = FryEggAsync(2);

            Toast bread = await taskBread;
            ApplyBlueband(bread);
            ApplyJam(bread);
            Console.WriteLine("Toast is ready");

            Eggs egg = await taskEggs;
            Console.WriteLine("Eggs are ready");

            Bacon bacon = await taskBacon;
            Console.WriteLine("Bacon is ready");

            var endTime = DateTime.Now;

            Console.WriteLine($"Total time taken is:" + (endTime - startTime).Seconds + " minutes\n");

        }

        //User defined methods
        private static void ApplyJam(Toast bread)
        {
            Console.WriteLine("Applying jam on the toast");
        }

        private static void ApplyBlueband(Toast bread)
        {
            Console.WriteLine("Applying blueband on the toast");
        }

        private async static Task<Toast> ToastBreadAsync(int slices)
        {

            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("putting slice of bread on a toaster");
            }
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from the toaster");
            return new Toast();
        }

        private async static Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in a pan");
            Console.WriteLine("cooking first side of the bacon");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            await Task.Delay(3000);
            Console.WriteLine("put bacon on plate");
            return new Bacon();
        }

        private async static Task<Eggs> FryEggAsync(int howMany)
        {
            Console.WriteLine($"cracking {howMany} egss");
            Console.WriteLine("cooking eggs...");
            await Task.Delay(6000);
            Console.WriteLine("putting egss on plate");

            return new Eggs();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("pouring coffee...");
            return new Coffee();
        }


    }
}
