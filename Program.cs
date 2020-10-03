using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Buyer
    {
        public string Name { get; set; }
        public int Money { get; set; }
      
        public Buyer()
        {
            Name = "no_name";
            Money = 0;
        }

        public Buyer(int money , string Name)
        {
            this.Money = money;
            this.Name = Name;
        }

        public void Purchase_sale(bool Change)
        {
            if (Change == true)
            {
                Money -= 100;
                Console.WriteLine($"Buyer {Name} buys shares");
            }
            else if (Change == false)
            {
                Money += 100;
                Console.WriteLine($"Buyer {Name} sells shares");
            }

        }

        public override string ToString()
        {
            return $"name:{Name}\n" +
                   $"Money:{Money}\n";
                  
        }
    }


    class Trader
    {
        public string Name { get; set; }
        public int Money { get; set; }


        public Trader()
        {
            Name = "no_name";
            Money = 0;
        }
        public Trader(int money, string Name)
        {
            this.Money = money;
            this.Name = Name;
        }

        public void Purchase_sale(bool Change)
        {
            if (Change == false)
            {
                Money -= 100;
                Console.WriteLine($"Trader {Name} buys shares");
            }
            else if (Change == true)
            {
                Money += 100;
                Console.WriteLine($"Trader {Name} sells shares");
            }

        }

        public override string ToString()
        {
            return $"name:{Name}\n" +
                   $"Money:{Money}\n";
        }
    }

   


    public delegate void ChangeOfСourse(bool Change);
    class Exchange
    {
        public bool Chenge_cours { get; set; }

        private Random rnd = new Random();

        public event ChangeOfСourse Change;

        public Exchange()
        {
            Chenge_cours = true;
        }

        public void  Change_of_course()
        {
            Console.WriteLine("--course Change--\n");

            int rand = rnd.Next(2);

            if(rand == 0)
            {
                Chenge_cours = false;
            }
            else if(rand == 1)
            {
                Chenge_cours = true;
            }

            Change.Invoke(Chenge_cours);

        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            Exchange exc = new Exchange();
            Buyer buyer1 = new Buyer(1000,"vasa");
            Buyer buyer2 = new Buyer(2000,"vlad");
            Trader trader1 = new Trader(1000,"ivan");
            exc.Change += buyer1.Purchase_sale;
            exc.Change += buyer2.Purchase_sale;
            exc.Change += trader1.Purchase_sale;

            while (buyer1.Money>0 && buyer2.Money > 0 && trader1.Money > 0)
            {
                Console.WriteLine("--all buyers--");
                Console.WriteLine(buyer1.ToString());
                Console.WriteLine(buyer2.ToString());
                Console.WriteLine(trader1.ToString());

                exc.Change_of_course();
               
                System.Threading.Thread.Sleep(500);
                Console.Clear();
                
            }
            Console.WriteLine("the auction is over");



        }
    }
}
