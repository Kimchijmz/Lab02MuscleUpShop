using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02MuscleUpShop
{
    internal class Product
    {

        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Product(string productname, decimal price)
        {
            ProductName = productname;
            Price = price;
        }

        public static void DifferentCurrencies(decimal price, decimal newPrice)
        {
            decimal euro = price / 11.54m;
            decimal dollar = price / 10.92m;

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Please choose a currency you´d like to see your price in : ");
            Console.WriteLine( $" 1 : SEK {price}");
            Console.WriteLine( $" 2 : EURO {Math.Round(euro, 2)}");
            Console.WriteLine( $" 3 : DOLLAR {Math.Round(dollar,2)} ");

            Console.WriteLine(" With the discount given : ");
            euro = newPrice / 11.54m;
            dollar = newPrice / 10.92m;
            Console.WriteLine($" 1 : SEK {newPrice}");

            Console.WriteLine($" 2 : EURO {Math.Round(euro, 2)}");

            Console.WriteLine($" 3 : DOLLAR {Math.Round(dollar, 2)} ");

            string chosenCurrency = Console.ReadLine();

            switch (chosenCurrency)
            {
                case "1":
                    Console.WriteLine($"The total price is : {newPrice} SEK.");
                    break;
                case "2":
                    Console.WriteLine($"The total price is : {Math.Round(euro,2)} EUROS.");
                    break;
                case "3":
                    Console.WriteLine($"The total price is  : {Math.Round(dollar,2)} DOLLARS. ");
                    break;

            }

        }
    }
}
