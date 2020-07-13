using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Configuration;

namespace MonoBankOp
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\MonoBank\\1.jfif");
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            LookingForForm.Current.Show();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=MonoBank;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select Action,Date from History where BankBoxID=@ID", connection);
                cmd.Parameters.AddWithValue("@ID",int.Parse(LookingForForm.ID));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
           
        }
    }
}
