using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _05多播委托
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Red };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Yellow };

            Action action1 = new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);

            #region 单播委托
            //单播委托
            //action1.Invoke();
            //action2.Invoke();
            //action3.Invoke();
            #endregion

            #region 多播委托
            //多播委托
            //action1 += action2; //将action2合并到action1中
            //action1 += action3; //将action3合并到action1中
            //action1.Invoke(); //只调用action1，将会执行三个action绑定的三个方法
            #endregion

            #region 直接同步调用
            //stu1.DoHomework();
            //stu2.DoHomework();
            //stu3.DoHomework();
            #endregion

            #region 使用委托，间接同步调用
            //action1.Invoke();
            //action2.Invoke();
            //action3.Invoke();
            #endregion

            #region 使用多播委托，间接同步调用
            //action1 += action2;
            //action1 += action3;
            //action1.Invoke();
            #endregion

            #region 使用委托，隐式异步调用
            // 使用异步调用时，会发生资源争抢，为避免多个线程之间的争抢，需要为资源加锁
            // 为资源加锁为高级内容，留作日后学习的内容
            // 使用委托的BeginInvoke()方法实现，委托的隐式异步调用
            //action1.BeginInvoke(null, null);
            //action2.BeginInvoke(null, null);
            //action3.BeginInvoke(null, null);
            #endregion

            #region 不使用委托，使用原始的Thread类进行，显示异步调用
            //Thread thread1 = new Thread(new ThreadStart(stu1.DoHomework));
            //Thread thread2 = new Thread(new ThreadStart(stu2.DoHomework));
            //Thread thread3 = new Thread(new ThreadStart(stu3.DoHomework));
            //
            //thread1.Start();
            //thread2.Start();
            //thread3.Start();
            #endregion

            #region 使用C#封装的，Task高级用法，显示异步调用
            Task task1 = new Task(stu1.DoHomework);
            Task task2 = new Task(stu2.DoHomework);
            Task task3 = new Task(stu3.DoHomework);

            task1.Start();
            task2.Start();
            task3.Start();
            #endregion

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main thread {0}.", i);
                Thread.Sleep(500);
            }
        }
    }

    class Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }

        public void DoHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine("Student {0} doning homework {1} hour(s).", this.ID, i);
                Thread.Sleep(500);
            }
        }
    }
}
