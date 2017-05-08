using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08事件的拥有者和响应者是不同的类
{
    /// <summary>
    /// 事件的拥有者和响应者归属不同类型，此种事件模型是MVC,MVP等设计模式的雏形
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form(); //事件的拥有者
            Controller controller = new Controller(form); //事件的响应者
            form.ShowDialog();
        }
    }

    class Controller
    {
        private Form form;
        public Controller(Form form)
        {
            if (form != null)
            {
                this.form = form;
                this.form.Click += this.FormClicked; //事件，事件订阅
            }
        }

        //注：此处EventArgs事件参数不同于Timer类的Elapsed事件的ElapsedEventArgs参数
        //因此最好使用vs生成事件处理器比较安全
        //事件的处理器
        private void FormClicked(object sender, EventArgs e)
        {
            this.form.Text = DateTime.Now.ToString();
        }
    }
}
