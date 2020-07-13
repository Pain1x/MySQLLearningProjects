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
    /// Interaction logic for UserControlMyAcc.xaml
    /// </summary>
    public partial class UserControlMyAcc : UserControl
    {
        public UserControlMyAcc()
        {
            InitializeComponent();
            GetAuthors("sp_GetAuthors", BoxAuthor);
            GetBookWithAuthor("sp_GetAuthorsAcc");
            GetBooks("sp_GetAllBooks", BoxBook);
        }
        //Event for geting books
        private void BoxAuthor_DropDownClosed(object sender, EventArgs e)
        {
            GetBookWithAuthor("sp_GetAuthorsAcc");
        }
        //Gets list of books into datagrid
        private void GetBookWithAuthor(string s)
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
        //Gets list of authors
        private void GetAuthors(string s, ComboBox c)
        {
            
            MainWindow.OpenCon(MainWindow.con);
            SqlCommand cmd = new SqlCommand(s, MainWindow.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            string ID = MainWindow.ID;
            SqlParameter idParam = new SqlParameter("@ReaderID", ID);
            cmd.Parameters.Add(idParam);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c.Items.Add(dr["Author"]);
            }
            MainWindow.CloseCon(MainWindow.con);
        }
        //Gets list of books
        private void GetBooks(string s, ComboBox c)
        {
            MainWindow.OpenCon(MainWindow.con);
            SqlCommand cmd = new SqlCommand(s, MainWindow.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            string ID = MainWindow.ID;
            SqlParameter IDParam = new SqlParameter("@ReaderID", ID);
            cmd.Parameters.Add(IDParam);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c.Items.Add(dr["Book"]);
            }
            MainWindow.CloseCon(MainWindow.con);
        }
        //Gets list of authors fr your acc depends on name of book
        private void GetBooksFromAcc(string s)
        {
            string ID = MainWindow.ID;
            MainWindow.OpenCon(MainWindow.con);
            SqlCommand cmd = new SqlCommand(s, MainWindow.con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter IDParam = new SqlParameter("@ReaderID", ID);
            cmd.Parameters.Add(IDParam);
            SqlParameter nameParam = new SqlParameter("@BooksName", BoxBook.Text);
            cmd.Parameters.Add(nameParam);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Progress");
            sda.Fill(dt);
            DataGridBooks.ItemsSource = dt.DefaultView;
            MainWindow.CloseCon(MainWindow.con);
        }
        //Event for getting books
        private void BoxBook_DropDownClosed(object sender, EventArgs e)
        {
            GetBooksFromAcc("sp_GetAccBooks");
        }
    }
}
