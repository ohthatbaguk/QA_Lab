using Homework_4.JSON;
using Homework_4.Menu;
using Homework_4.Models;
using log4net.Config;
using Newtonsoft.Json;

namespace Homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();

            var stores = JsonConvert.DeserializeObject<Stores>(ExtendedJsonReader.ReadFile());
            ShopHelper.PrintInfoAboutShops(stores);

            //3 task 
            var listOfPhones = ShopHelper.ChoosePhoneModel(stores);

            //4 task
            ShopHelper.OrderPhone(listOfPhones[0], stores);
        }
    }
}