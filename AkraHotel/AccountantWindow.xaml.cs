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

namespace AkraHotel
{
    public partial class AccountantWindow : Window
    {
        private DatabaseClass _db = DatabaseClass.Instance;
        public AccountantWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            _db.ReloadContext();

            #region FormatData

            List<string> _guestStringList = new List<string>();
            List<string> _employeeStringList = new List<string>();
            List<string> _companyStringList = new List<string>();
            List<string> _roomStringList = new List<string>();
            List<string> _billStringList = new List<string>();

            List<Guest> _guestList = _db._context.Guests.ToList();
            List<Employee> _employeeList = _db._context.Employees.ToList();
            List<Company> _companyList = _db._context.Companies.ToList();
            List<Room> _roomList = _db._context.Rooms.ToList();
            List<Bill> _billList = _db._context.Bills.ToList();

            _guestList.ForEach(g => _guestStringList.Add($"{g.id} - {g.Name}"));
            _employeeList.ForEach(e => _employeeStringList.Add($"{e.id} - {e.Login}"));
            _companyList.ForEach(c => _companyStringList.Add($"{c.id} - {c.Director}"));
            _roomList.ForEach(r => _roomStringList.Add($"{r.id} - {r.BuildingRoom} корпус (класс {r.Class})"));
            _billList.ForEach(b => _billStringList.Add($"{b.id} - {b.Status} ({b.Amount})"));

            #endregion

            #region LoadData

            newBillEmployee.ItemsSource = _employeeStringList;

            newBillGuestBill.ItemsSource = _billStringList;
            newBillGuestGuest.ItemsSource = _guestStringList;

            newBillCompanyBill.ItemsSource = _billStringList;
            newBillCompanyCompany.ItemsSource = _companyStringList;

            newBillRoomBill.ItemsSource = _billStringList;
            newBillRoomRoom.ItemsSource = _roomStringList;

            billDataGrid.ItemsSource = _db._context.Bills.ToList();
            serviceDataGrid.ItemsSource = _db._context.Services.ToList();
            billGuestDataGrid.ItemsSource = _db._context.BillGuests.ToList();
            billCompanyDataGrid.ItemsSource = _db._context.BillCompanies.ToList();
            billRoomDataGrid.ItemsSource = _db._context.RoomBills.ToList();

            #endregion

        }

        public void UpdateView()
        {
            #region ResetItemSources

            newBillEmployee.ItemsSource = null;
            newBillEmployee.Items.Clear();
            newBillEmployee.Items.Refresh();

            newBillGuestBill.ItemsSource = null;
            newBillGuestBill.Items.Clear();
            newBillGuestBill.Items.Refresh();

            newBillGuestGuest.ItemsSource = null;
            newBillGuestBill.Items.Clear();
            newBillGuestBill.Items.Refresh();

            newBillCompanyBill.ItemsSource = null;
            newBillCompanyBill.Items.Clear();
            newBillCompanyBill.Items.Refresh();

            newBillCompanyBill.ItemsSource = null;
            newBillCompanyBill.Items.Clear();
            newBillCompanyBill.Items.Refresh();

            newBillRoomBill.ItemsSource = null;
            newBillRoomBill.Items.Clear();
            newBillRoomBill.Items.Refresh();

            newBillRoomRoom.ItemsSource = null;
            newBillRoomBill.Items.Clear();
            newBillRoomBill.Items.Refresh();

            newBillEmployee.ItemsSource = null;
            newBillEmployee.Items.Clear();
            newBillEmployee.Items.Refresh();

            billDataGrid.ItemsSource = null;
            billDataGrid.Items.Clear();
            billDataGrid.Items.Refresh();

            serviceDataGrid.ItemsSource = null;
            serviceDataGrid.Items.Clear();
            serviceDataGrid.Items.Refresh();

            billGuestDataGrid.ItemsSource = null;
            billGuestDataGrid.Items.Clear();
            billGuestDataGrid.Items.Refresh();

            billCompanyDataGrid.ItemsSource = null;
            billCompanyDataGrid.Items.Clear();
            billCompanyDataGrid.Items.Refresh();

            billRoomDataGrid.ItemsSource = null;
            billRoomDataGrid.Items.Clear();
            billRoomDataGrid.Items.Refresh();


            #endregion

            Load();
        }


