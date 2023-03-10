using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Oil_station_task
{
    public class Fuel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
    public class Food
    {
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public override string ToString()
        {
            return $"{FoodName}";
        }

    }
}
