using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AkraHotel
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee _employee = DatabaseClass.Instance._context.Employees.Where(employee => employee.Login == loginInput.Text && employee.Password == passwordInput.Text).Single();
                switch (_employee.Post)
                {
                    case "Администратор":
                        DatabaseClass.Instance.CurrentUser = _employee;
                        new AdminWindow().Show();
                        Hide();
                        break;
                    case "Бухгалтер":
                        DatabaseClass.Instance.CurrentUser = _employee;
                        new AccountantWindow().Show();
                        Hide();
                        break;
                    case "Менеджер":
                        DatabaseClass.Instance.CurrentUser = _employee;
                        new BookingManagerWindow().Show();
                        Hide();
                        break;
                    case "Аналитик":
                        DatabaseClass.Instance.CurrentUser = _employee;
                        new AnalystWindow().Show();
                        Hide();
                        break;
                    default: break;
                }
            }
            catch (Exception ex) { MessageBox.Show("Произошла ошибка при попытке авторизации. Проверьте корректность введенных данных или обратитесь к администратору."); Debug.WriteLine(ex); }
            // new AnalystWindow().Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть приложение?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);

            }
            else { e.Cancel = true; }
        }
    }
}