        #region Submit Buttons

        private void SubmitServiceButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Service _temp = new Service { Amount = newServiceAmount.Text, Type = newServiceType.Text };
                _db._context.Services.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();

        }

        private void SubmitBillButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Bill _temp = new Bill
                {
                    Amount = newBillAmount.Text,
                    Status = newBillStatus.Text,
                    Employee = Int32.Parse(newBillEmployee.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]),
                    Date = DateTime.Parse(newBillDate.Text)
                };
                _db._context.Bills.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();


        }

        private void submitBillGuest_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                BillGuest _temp = new BillGuest { Bill = Int32.Parse(newBillGuestBill.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]), Guest = Int32.Parse(newBillGuestGuest.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]) };
                _db._context.BillGuests.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();

        }

        private void submitBillCompany_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                BillCompany _temp = new BillCompany { Bill = Int32.Parse(newBillCompanyBill.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]), Company = Int32.Parse(newBillCompanyCompany.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]) };
                _db._context.BillCompanies.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();

        }

        private void submitBillRoom_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                RoomBill _temp = new RoomBill { Bill = Int32.Parse(newBillRoomBill.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]), Room = Int32.Parse(newBillRoomRoom.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]) };
                _db._context.RoomBills.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();

        }

        #endregion

        #region Delete Buttons

        private void deleteServiceDataRow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Service selectedItem = serviceDataGrid.SelectedItem as Service;
                Service _temp = _db._context.Services.Where(t => t.id == selectedItem.id).Single();
                _db._context.Services.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

        }

        private void deleteBillDataRow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Bill selectedItem = billDataGrid.SelectedItem as Bill;
                Bill _temp = _db._context.Bills.Where(t => t.id == selectedItem.id).Single();
                _db._context.Bills.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

        }

        private void deleteBillGuestRow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                BillGuest selectedItem = billGuestDataGrid.SelectedItem as BillGuest;
                BillGuest _temp = _db._context.BillGuests.Where(t => t.id == selectedItem.id).Single();
                _db._context.BillGuests.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

        }

        private void deleteBillCompanyRow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                BillCompany selectedItem = billCompanyDataGrid.SelectedItem as BillCompany;
                BillCompany _temp = _db._context.BillCompanies.Where(t => t.id == selectedItem.id).Single();
                _db._context.BillCompanies.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

        }

        private void deleteBillRoomDataRow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                RoomBill selectedItem = billRoomDataGrid.SelectedItem as RoomBill;
                RoomBill _temp = _db._context.RoomBills.Where(t => t.id == selectedItem.id).Single();
                _db._context.RoomBills.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

        }


        #endregion

        #region Update Events

        private void serviceDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            try
            {
                Service selectedItem = serviceDataGrid.SelectedItem as Service;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Service _temp = (from t in _db._context.Services where t.id == selectedItem.id select t).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Стоимость":
                        _temp.Amount = selectedItemText;
                        break;
                    case "Тип":
                        _temp.Type = selectedItemText;
                        break;
                    default:
                        break;
                }
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

            UpdateView();

        }

        private void billDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            try
            {
                Bill selectedItem = billDataGrid.SelectedItem as Bill;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Bill _temp = (from t in _db._context.Bills where t.id == selectedItem.id select t).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Сумма":
                        _temp.Amount = selectedItemText;
                        break;
                    case "Статус":
                        _temp.Status = selectedItemText;
                        break;
                    case "Сотрудник":
                        _temp.Employee = Int32.Parse(selectedItemText);
                        break;
                    case "Дата":
                        _temp.Date = DateTime.Parse(selectedItemText);
                        break;
                    default:
                        break;
                }
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

            UpdateView();

        }

        #endregion

        private void logoutButton_Click(object sender, RoutedEventArgs e)
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
