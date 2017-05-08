using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15自定义事件的再简化
{
    /// <summary>
    /// 事件的本质是委托字段的一个包装器
    /// 这个包装器对委托字段的访问起限制作用， 相当于一个“蒙板”
    /// 封装的一个重要功能就是隐藏
    /// 事件对外界隐藏了委托实例的大部分功能，仅暴露添加/移除事件处理器的功能
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
    // 可以使用系统的EventHandler替换，因此此处已没必要声明OrderEventHandler
    //public delegate void OrderEventHandler(Customer customer, OrderEventArgs e); 

    public class Customer
    {
        // 系统会自动生成一个private OrderEventHandler Order的私有委托类型字段，隐藏在事件简化声明背后的秘密
        // 为了解决public委托类型，被滥用的情况才推出的Event事件类型
        // public event OrderEventHandler Order;
        // 使用系统的EventHandler
        // 事件命名应该使用正确的时态
        public event EventHandler Order;

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
            this.OnOrder("Kongpao Chicken", "large");
        }

        /// 面向对象设计原则要求每个方法只能做一件事情，因此将事件触发放置出来单独做一个函数
        /// 访问级别设置为protected，不能用public，因此其可以被其派生类访问，而不能被外界访问
        protected void OnOrder(string dishName, string size)
        {
            // 此处使用简略格式的Order事件，替代了完整声明时的orderEventHandler实例
            // 此处能使用Order事件做非空比较以及调用Order.Invoke()方法纯属不得已而为之
            // 因为使用事件的简化声明时，我们没有手动声明一个委托类型的字段
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishName;
                e.Size = size;
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
        // 使用系统基类 EventHandler, 应对事件拥有者及事件消息对象进行强制转换
        internal void Action(object sender, EventArgs e)
        {
            Customer customer = sender as Customer;
            OrderEventArgs orderInfo = e as OrderEventArgs;
            Console.WriteLine("I will server you the dish - {0}.", orderInfo.DishName);
            double price = 10;
            switch (orderInfo.Size)
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
