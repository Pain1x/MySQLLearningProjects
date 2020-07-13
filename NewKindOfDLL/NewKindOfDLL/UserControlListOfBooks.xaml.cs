using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
using System.Xml;

namespace NewKindOfDLL
{
    /// <summary>
    /// Interaction logic for UserControlOptions.xaml
    /// </summary>
    public partial class UserControlListOfBooks : UserControl
    {
        public UserControlListOfBooks()
        {
            InitializeComponent();
            GetA("sp_Authors", BoxAuthor);
            GetB("sp_GetBooks");

        }
        //Gets list of authors
        private void GetA(string s, ComboBox c)
        {
            MainWindow.OpenCon(MainWindow.con);
            SqlCommand cmd = new SqlCommand(s, MainWindow.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c.Items.Add(dr["Author"]);
            }
            MainWindow.CloseCon(MainWindow.con);

        }
        //Gets list of books into datagrid
        private void GetB(string s)
        {
            MainWindow.OpenCon(MainWindow.con);
            SqlCommand cmd = new SqlCommand(s, MainWindow.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter nameParam = new SqlParameter("@Name", BoxAuthor.Text);
            cmd.Parameters.Add(nameParam);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Books");
            sda.Fill(dt);
            DataGridBooks.ItemsSource = dt.DefaultView;
            MainWindow.CloseCon(MainWindow.con);
        }
        //Updates the datagrid after selection
        private void BoxAuthor_DropDownClosed(object sender, EventArgs e)
        {
            GetB("sp_GetBooks");
        }
        //Disables the label for book adding
        private void DataGridBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddLabel.Visibility = Visibility.Hidden;
        }
        //Addbutton event
        private void AddButon_Click(object sender, RoutedEventArgs e)
        {
            AddABook();
        }
        //Adds the book to acc
        private void AddABook() 
        {
           try
           {
                if (DataGridBooks.SelectedItems.Count > 0)
                {
                    DataRowView dataRowView = (DataRowView)DataGridBooks.SelectedItem;
                    string Name = Convert.ToString(dataRowView.Row[0]);
                    MainWindow.OpenCon(MainWindow.con);
                    SqlCommand cmd = new SqlCommand("sp_UpdateProgress", MainWindow.con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    string ID = MainWindow.ID;
                    SqlParameter RIDParam = new SqlParameter("@ReaderID", ID);
                    cmd.Parameters.Add(RIDParam);
                    SqlParameter BooksNameParam = new SqlParameter("@BooksName", Name);
                    cmd.Parameters.Add(BooksNameParam);
                    SqlParameter AuthorsNameParam = new SqlParameter("@AuthorsName", BoxAuthor.Text);
                    cmd.Parameters.Add(AuthorsNameParam);
                    cmd.ExecuteNonQuery();
                    MainWindow.CloseCon(MainWindow.con);
                    AddLabel.Visibility = Visibility.Visible;
                    AlreadyLabel.Visibility = Visibility.Hidden;
                }
           }
           catch (Exception ex)
           {
                AlreadyLabel.Visibility = Visibility.Visible;
                AddLabel.Visibility = Visibility.Hidden;
           }
        }
    }
}


