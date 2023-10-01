using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02MuscleUpShop
{
    internal class Bonuses : Customers 
    {
        public enum Discounts
        { 
        Gold,
        Silver,
        Bronz
        }

        private Discounts _membershipLevels { get; set; }
        public string MembershipLevel { get; }

        public Discounts MembershipLevels { get { return _membershipLevels; } set { _membershipLevels = value; } }

        public Bonuses(string Username, string Password, Discounts membershiplevels) :base(Username, Password)
        {
            MembershipLevels = membershiplevels;
            this.Username = Username;
            this.Password = Password;
            this.ShoppingCart = new ShoppingCart();
        }

        

        public Bonuses(string username, string password, string membershipLevel) : base(username, password)
        {
            MembershipLevel = membershipLevel;
            this.Username = username;
            this.Password = password;
            this.ShoppingCart = new ShoppingCart(); 
        }

        public override string ToString()
        { 
        return $"{Username}\n{Password}\n{MembershipLevels}\n*******************";
        }
        
        public decimal DiscountGiven(decimal price)
        {
            decimal discount = 1.0m;

            switch (MembershipLevels)
            {
                case Discounts.Gold:
                        discount = 0.85m;
                    break;
                case Discounts.Silver:
                    discount = 0.90m;
                    break;
                case Discounts.Bronz:
                    discount = 0.95m;
                    break;
            
            }
            return discount * price;
        }
    }
}
