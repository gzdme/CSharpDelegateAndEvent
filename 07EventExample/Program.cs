using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _07EventExample
{
    /// <summary>
    /// 事件模型的五个组成部分
    /// 1、事件的拥有者
    /// 2、事件
    /// 3、事件的响应者
    /// 4、事件处理器
    /// 5、事件订阅
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(); //事件的拥有者，包含事件Elapsed
            timer.Interval = 500;
            
            Boy boy = new Boy(); //事件的响应者
            Girl girl = new Girl(); //事件的响应者
            //事件Elapsed
            timer.Elapsed += boy.Action; //事件订阅
            timer.Elapsed += girl.Action; //事件订阅
            timer.Start(); 
            Console.ReadKey();
        }
        class Boy
        {
            // 事件处理器
            internal void Action(object sender, ElapsedEventArgs e)
            {
                Console.WriteLine("Jump!");
            }
        }
        class Girl
        {
            // 事件处理器
            internal void Action(object sender, ElapsedEventArgs e)
            {
                Console.WriteLine("Sing!");
            }
        }
    }
}
