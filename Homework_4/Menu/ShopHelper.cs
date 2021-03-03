using System;
using System.Collections.Generic;
using System.Reflection;
using Homework_4.Exceptions;
using Homework_4.Models;
using log4net;

namespace Homework_4.Menu
{
    public static class ShopHelper
    {
        static ILog logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static int GetPhonesByOperationSystem(Shop shop, OperationSystemType op)
        {
            var amount = 0;
            foreach (var phone in shop.Phones)
            {
                if (phone.IsAvailable && phone.OperationSystemType == op)
                {
                    amount++;
                }
            }

            return amount;
        }
        public static List<Phone> ChoosePhoneModel(Stores stores)
        {
            List<Phone> listOfPhones = new List<Phone>();
            while (true)
            {
                logger.Info("Welcome!");
                logger.Info("What phone do you want to buy?");
                var model = Console.ReadLine();
                try
                {
                    listOfPhones = GetPhoneByModel(model, stores);
                    break;
                }
                catch (PhoneNotAvailableException e)
                {
                    logger.Error("This product is out of stock. Please choose another model: ");
                }
                catch (PhoneNotFoundException)
                {
                    logger.Error("The product you entered was not found. Please choose another model: ");
                }
            }
            return listOfPhones;
        }
        public static void OrderPhone(Phone phone, Stores stores)
        {
            var shop = new Shop();
            while (true)
            {
                logger.Info($"Which store do you want to buy from {phone.Model}?");
                var shopName = Console.ReadLine();
                try
                {
                    shop = GetShop(stores, shopName);
                    if (CheckIsModelAvailableAtShop(phone.Model, shop))
                        logger.Info($"Order {phone.Model} for the amount {phone.Price} successfully!");
                    else
                        throw new PhoneNotAvailableException();
                    break;
                }
                catch (ShopNotFoundException)
                {
                    logger.Error("No store was found! Repeat entering the store name:");
                }
                catch (PhoneNotAvailableException)
                {
                    logger.Error("This model is not available in the store" + shop.Name + " . Please, choose another store");
                }
            }
        }
        public static List<Phone> GetPhoneByModel(string model, Stores stores)
        {
            var phones = new List<Phone>();
            foreach (var shop in stores.Shops)
            {
                foreach (var phone in shop.Phones)
                {
                    if (phone.Model == model && phone.IsAvailable)
                    {
                        phones.Add(phone);
                    }
                    else if(phone.Model == model && !phone.IsAvailable)
                    {
                        throw new PhoneNotAvailableException();
                    }
                }
            }
            if(phones.Count == 0)
                throw new PhoneNotFoundException();
          
            return phones;
        }
        public static void PrintInfoAboutShops(Stores stores)
        {
            foreach (var store in stores.Shops)
            {
                logger.Info($"{store}");
                logger.Info("IOS Phones amount: " + GetPhonesByOperationSystem(store, OperationSystemType.IOS));
                logger.Info("Android Phones amount: " + GetPhonesByOperationSystem(store, OperationSystemType.ANDROID));
            }
        }
        public static Shop GetShop(Stores stores, string shopName)
        {
            Shop shop = null;
            foreach (var item in stores.Shops)
            {
                if (item.Name == shopName)
                {
                    shop = item;
                }
            }
            if(shop == null)
            {
                throw new ShopNotFoundException();
            }
           
            return shop;
        }
        public static bool CheckIsModelAvailableAtShop(string model, Shop shop)
        {
            foreach(var phone in shop.Phones)
            {
                if (phone.Model == model && phone.IsAvailable )
                {
                    return true;
                }                    
            }
            return false;
        }
    }
}