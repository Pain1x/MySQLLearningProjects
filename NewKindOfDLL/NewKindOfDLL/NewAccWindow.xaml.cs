
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace NewKindOfDLL
{
    public partial class NewAccWindow : Window
    {
        public NewAccWindow()
        {
            InitializeComponent();
        }
        //Returns to main window
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow.Current.Show();
        }
        //Reg button do some registration
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            InsertM();
        }
        //Method for registration
        private void InsertM()
        {
            try
            {
                MainWindow.OpenCon(MainWindow.con);
                SqlCommand cmd = new SqlCommand("sp_SignUp", MainWindow.con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter nameParam = new SqlParameter("@Login", LoginBox.Text);
                cmd.Parameters.Add(nameParam);
                SqlParameter passParam = new SqlParameter("@Pass", PassBox.Password);
                cmd.Parameters.Add(passParam);
                cmd.ExecuteNonQuery();
                MainWindow.CloseCon(MainWindow.con);
                RegLabel.Visibility = Visibility.Visible;
                SecondLabel.Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                SecondLabel.Visibility = Visibility.Visible;
            }
        }
        //Closes app
        private void Close_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //Minimizes the window
        private void Minimize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Allows to move the window
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
