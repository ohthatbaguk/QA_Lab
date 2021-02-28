using System;
using Homework_4.JSON;
using Homework_4.Models;
using Newtonsoft.Json;

namespace Homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = new ExtendedJson();
            var stores = JsonConvert.DeserializeObject<Stores>(json.ReadFile());
            stores.ShowInfoAboutShop();

            Console.WriteLine($"What phone do you want to buy?");
            var enterPhone = Console.ReadLine();
        }
    }
}