using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewKindOfDLL
{
    /// <summary>
    /// Interaction logic for ForgotWindow.xaml
    /// </summary>
    public partial class ForgotWindow : Window
    {
        private string Pass = "";
        public ForgotWindow()
        {
            InitializeComponent();
        }
        //Recovers the password
        private void PassChanger()
        {
            MainWindow.OpenCon(MainWindow.con);
            SqlCommand passcheck = new SqlCommand("sp_PassCheker", MainWindow.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter nParam = new SqlParameter("@Name", LoginBox.Text);
            passcheck.Parameters.Add(nParam);
            SqlDataAdapter sda = new SqlDataAdapter(passcheck);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            SqlDataReader dr = passcheck.ExecuteReader();
            while (dr.Read())
            {
               Pass = dr.GetValue(0).ToString();
            }
            MainWindow.CloseCon(MainWindow.con);
            int i = ds.Tables[0].Rows.Count;
            if (i == 1)
            {
                if (Pass == PassBox.Password)
                {
                    OldPass.Visibility = Visibility.Visible;
                    WrongCus.Visibility = Visibility.Hidden;
                    NewPass.Visibility = Visibility.Hidden;
                }
                else
                {
                    MainWindow.OpenCon(MainWindow.con);
                    SqlCommand passchng = new SqlCommand("sp_PassChanger", MainWindow.con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter nameParam = new SqlParameter("@Name", LoginBox.Text);
                    passchng.Parameters.Add(nameParam);
                    SqlParameter passParam = new SqlParameter("@Pass", PassBox.Password);
                    passchng.Parameters.Add(passParam);
                    passchng.ExecuteNonQuery();
                    MainWindow.CloseCon(MainWindow.con);
                    NewPass.Visibility = Visibility.Visible;
                    OldPass.Visibility = Visibility.Hidden;
                    WrongCus.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                WrongCus.Visibility = Visibility.Visible;
                OldPass.Visibility = Visibility.Hidden;
                NewPass.Visibility = Visibility.Hidden;

            }
        }
        //Returns to login window
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow.Current.Show();
        }
        //Minimizes the window
        private void Minimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Closes the window
        private void Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //Allows to move the window
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        //Event for return button
        private void RecoverButton_Click(object sender, RoutedEventArgs e)
        {
            PassChanger();
        }
    }
}
