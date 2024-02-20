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
using System.Windows.Shapes;
using System.Threading;

namespace AkraHotel
{
    /// <summary>
    /// Логика взаимодействия для AnalystWindow.xaml
    /// </summary>
    public partial class AnalystWindow : Window
    {
        public AnalystWindow()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            DatabaseClass.Instance.ReloadContext();
            analystComplainsDataGrid.ItemsSource = DatabaseClass.Instance._context.Complains.ToList();

            List<string> _guestStringList = new List<string>();
            List<string> _employeeStringList = new List<string>();

            List<Guest> _guestList = DatabaseClass.Instance._context.Guests.ToList();
            List<Employee> _employeeList = DatabaseClass.Instance._context.Employees.ToList();

            _guestList.ForEach(g => _guestStringList.Add($"{g.id} - {g.Name}"));
            _employeeList.ForEach(e => _employeeStringList.Add($"{e.id} - {e.Login}"));

            newComplainGuest.ItemsSource = _guestStringList;
            newComplainEmployee.ItemsSource = _employeeStringList;
        }
        public void UpdateView()
        {
            newComplainGuest.ItemsSource = null;
            newComplainGuest.Items.Clear();
            newComplainGuest.Items.Refresh();

            newComplainEmployee.ItemsSource = null;
            newComplainEmployee.Items.Clear();
            newComplainEmployee.Items.Refresh();

            analystComplainsDataGrid.ItemsSource = null;
            analystComplainsDataGrid.Items.Clear();
            analystComplainsDataGrid.Items.Refresh();
            Load();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Complain _complain = new Complain { Text = newComplainText.Text, Employee = Int32.Parse(newComplainEmployee.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]), Guest = Int32.Parse(newComplainGuest.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]) };
                DatabaseClass.Instance._context.Complains.Add(_complain);
                DatabaseClass.Instance._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();
        }

        private void analystComplainsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Complain selectedItem = analystComplainsDataGrid.SelectedItem as Complain;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Complain _complain = (from c in DatabaseClass.Instance._context.Complains where c.id == selectedItem.id select c).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Текст":
                        _complain.Text = selectedItemText;
                        break;
                    case "Сотрудник":
                        _complain.Employee = Int32.Parse(selectedItemText);
                        break;
                    case "Гость":
                        _complain.Guest = Int32.Parse(selectedItemText);
                        break;

                    default:
                        break;
                }
                DatabaseClass.Instance._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

            UpdateView();
        }
        private void deleteDataRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Complain selectedItem = analystComplainsDataGrid.SelectedItem as Complain;
                Complain _complain = DatabaseClass.Instance._context.Complains.Where(c => c.id == selectedItem.id).Single();
                DatabaseClass.Instance._context.Complains.Remove(_complain);
                DatabaseClass.Instance._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из учетной записи?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DatabaseClass.Instance.CurrentUser = null;
                new MainWindow().Show();
                Hide();
            }
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
