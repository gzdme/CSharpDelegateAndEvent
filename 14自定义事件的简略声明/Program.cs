using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _14自定义事件的简略声明
{
    /// <summary>
    /// 事件的本质是委托字段的一个包装器
    /// 这个包装器对委托字段的访问起限制作用， 相当于一个“蒙板”
    /// 封装的一个重要功能就是隐藏
    /// 事件对外界隐藏了委托实例的大部分功能，仅暴露添加/移除事件处理器
    /// </summary>
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
        // 系统会自动生成一个private OrderEventHandler Order的私有委托类型字段，隐藏在事件简化声明背后的秘密
        // 为了解决public委托类型，被滥用的情况才推出的Event事件类型
        public event OrderEventHandler Order;

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

            // 此处使用简略格式的Order事件，替代了完整声明时的orderEventHandler实例
            // 此处能使用Order事件做非空比较以及调用Order.Invoke()方法纯属不得已而为之
            // 因为使用事件的简化声明时，我们没有手动声明一个委托类型的字段
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";
                this.Order.Invoke(this, e);
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
