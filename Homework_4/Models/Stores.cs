using System;
using System.Collections.Generic;

namespace Homework_4.Models
{
    public class Stores
    {
        public List<Shop> Shops { get; set; }

        public void ShowInfoAboutShop()
        {
            foreach (var shop in Shops)
            {
                Console.WriteLine($"Info about shop {shop.Id} - {shop.Name} - {shop.Description}");
                var countPhoneWithIOS = shop.CountOfPhones(OperationSystemType.IOS);
                var countPhoneWithAndroid = shop.CountOfPhones(OperationSystemType.ANDROID);
                Console.WriteLine($"In shop {countPhoneWithAndroid} phones on Android and {countPhoneWithIOS} on IOS.");
            }
        }
    }
}