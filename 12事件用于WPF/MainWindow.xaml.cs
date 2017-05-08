using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _12事件用于WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //可以使用代码挂接事件处理器
            //也可以在前端增加 Click="ButtonClicked"
            this.button.Click += this.ButtonClicked;


            #region 使用委托调用
            this.button.Click += new RoutedEventHandler(this.ButtonClicked);
            #endregion

            #region 使用匿名方法挂接事件处理器，已经过时了
            //使用此方法挂接后，其他的挂接将失效，优先级比较高
            //this.button.Click += delegate (object sender, RoutedEventArgs e)
            //{
            //    this.textBox.Text = "我是用委托写的";
            //};
            #endregion

            #region 使用匿名方法挂接事件处理器，流行用法
            //使用此方法挂接后，其他的挂接将失效，优先级比较高
            this.button.Click += (sender, e) =>
            {
                this.textBox.Text = "哈哈，我才是流行的";
            };
            #endregion
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "Hello World!";
        }
    }
}
