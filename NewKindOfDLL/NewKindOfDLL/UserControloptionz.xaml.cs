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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewKindOfDLL
{
    /// <summary>
    /// Interaction logic for UserControloptionz.xaml
    /// </summary>
    public partial class UserControloptionz : UserControl
    {
        public UserControloptionz()
        {
            InitializeComponent();
        }
        //Adds a book to the library
        private void BookAdder()
        {
            try
            {
                MainWindow.OpenCon(MainWindow.con);
                SqlCommand bookadd = new SqlCommand("sp_BookAddToLibrary", MainWindow.con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter BookParam = new SqlParameter("@BName", BoxBook.Text);
                bookadd.Parameters.Add(BookParam);
                SqlParameter AuParam = new SqlParameter("@AName", BoxAuthor.Text);
                bookadd.Parameters.Add(AuParam);
                bookadd.ExecuteNonQuery();
                MainWindow.CloseCon(MainWindow.con);
                BookLabelSuc.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                BookLabelFail.Visibility = Visibility.Visible;
            }  
        }
        //Event for button
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            BookAdder();
        }
    }
}
