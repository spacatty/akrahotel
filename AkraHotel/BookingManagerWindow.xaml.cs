using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace AkraHotel
{
    public partial class BookingManagerWindow : Window
    {
        private DatabaseClass _db = DatabaseClass.Instance;
        public BookingManagerWindow()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            #region FormatData

            List<string> _hotelStringList = new List<string>();
            List<Hotel> _hotelList = _db._context.Hotels.ToList();

            _hotelList.ForEach(h => _hotelStringList.Add($"{h.id} - {h.Stars} звезд(ы)"));

            #endregion

            #region LoadData

            newRoomBuilding.ItemsSource = _hotelStringList;

            roomsDataGrid.ItemsSource = _db._context.Rooms.ToList();

            #endregion

        }

        public void UpdateView()
        {
            newRoomBuilding.ItemsSource = null;
            newRoomBuilding.Items.Clear();
            newRoomBuilding.Items.Refresh();

            roomsDataGrid.ItemsSource = null;
            roomsDataGrid.Items.Clear();
            roomsDataGrid.Items.Refresh();

            Load();
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

        private void roomsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
