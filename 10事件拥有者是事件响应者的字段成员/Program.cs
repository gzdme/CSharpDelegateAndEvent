using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10事件拥有者是事件响应者的字段成员
{
    class Program
    {
        static void Main(string[] args)
        {
            MyForm form = new MyForm(); //事件的响应者
            form.ShowDialog();
        }
    }
    class MyForm : Form
    {
        private TextBox textBox;
        private Button button;

        public MyForm()
        {
            this.textBox = new TextBox();
            this.button = new Button(); //事件的拥有者
            this.button.Top = 40;
            this.button.Text = "Say Hello";
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.button);
            this.button.Click += this.ButtonClicked; //事件，事件订阅
        }

        // 事件的处理器
        private void ButtonClicked(object sender, EventArgs e)
        {
            this.textBox.Text = "Hello World!";
        }
    }
}
