using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Configuration;

namespace NewKindOfDLL
{
    public partial class MainWindow : Window
    {
        internal static string ID;
        internal static int counter = 0;
        internal static MainWindow Current;
        internal static SqlConnection con;
        public MainWindow()
        {
            InitializeComponent();
            Current = this;
            GetCon();
           
        }
        //Gettion a connection without storing info in code
        internal static  void GetCon()
        {
            string conString = GetConnectionString();
            con = new SqlConnection(conString);
        }
        // To avoid storing the connection string in your code,
        //it retrieves string from a configuration file.
        static private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyOwn"].ConnectionString;
        }
        //Closes connection
        internal static void CloseCon(SqlConnection c)
        {
            if (c.State == ConnectionState.Open)
            {
                c.Close();
            }
        }
        //Opens connection
        internal static void OpenCon(SqlConnection c)
        {
            if (c.State == ConnectionState.Closed)
            {
                c.Open();
            }
        }

        //Method for sign in
        private void LoginB()
        {
            //Checking if the user is in table
            OpenCon(con);
            SqlCommand check = new SqlCommand("sp_NameCheck", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter checkParam = new SqlParameter("@Name", LoginBox.Text);
            check.Parameters.Add(checkParam);
            SqlDataAdapter s = new SqlDataAdapter(check);
            DataSet d = new DataSet();
            s.Fill(d);
            int a = d.Tables[0].Rows.Count;
            //if yes then try to sign in with a password
            if (a == 1)
            {
                ID = check.ExecuteScalar().ToString();
                SqlCommand cmd = new SqlCommand("sp_Login", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter nameParam = new SqlParameter("@UserName", LoginBox.Text);
                cmd.Parameters.Add(nameParam);
                SqlParameter passParam = new SqlParameter("@Password", PassBox.Password);
                cmd.Parameters.Add(passParam);
                cmd.ExecuteNonQuery();
                SqlCommand Ban = new SqlCommand("sp_Ban", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter nParam = new SqlParameter("@UserName", LoginBox.Text);
                Ban.Parameters.Add(nParam);
                SqlParameter banParam = new SqlParameter
                {
                    ParameterName = "@Ban",
                    SqlDbType = SqlDbType.Int
                };
                banParam.Direction = ParameterDirection.Output;
                Ban.Parameters.Add(banParam);
                Ban.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                //if sign in is sucsessful
                if (i == 1 & int.Parse(banParam.Value.ToString()) == 0)
                {
                    CloseCon(con);
                    OpenCon(con);
                    Hide();
                    AccWindow nw = new AccWindow();
                    nw.Show();
                    LoginBox.Text = "Username";
                    PassBox.Password = "Password";
                    InvalidLabel.Visibility = Visibility.Hidden;
                }
                //if sign in isn't sucsessful
                else
                {
                    InvalidLabel.Visibility = Visibility.Visible;
                    counter++;
                    if (counter == 4 & counter < 5)
                    {
                        SqlCommand Banned = new SqlCommand("sp_BanChange", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        SqlParameter noParam = new SqlParameter("@UserName", LoginBox.Text);
                        Banned.Parameters.Add(noParam);
                        Banned.ExecuteNonQuery();
                        MessageBox.Show("BAN!");
                    }
                }
            }
            //if the user is not a table then just invalid login
            else
            {
                InvalidLabel.Visibility = Visibility.Visible;
            }
            CloseCon(con);
        }
        //Sign in button 
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            LoginB();
        }
        //Label for new acc 
        private void Newacclabel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Hide();
            NewAccWindow nw = new NewAccWindow();
            nw.Show();
        }
        //Label for changing a pass 
        private void Forgotacclabel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Hide();
            ForgotWindow fw = new ForgotWindow();
            fw.Show();
        }
        //Cleans the field of textbox
        private void LoginBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            LoginBox.Clear();
        }
        //Cleans the field of passbox
        private void PassBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            PassBox.Clear();
        }
        //Minimizes the window
        private void Minimize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        //Closes app
        private void Close_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //Allows to move the window
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

