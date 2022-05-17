using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            webBrowser1.Navigate(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "index.html"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt_Main = new DataTable("DefInHRInsurance");
            //创建3列表头  
            dt_Main.Columns.Add("IdCardNumber", Type.GetType("System.String"));
            dt_Main.Columns.Add("Name", Type.GetType("System.String"));
            dt_Main.Columns.Add("Month", Type.GetType("System.String"));

            for (int i = 0; i < 100; i++)
            {
                DataRow dr_main = dt_Main.NewRow();//创建新行  
                dt_Main.Rows.Add(dr_main);//将新行加入到表中 
                //给新行 各单元格赋值  
                dr_main["IdCardNumber"] = "主键"+i;
                dr_main["Name"] = "名称" + i;
                dr_main["Month"] = "月份" + i;  
            }

            string result = JsonConvert.SerializeObject(dt_Main, new DataTableConverter());

            // 调用JavaScript的messageBox方法，并传入参数
            object[] objects = new object[1];
            objects[0] = result;
            this.webBrowser1.InvokeScript("senddata", objects);
        }
    }
}
