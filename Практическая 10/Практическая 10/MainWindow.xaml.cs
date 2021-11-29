using System;
using System.Collections;
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
using Пример_таблицы_WPF;

namespace Практическая_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly Random _random = new Random();
        private ArrayList _integers;

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GetInformation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил Дударев И. В. ИСП-34. \nВариант 4.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void FillArray_Click(object sender, RoutedEventArgs e)
        {
            _integers = new ArrayList(6);

            for (int i = 0; i < 6; i++)
            {
                _integers.Insert(i, _random.Next(-30, 30));
            }

            dataGridMain.ItemsSource = VisualArray.ToDataTable(_integers.ToArray()).DefaultView;
        }


        private void GetCalculations_Click(object sender, RoutedEventArgs e)
        {
            int max = -30;
            int min = 30;

            foreach (int integer in _integers)
            {
                if (integer % 2 == 0 && integer > max)
                {
                    max = integer;
                }

                if (integer % int.Parse(inputValueA.Text) == 0 && integer < min)
                {
                    min = integer;
                }
            }
            MessageBox.Show($"Максимальный четный элемент - {max}\nМинимальный среди кратных {inputValueA.Text} - {min}", "Результат вычислений", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
