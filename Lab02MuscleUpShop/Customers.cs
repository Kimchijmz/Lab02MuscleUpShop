using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02MuscleUpShop
{
    internal class Customers 
    {
        private string _username;
        private string _password;
        private ShoppingCart _shoppingCart;

        public string Username { get { return _username; } set { _username = value; } }
        public string Password { get { return _password; } set { _password = value; } }

        public ShoppingCart ShoppingCart { get { return _shoppingCart; } set { _shoppingCart = value; } }

        public Customers(string username, string password)
        {
            Username = username;
            Password = password;
            ShoppingCart  = new ShoppingCart();
           
        }

        internal decimal DiscountGiven(decimal totalPrice)
        {

            throw new NotImplementedException();
        }

    }
}
