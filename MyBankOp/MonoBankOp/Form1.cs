
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace MonoBankOp
{
    public partial class Form1 : Form
    {
        public static Form1 Current;
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("E:\\war3\\Projects\\MonoBank\\1.jfif");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Current = this;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=MonoBank;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from TrustedUsers", connection);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    string ID = da.GetValue(0).ToString();
                    string Log = da.GetValue(1).ToString();
                    string Pass = da.GetValue(2).ToString();
                    if (textBox1.Text == Log & textBox2.Text == Pass)
                    {
                        Hide();
                        LookingForForm newForm = new LookingForForm();
                        newForm.Show();
                    }
                    else if(textBox1.Text=="" & textBox1.Text != Log & textBox2.Text == "" & textBox2.Text != Pass)
                    {
                        label3.Visible = true;
                    }
                }
                connection.Close();
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
