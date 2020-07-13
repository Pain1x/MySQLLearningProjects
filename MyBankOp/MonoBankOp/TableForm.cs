using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace MonoBankOp
{
    public partial class TableForm : Form
    {
        public static TableForm Current;
        public TableForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\MonoBank\\1.jfif");
            BackgroundImageLayout = ImageLayout.Stretch;
            Current=this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            LookingForForm.Current.ShowDialog();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=MonoBank;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select FirstName,SecondName from Customers where ID=@ID", connection);
                cmd.Parameters.AddWithValue("@ID",LookingForForm.ID);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = dr.GetValue(0).ToString();
                    textBox2.Text = dr.GetValue(1).ToString();
                }
                connection.Close();
                connection.Open();
                SqlCommand cm = new SqlCommand("Select ID,Money from Chambers where ID=@ID", connection);
                cm.Parameters.AddWithValue("@ID", LookingForForm.ID);
                SqlDataReader da = cm.ExecuteReader();
                while (da.Read())
                {
                    textBox3.Text = da.GetValue(0).ToString();
                    textBox4.Text = da.GetValue(1).ToString();
                }
                connection.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            HistoryForm newForm = new HistoryForm();
            newForm.Show();
        }
    }
}
