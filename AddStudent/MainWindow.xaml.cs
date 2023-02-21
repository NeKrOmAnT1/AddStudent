using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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




namespace AddStudent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_save_click(object sender, RoutedEventArgs e)
        {
            Student student= new Student()
            {
                Group1 = tb_Group.Text,
                FullName = tb_Name.Text,
                GuidStudent = Guid.NewGuid()
            };
            tb_Group.Text = student.Group1;
            tb_Guid.Text=student.GuidStudent.ToString();
            tb_Name.Text = student.FullName;
            string json=JsonSerializer.Serialize<Student>(student);
            SaveFileDialog saveFile= new SaveFileDialog();
            saveFile.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
            saveFile.ShowDialog();
            if(string.IsNullOrEmpty(saveFile.FileName))
            {
                return;
            }
            
            File.WriteAllText(saveFile.FileName, json);

        }

        private void btn_open_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile= new OpenFileDialog();
            openFile.Filter= "Json files(*.json)|*.json|All files(*.*)|*.*";
            openFile.ShowDialog();
            string jsonstring=File.ReadAllText(openFile.FileName);
            if (string.IsNullOrEmpty(openFile.FileName))
            {
                return;
            }
            Student student= JsonSerializer.Deserialize<Student>(jsonstring);
            tb_Group.Text = student.Group1;
            tb_Guid.Text = student.GuidStudent.ToString(); 
            tb_Name.Text = student.FullName;


        }
    }
}
