using System;
using System.Collections.Generic;
using Homework_4.Models;

namespace Homework_4.Menu
{
    public static class ShopHelper
    {
        public static int GetPhonesByOperationSystem(Shop shop, OperationSystemType op)
        {
            var count = 0;
            foreach (var phone in shop.Phones)
            {
                if (phone.IsAvailable && phone.OperationSystemType == op)
                {
                    count++;
                }
            }

            return count;
        }

        public static List<Phone> GetPhoneByModel(string model, Stores stores)
        {
            var phones = new List<Phone>();
            foreach (var shop in stores.Shops)
            {
                foreach (var phone in shop.Phones)
                {
                    if (phone.Model == model)
                    {
                        phones.Add(phone);
                    }
                }
            }
           
            return phones;
        }

        public static void PrintInfoAboutShops (Stores stores)
        {
            foreach (var shop in stores.Shops)
            {
                Console.WriteLine($"Info about shop {shop}");
                Console.WriteLine("IOS Phones amount: " + GetPhonesByOperationSystem(shop, OperationSystemType.IOS));
                Console.WriteLine("Android Phones amount: " + GetPhonesByOperationSystem(shop, OperationSystemType.ANDROID));
            }
        }
        
        public static Shop GetShop(Stores stores, string shopName)
        {
            Shop shop = null;
            foreach (var item in stores.Shops)
            {
                if(item.Name == shopName)
                {
                    shop = item;
                }
            }

            return shop;
        }
        public static bool CheckIsModelAvailableAtShop(string model, Shop shop)
        {
            foreach(var phone in shop.Phones)
            {
                if (phone.Model == model && phone.IsAvailable == true)
                {
                    return true;
                }                    
            }
            return false;
        }
    }
}