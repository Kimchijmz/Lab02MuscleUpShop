using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.IO;
using System.Runtime.CompilerServices;
using System.IO;
using System.ComponentModel.Design;
using System.Xml;

namespace Lab02MuscleUpShop
{
    internal class Displays : Bonuses
    {

        static List<Product> products = new List<Product>
        {
        new Product ("Creatine", 100),
        new Product ("Whey Protein", 179),
        new Product ("Casein", 219),
        new Product ("Redbull 24st", 349),
        new Product ("Nocoo 24st", 399),
        new Product ("Coco Protein Bars 12st", 129),
        new Product ("Chocolate Chip Protein Bars", 149)
        };

        static List<Bonuses> customers = new List<Bonuses>
        {
            new Bonuses  ("Knatte", "123",Bonuses.Discounts.Gold ),
            new Bonuses ("Fnatte", "321", Bonuses.Discounts.Bronz),
            new Bonuses ("Tjatte", "231", Bonuses.Discounts.Silver)
            

        };

        public static Customers? loggedInUser;


        public Displays(string Username, string Password, Discounts membershiplevels) : base(Username, Password, membershiplevels)
        {

        }

        public static void DisplayMenu()
        {
            
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" WELCOME TO YOUR ONLINE SHOP ");
            Console.WriteLine(" 1 : LOG IN                  ");
            Console.WriteLine(" 2 : SIGN UP                 ");
            string userInput = Console.ReadLine();
            Console.ResetColor();

            switch (userInput)
            {
                case "1":
                    LogIn();
                    break;
                case "2":
                    SignUp();
                    break;
                default:
                    Console.WriteLine("invalid option try again..");
                    Console.ReadKey();
                    DisplayMenu();
                    break;

            }
           

        }


