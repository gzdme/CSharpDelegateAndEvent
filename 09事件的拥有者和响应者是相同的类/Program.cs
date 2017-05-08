using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09事件的拥有者和响应者是相同的类
{
    class Program
    {
        static void Main(string[] args)
        {
            MyForm myForm = new MyForm(); //事件的拥有者，事件的响应者
            myForm.Click += myForm.FormClicked; //事件，事件订阅
            myForm.ShowDialog();
        }
    }
    class MyForm : Form
    {
        //事件的处理器
        internal void FormClicked(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
