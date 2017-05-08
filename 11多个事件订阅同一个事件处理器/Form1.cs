using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11多个事件订阅同一个事件处理器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            #region 代码添加事件处理器给button3
            //this.button3.Click += ButtonClicked;
            #endregion

            #region 使用委托调用
            this.button3.Click += new EventHandler(this.ButtonClicked);
            #endregion

            #region 使用匿名方法挂接事件处理器，已经过时了
            //使用此方法挂接后，其他的挂接将失效，优先级比较高
            //this.button3.Click += delegate (object sender, EventArgs e)
            //{
            //    this.textBox1.Text = "我是用委托写的";
            //};
            #endregion

            #region 使用匿名方法挂接事件处理器，流行用法
            //使用此方法挂接后，其他的挂接将失效，优先级比较高
            this.button3.Click += (sender, e) =>
            {
                this.textBox1.Text = "哈哈，我才是流行的";
            };
            #endregion
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            if (sender == this.button1)
            {
                this.textBox1.Text = "Hello";
            }
            if (sender == this.button2)
            {
                this.textBox1.Text = "World!";
            }
            if (sender == this.button3)
            {
                this.textBox1.Text = "哈哈，我是3号";
            }
        }
    }
}