        public static void DisplayMainMenu()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" WElCOME TO YOUR ONLINE SHOP");
            Console.WriteLine(" 1 : MUSCLE UP SHOP ");
            Console.WriteLine(" 2 : CART ");
            Console.WriteLine(" 3 : CHECKOUT ");
            Console.WriteLine(" 4 : EXIT ");
            string option = Console.ReadLine();


            switch (option)
            {
                case "1":
                    MuscleUpShop();
                    break;
                    case "2":
                    FinalCart();
                    break;
                    case "3":
                    CheckOut();
                    break;
                    case "4":
                    DisplayMenu();
                    break;
                default:
                    Console.WriteLine("invalid option, try again");
                    Console.ReadKey();
                    DisplayMainMenu();
                    break;
            }
        }

        public static void LogIn()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(" Username : ");
            string username = Console.ReadLine();
            Console.WriteLine(" Password : ");
            string password = Console.ReadLine();

            Bonuses? newCustomer = customers.FirstOrDefault(u => u.Username == username);

            if (newCustomer != null)
            {
                if (newCustomer.Password == password)
                {
                    loggedInUser = newCustomer;
                    DisplayMainMenu();
                }
                else
                {
                    Console.WriteLine(" Wrong password.. try again!");
                    DisplayMenu();
                }
            
            }
            else 
            {
                Console.WriteLine(" User do not exist, press y for registrationof new user.");
                string userInput = Console.ReadLine();

                if (userInput == "y" || userInput == "Y")
                {
                    SignUp();
                    Console.WriteLine(" Please log in : ");
                    LogIn();
                }
                
            }

        }


        public static void SignUp()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please choose your username : ");
            string newUsername = Console.ReadLine();
            Console.WriteLine(" choose your password : ");
            string newPassword = Console.ReadLine();
            

            if (!string.IsNullOrEmpty(newUsername) && !string.IsNullOrEmpty(newPassword))
            {
                Bonuses newCustomer = new Bonuses(newUsername, newPassword, Bonuses.Discounts.Bronz);
                customers.Add(newCustomer); 

            }
            else 
            {
                Console.WriteLine("Please enter a username and a password. ");
            }

        }

    
        public static void MuscleUpShop()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  WELCOME TO MUSCLE UP SHOP ! ");
            Console.WriteLine();

              for (int i = 0; i < products.Count; i++)
              {
                  Console.WriteLine($"{i+1}. {products[i].ProductName} - {products[i].Price} kr.");
                  Console.WriteLine("---------------------------------------------------------------------------");

              }

            Console.WriteLine("Press 0 to go back previous menu!");
            int pickedProducts;
            bool success = int.TryParse(Console.ReadLine(), out pickedProducts);
            

            if (success && (pickedProducts >= 1) && (pickedProducts <= products.Count))
            {
                Product product = products[pickedProducts - 1];
                    
                    
                    loggedInUser.ShoppingCart.InStoreProducts.Add(product);
                    loggedInUser.ShoppingCart.TotalPrice += product.Price;
                    loggedInUser.ShoppingCart.TotalItems++;
                    Console.WriteLine($"{product.ProductName} have been added to your cart, press any key to keep shopping.");
                    Console.ReadKey();
                    MuscleUpShop();

            }
              
            else if (success && (pickedProducts == 0))
            {
                loggedInUser.ShoppingCart.Display();
                DisplayMainMenu();
            }
            else

            {
                Console.WriteLine("Invalid option, try again.. ");
                Console.ReadKey();
                MuscleUpShop();

            }
        }

        private static decimal totalPrice = 0;
        private static decimal calculateDiscountGiven = 0;
        public static void FinalCart()
        {
            Console.Clear();

            foreach (Product item in loggedInUser.ShoppingCart.InStoreProducts)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine($"{item.ProductName} , {item.Price}");
            }

            //calculateDiscountGiven = Math.Round(loggedInUser.discountGiven(totalPrice), 2);
            //Console.WriteLine($"Your cart contains : {loggedInUser.SelectedItems.Sum(c=>c.Quantity)} products.");
            Console.WriteLine($"Totalprice is : {loggedInUser.ShoppingCart.TotalPrice} kr.");
            //Console.WriteLine($"Your total price with your emmberhsip discount : {calculateDiscountGiven} kr");

            Console.WriteLine(" Would you like to proceed to chekout or continuing shopping?");
            Console.WriteLine(" 1 : Checkout");
            Console.WriteLine(" 2 : Shop ");
            string finalChoice = Console.ReadLine();

            switch (finalChoice)
            {
                case "1":
                    CheckOut();
                    break;
                case "2":
                    MuscleUpShop();
                    break;
                default:
                    Console.WriteLine("invalid option!");
                    Console.ReadKey();
                    FinalCart();
                    break;


            }



        }


        public static void CheckOut()
        {
            Bonuses customer = customers.FirstOrDefault(u => u.Username == loggedInUser.Username);
            Product.DifferentCurrencies(loggedInUser.ShoppingCart.TotalPrice, customer.DiscountGiven(loggedInUser.ShoppingCart.TotalPrice));
            Console.WriteLine(" How would you like to pay?");
            Console.WriteLine(" 1. Crypto");
            Console.WriteLine(" 2. Cardpayement");
            Console.WriteLine(" 3. Klarna");
            string paymentOption = Console.ReadLine();

            switch (paymentOption)
            {
                case "1":
                    Console.WriteLine(" Enter your crypto code : ");
                    Console.ReadLine();
                    Console.WriteLine(" Succesful payment!");
                    Console.WriteLine("Thanks for buying with us");
                    break;
                case "2":
                    Console.WriteLine(" enter your card number");
                    Console.ReadLine();
                    Console.WriteLine(" enter your pin : ");
                    Console.ReadLine();
                    Console.WriteLine(" thank you!");
                    break;
                case "3":
                    Console.WriteLine(" enter your email adress connected to klarna ");
                    Console.ReadLine();
                    Console.WriteLine("Thank you!");
                    break;
                default:
                    Console.WriteLine("invalid payment option, try again.. ");
                    Console.ReadKey();
                    CheckOut();
                    break;


            }


        }

        public static void LoadedCustomers()
        {
            string fileName = "Customers.txt";
            List<string> members = File.ReadAllLines(fileName).ToList();

            foreach (string member in members) 
            {
            string[] account  = member.Split(',');


                if (account.Length == 3)
                { 
                string Username = account[0];
                    string Password = account[1];
                    string MembershipLevel = account[2];

                    if (Enum.TryParse(MembershipLevel, out Bonuses.Discounts discounts))
                    {
                        Bonuses newBonus = new Bonuses(Username, Password, MembershipLevel);
                        customers.Add(newBonus);
                    }
                
                }
            }

            
        }

    }
}
