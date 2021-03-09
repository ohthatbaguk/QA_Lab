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
        private static readonly ILog Logger =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static int GetPhonesByOperationSystem(Shop shop, OperationSystemType operationSystemType)
        {
            var amount = 0;
            foreach (var phone in shop.Phones)
            {
                if (phone.IsAvailable && phone.OperationSystemType == operationSystemType)
                {
                    amount++;
                }
            }

            return amount;
        }

        public static List<Phone> ChoosePhoneModel(Stores stores)
        {
            List<Phone> foundedPhones = new List<Phone>();
            while (true)
            {
                Logger.Info("Welcome!");
                Logger.Info("What phone do you want to buy?");
                var model = Console.ReadLine();
                try
                {
                    foundedPhones = GetPhoneByModel(model, stores);
                    break;
                }
                catch (PhoneNotAvailableException e)
                {
                    Logger.Error("This product is out of stock. Please choose another model. ");
                }
                catch (PhoneNotFoundException)
                {
                    Logger.Error("The product you entered was not found. Please choose another model. ");
                }
            }

            return foundedPhones;
        }

        public static void OrderPhone(Phone phone, Stores stores)
        {
            var shop = new Shop();
            while (true)
            {
                Logger.Info($"Which store do you want to buy from {phone.Model}?");
                var shopName = Console.ReadLine();
                try
                {
                    shop = GetShop(stores, shopName);
                    if (CheckIsModelAvailableAtShop(phone.Model, shop))
                    {
                        Logger.Info($"Order {phone.Model} for the amount {phone.Price} successfully!");
                    }
                    else
                    {
                        throw new PhoneNotAvailableException(
                            "The product is out of stock. Please choose another model.");
                    }
                }
                catch (ShopNotFoundException)
                {
                    Logger.Error("No store was found! Repeat entering the store name.");
                }
            }
        }

        public static List<Phone> GetPhoneByModel(string model, Stores stores)
        {
            var phones = new List<Phone>();
            try
            {
                foreach (var shop in stores.Shops)
                {
                    foreach (var phone in shop.Phones)
                    {
                        if (phone.Model == model && phone.IsAvailable)
                        {
                            phones.Add(phone);
                        }

                        else if (phone.Model == model && !phone.IsAvailable)
                        {
                            throw new PhoneNotAvailableException("Phone not available.");
                        }
                    }
                }
            }
            catch (PhoneNotAvailableException ex)
            {
                Logger.Error(ex.Message);
            }

            if (phones.Count == 0)
                throw new PhoneNotFoundException();

            return phones;
        }

        public static void PrintInfoAboutShops(Stores stores)
        {
            foreach (var store in stores.Shops)
            {
                Logger.Info($"{store}");
                Logger.Info("IOS Phones amount: " + GetPhonesByOperationSystem(store, OperationSystemType.Ios));
                Logger.Info("Android Phones amount: " + GetPhonesByOperationSystem(store, OperationSystemType.Android));
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

            if (shop == null)
            {
                throw new ShopNotFoundException();
            }

            return shop;
        }

        public static bool CheckIsModelAvailableAtShop(string model, Shop shop)
        {
            foreach (var phone in shop.Phones)
            {
                if (phone.Model == model && phone.IsAvailable)
                {
                    return true;
                }
            }

            return false;
        }
    }
}