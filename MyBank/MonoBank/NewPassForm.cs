using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MonoBank
{
    public partial class NewPassForm : Form
    {
        public static int counter = 0;
        public static NewPassForm Current;
        public NewPassForm()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("E:\\war3\\Projects\\MonoBank\\1.jfif");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Current = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            LogForm newForm = new LogForm();
            newForm.Show();
        }

        private void NewPassForm_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=MonoBank;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Pass from CustomersLogs where ID =@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(ForgotForm.ID));
            SqlDataReader da = cmd.ExecuteReader();
            da.Read();
            textBox1.Text = da.GetValue(0).ToString();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=MonoBank;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE CustomersLogs SET Pass = @SUM WHERE ID=@ID", connection);
                cmd.Parameters.AddWithValue("@SUM", textBox2.Text);
                cmd.Parameters.AddWithValue("@ID", int.Parse(ForgotForm.ID));
                cmd.ExecuteNonQuery();
                SqlCommand command = new SqlCommand("Select Pass from CustomersLogs where ID =@ID", connection);
                command.Parameters.AddWithValue("@ID", int.Parse(ForgotForm.ID));
                SqlDataReader da = command.ExecuteReader();
                da.Read();
                textBox1.Text = da.GetValue(0).ToString();
                da.Close();
                connection.Close();
                counter++;
            }
        }
    }
}
