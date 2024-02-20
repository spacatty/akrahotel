using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AkraHotel
{
    public partial class AdminWindow : Window
    {
        private DatabaseClass _db = DatabaseClass.Instance;
        public AdminWindow()
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
            List<string> _hotelStringList = new List<string>();

            List<Guest> _guestList = _db._context.Guests.ToList();
            List<Employee> _employeeList = _db._context.Employees.ToList();
            List<Company> _companyList = _db._context.Companies.ToList();
            List<Hotel> _hotelList = _db._context.Hotels.ToList();

            _guestList.ForEach(g => _guestStringList.Add($"{g.id} - {g.Name}"));
            _employeeList.ForEach(e => _employeeStringList.Add($"{e.id} - {e.Login}"));
            _companyList.ForEach(c => _companyStringList.Add($"{c.id} - {c.Director}"));
            _hotelList.ForEach(h => _hotelStringList.Add($"{h.id} - {h.Stars} звезд(ы)"));

            #endregion

            #region LoadData

            newBillEmployee.ItemsSource = _employeeStringList;
            newContractEmployee.ItemsSource = _employeeStringList;
            newContractCompany.ItemsSource = _companyStringList;
            newRoomBuilding.ItemsSource = _hotelStringList;

            hotelsDataGrid.ItemsSource = _db._context.Hotels.ToList();
            employeeDataGrid.ItemsSource = _db._context.Employees.ToList();
            roomsDataGrid.ItemsSource = _db._context.Rooms.ToList();
            guestDataGrid.ItemsSource = _db._context.Guests.ToList();
            billDataGrid.ItemsSource = _db._context.Bills.ToList();
            companyDataGrid.ItemsSource = _db._context.Companies.ToList();
            contractDataGrid.ItemsSource = _db._context.Contracts.ToList();
            complainDataGrid.ItemsSource = _db._context.Complains.ToList();

            #endregion

        }

        public void UpdateView()
        {
            #region ResetItemSources

            newRoomBuilding.ItemsSource = null;
            newRoomBuilding.Items.Clear();
            newRoomBuilding.Items.Refresh();

            newBillEmployee.ItemsSource = null;
            newBillEmployee.Items.Clear();
            newBillEmployee.Items.Refresh();


            newContractEmployee.ItemsSource = null;
            newContractEmployee.Items.Clear();
            newContractEmployee.Items.Refresh();


            hotelsDataGrid.ItemsSource = null;
            hotelsDataGrid.Items.Clear();
            hotelsDataGrid.Items.Refresh();


            employeeDataGrid.ItemsSource = null;
            employeeDataGrid.Items.Clear();
            employeeDataGrid.Items.Refresh();

            roomsDataGrid.ItemsSource = null;
            roomsDataGrid.Items.Clear();
            roomsDataGrid.Items.Refresh();

            guestDataGrid.ItemsSource = null;
            guestDataGrid.Items.Clear();
            guestDataGrid.Items.Refresh();

            billDataGrid.ItemsSource = null;
            billDataGrid.Items.Clear();
            billDataGrid.Items.Refresh();

            companyDataGrid.ItemsSource = null;
            companyDataGrid.Items.Clear();
            companyDataGrid.Items.Refresh();

            contractDataGrid.ItemsSource = null;
            contractDataGrid.Items.Clear();
            contractDataGrid.Items.Refresh();

            complainDataGrid.ItemsSource = null;
            complainDataGrid.Items.Clear();
            complainDataGrid.Items.Refresh();

            #endregion

            Load();
        }

        #region Insert Button
        private void SubmitHotelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hotel _temp = new Hotel
                {
                    Catering = newHotelCatering.Text,
                    Stars = Int32.Parse(newHotelStars.Text),
                    Rooms = Int32.Parse(newHotelRooms.Text),
                    Floors = Int32.Parse(newHotelFloors.Text),
                    AvailableServices = newHotelServices.Text,
                    RoomsOnFloors = newHotelRoomsOnFloors.Text,
                    Entertainments = newHotelEntertainments.Text,
                };
                _db._context.Hotels.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();
        }

        private void SubmitRoomButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Room _temp = new Room { Class = newRoomClass.Text, Capacity = Int32.Parse(newRoomCapacity.Text), Floor = Int32.Parse(newRoomFloor.Text), Price = newRoomPrice.Text, Status = newRoomStatus.Text, Rooms = Int32.Parse(newRoomRooms.Text), BuildingRoom = Int32.Parse(newRoomBuilding.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]) };
                _db._context.Rooms.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();

        }

        private void SubmitEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Employee _temp = new Employee { Login = newEmployeeLogin.Text, Password = newEmployeePassword.Text, Post = newEmployeePost.Text, Salary = newEmployeeSalary.Text };
                _db._context.Employees.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();

        }

        private void SubmitGuestButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Guest _temp = new Guest { Name = newGuestName.Text, Email = newGuestEmail.Text, Passport = newGuestPassport.Text, Phone = newGuestPhone.Text };
                _db._context.Guests.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();

        }

        private void SubmitCompanyButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Company _temp = new Company { Details = newCompanyDetails.Text, Director = newCompanyDirector.Text, Type = newCompanyType.Text };
                _db._context.Companies.Add(_temp);
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
                    Date = newBillDate.SelectedDate
                };
                _db._context.Bills.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();

        }

        private void SubmitContractButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Contract _temp = new Contract
                {
                    Type = newContractType.Text,
                    Discount = newContractDiscount.Text,
                    Company = Int32.Parse(newContractCompany.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]),
                    Employee = Int32.Parse(newContractEmployee.Text.Split(new string[] { " - " }, StringSplitOptions.None)[0]),
                    Date = newContractDate.SelectedDate
                };
                _db._context.Contracts.Add(_temp);
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
            UpdateView();

        }

        #endregion

        #region Update Events

        private void hotelsDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Hotel selectedItem = hotelsDataGrid.SelectedItem as Hotel;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Hotel _temp = (from t in _db._context.Hotels where t.id == selectedItem.id select t).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Звезд":
                        _temp.Stars = Int32.Parse(selectedItemText);
                        break;
                    case "Комнат":
                        _temp.Rooms = Int32.Parse(selectedItemText);
                        break;
                    case "Этажей":
                        _temp.Floors = Int32.Parse(selectedItemText);
                        break;
                    case "Комнат на этаже":
                        _temp.RoomsOnFloors = selectedItemText;
                        break;
                    case "Услуги":
                        _temp.AvailableServices = selectedItemText;
                        break;
                    case "Развлечения":
                        _temp.Entertainments = selectedItemText;
                        break;
                    case "Обесп. Еды":
                        _temp.Catering = selectedItemText;
                        break;
                    default:
                        break;
                }
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

            UpdateView();
        }

        private void roomsDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Room selectedItem = roomsDataGrid.SelectedItem as Room;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Room _temp = (from t in _db._context.Rooms where t.id == selectedItem.id select t).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Класс":
                        _temp.Class = selectedItemText;
                        break;
                    case "Вместимость":
                        _temp.Capacity = Int32.Parse(selectedItemText);
                        break;
                    case "Этаж":
                        _temp.Floor = Int32.Parse(selectedItemText);
                        break;
                    case "Комнаты":
                        _temp.Rooms = Int32.Parse(selectedItemText);
                        break;
                    case "Стоимость":
                        _temp.Price = selectedItemText;
                        break;
                    case "Статус":
                        _temp.Status = selectedItemText;
                        break;
                    case "Корпус":
                        _temp.BuildingRoom = Int32.Parse(selectedItemText);
                        break;
                    default:
                        break;
                }
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

            UpdateView();
        }

        private void employeeDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {

            try
            {
                Employee selectedItem = employeeDataGrid.SelectedItem as Employee;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Employee _temp = (from t in _db._context.Employees where t.id == selectedItem.id select t).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Пост":
                        _temp.Post = selectedItemText;
                        break;
                    case "Логин":
                        _temp.Login = selectedItemText;
                        break;
                    case "Пароль":
                        _temp.Password = selectedItemText;
                        break;
                    case "Зарплата":
                        _temp.Salary = selectedItemText;
                        break;
                    default:
                        break;
                }
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

            UpdateView();

        }

        private void guestDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {

            try
            {
                Guest selectedItem = guestDataGrid.SelectedItem as Guest;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Guest _temp = (from t in _db._context.Guests where t.id == selectedItem.id select t).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Имя":
                        _temp.Name = selectedItemText;
                        break;
                    case "Паспорт":
                        _temp.Passport = selectedItemText;
                        break;
                    case "Телефон":
                        _temp.Phone = selectedItemText;
                        break;
                    case "Электронная почта":
                        _temp.Email = selectedItemText;
                        break;
                    default:
                        break;
                }
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

            UpdateView();

        }

        private void companyDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {

            try
            {
                Company selectedItem = companyDataGrid.SelectedItem as Company;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Company _temp = (from t in _db._context.Companies where t.id == selectedItem.id select t).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Тип":
                        _temp.Type = selectedItemText;
                        break;
                    case "Директор":
                        _temp.Director = selectedItemText;
                        break;
                    case "Реквизиты":
                        _temp.Details = selectedItemText;
                        break;
                    default:
                        break;
                }
                _db._context.SaveChanges();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

            UpdateView();

        }

        private void billDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {

            try
            {
                Bill selectedItem = billDataGrid.SelectedItem as Bill;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Bill _temp = (from t in _db._context.Bills where t.id == selectedItem.id select t).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Статус":
                        _temp.Status = selectedItemText;
                        break;
                    case "Сумма":
                        _temp.Amount = selectedItemText;
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

        private void contractDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {

            try
            {
                Contract selectedItem = contractDataGrid.SelectedItem as Contract;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Contract _temp = (from t in _db._context.Contracts where t.id == selectedItem.id select t).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Тип":
                        _temp.Type = selectedItemText;
                        break;
                    case "Скидка":
                        _temp.Discount = selectedItemText;
                        break;
                    case "Сотрудник":
                        _temp.Employee = Int32.Parse(selectedItemText);
                        break;
                    case "Компания":
                        _temp.Company = Int32.Parse(selectedItemText);
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

        private void complainDataGrid_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {

            try
            {
                Complain selectedItem = complainDataGrid.SelectedItem as Complain;
                string selectedItemText = (e.EditingElement as TextBox).Text;
                Complain _temp = (from t in _db._context.Complains where t.id == selectedItem.id select t).Single();
                switch (e.Column.Header.ToString())
                {
                    case "Текст":
                        _temp.Text = selectedItemText;
                        break;
                    case "Сотрудник":
                        _temp.Employee = Int32.Parse(selectedItemText);
                        break;
                    case "Гость":
                        _temp.Guest = Int32.Parse(selectedItemText);
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

        #region DeleteRow Buttons

        private void deleteHotelDataRow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Hotel selectedItem = hotelsDataGrid.SelectedItem as Hotel;
                Complain _temp = _db._context.Complains.Where(h => h.id == selectedItem.id).Single();
                _db._context.Complains.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

        }

        private void deleteRoomsDataRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Room selectedItem = roomsDataGrid.SelectedItem as Room;
                Room _temp = _db._context.Rooms.Where(t => t.id == selectedItem.id).Single();
                _db._context.Rooms.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
        }

        private void deleteEmployeeDataRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee selectedItem = employeeDataGrid.SelectedItem as Employee;
                Employee _temp = _db._context.Employees.Where(t => t.id == selectedItem.id).Single();
                _db._context.Employees.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }
        }

        private void deleteGuestDataRow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Guest selectedItem = roomsDataGrid.SelectedItem as Guest;
                Guest _temp = _db._context.Guests.Where(t => t.id == selectedItem.id).Single();
                _db._context.Guests.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

        }

        private void deleteCompanyDataRow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Company selectedItem = companyDataGrid.SelectedItem as Company;
                Company _temp = _db._context.Companies.Where(t => t.id == selectedItem.id).Single();
                _db._context.Companies.Remove(_temp);
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

        private void deleteContractDataRow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Contract selectedItem = contractDataGrid.SelectedItem as Contract;
                Contract _temp = _db._context.Contracts.Where(t => t.id == selectedItem.id).Single();
                _db._context.Contracts.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

        }

        private void deleteComplainDataRow_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Complain selectedItem = complainDataGrid.SelectedItem as Complain;
                Complain _temp = _db._context.Complains.Where(t => t.id == selectedItem.id).Single();
                _db._context.Complains.Remove(_temp);
                _db._context.SaveChanges();
                UpdateView();
            }
            catch (Exception ex) { Debug.WriteLine(ex); MessageBox.Show("Произошла ошибка. Обратитесь к администратору."); }

        }

        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть приложение?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);

            }
            else { e.Cancel = true; }
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из учетной записи?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _db.CurrentUser = null;
                new MainWindow().Show();
                Hide();
            }
        }
    }
}
