using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _13自定义事件的完整声明
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(); //事件拥有者
            Waiter waiter = new Waiter(); //事件订阅者
            customer.Order += waiter.Action;  //事件，事件订阅
            customer.Action();
            customer.PayTheBill();
        }
    }
    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    // 事件处理器声明时应该跟类型声明平级
    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    public class Customer
    {
        private OrderEventHandler orderEventHandler;
        public event OrderEventHandler Order
        {
            add
            {
                this.orderEventHandler += value;
            }

            remove
            {
                this.orderEventHandler -= value;
            }
        }
        public double Bill { get; set; }
        public void PayTheBill()
        {
            Console.WriteLine("I will pay ${0}.", this.Bill);
        }
        public void WalkIn()
        {
            Console.WriteLine("Walk into the restaurant.");
        }
        public void SitDown()
        {
            Console.WriteLine("Sit down.");
        }
        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me think ...");
                Thread.Sleep(1000);
            }

            if (this.orderEventHandler != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";
                this.orderEventHandler.Invoke(this, e);
            }
        }
        public void Action()
        {
            Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }

    public class Waiter
    {
        //事件处理器
        internal void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I will server you the dish - {0}.", e.DishName);
            double price = 10;
            switch (e.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }
    }
}
