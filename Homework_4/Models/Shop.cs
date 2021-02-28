using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_4.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Phone> Phones { get; set; }

        public int CountOfPhones(OperationSystemType type)
        {
            var count = 0;
            foreach (var phone in Phones)
            {
                if (phone.OperationSystemType == type)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

