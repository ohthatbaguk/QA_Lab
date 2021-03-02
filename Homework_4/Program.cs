﻿using System;
using System.Collections.Generic;
using Homework_4.JSON;
using Homework_4.Menu;
using Homework_4.Models;
using Newtonsoft.Json;

namespace Homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var stores = JsonConvert.DeserializeObject<Stores>(ExtendedJsonReader.ReadFile());
            ShopHelper.PrintInfoAboutShops(stores);
            
            Console.WriteLine("Какой телефон вы желаете приобрести");
            string model = Console.ReadLine();
            List<Phone> listOfPhones = ShopHelper.GetPhoneByModel(model, stores);
            
            var phoneForOrdering = new Phone();
            bool isModelNotFound = true;

            Console.WriteLine("Finded models:");
           
            

            while (isModelNotFound)
            {
                if (listOfPhones.Count != 0 && listOfPhones[0].IsAvailable == false)
                {
                    Console.WriteLine("Данный товар отсутствует на складе");
                    Console.WriteLine("Повторите ввод модели:");
                    model = Console.ReadLine();
                    listOfPhones = ShopHelper.GetPhoneByModel(model, stores);
                }
                else if (listOfPhones.Count != 0 )
                {                   
                    foreach (var phone in listOfPhones)
                    {
                        Console.WriteLine("Phone: " + phone.Model + " ShopId: " + phone.ShopId);
                        phoneForOrdering = phone;
                    }
                    isModelNotFound = false;
                }
                else
                {
                    Console.WriteLine("Введенный Вами товар не найден");
                    Console.WriteLine("Повторите ввод модели:");
                    model = Console.ReadLine();
                    listOfPhones = ShopHelper.GetPhoneByModel(model, stores);
                }
            }

            bool isShopNotFound = true;
            Console.WriteLine($"В каком магазине вы хотите приобрести {listOfPhones[0].Model} ?");

            while (isShopNotFound)
            {
                var shopName = Console.ReadLine();
                if (ShopHelper.GetShop(stores, shopName) != null)
                {                  
                    if (ShopHelper.CheckIsModelAvailableAtShop(model, ShopHelper.GetShop(stores, shopName))){
                        Console.WriteLine($"Заказ {phoneForOrdering.Model} на сумму {phoneForOrdering.Price} успешно оформлен!");
                        isShopNotFound = false;
                    }
                    else
                    {
                        Console.WriteLine("Данная модель недоступна в выбранном вами магазине. Повторите выбор магазина");
                    }                    
                }
                else
                {
                    Console.WriteLine("Магазин, который вы ввели не найден. Повторите попыткук ввода: ");                   
                }
            }
        }
    }
}