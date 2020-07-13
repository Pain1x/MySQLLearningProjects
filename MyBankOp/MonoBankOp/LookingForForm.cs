using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonoBankOp
{
    public partial class LookingForForm : Form
    {
        public static LookingForForm Current;
        public static string ID;
        public LookingForForm()
        { 
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\MonoBank\\1.jfif");
            BackgroundImageLayout = ImageLayout.Stretch;
            Current = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1.Current.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=MonoBank;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from Customers", connection);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    ID = da.GetValue(0).ToString();
                    string Log = da.GetValue(1).ToString();
                    string Pass = da.GetValue(2).ToString();
                    if (textBox1.Text == Log & textBox2.Text == Pass)
                    {
                        Hide();
                        TableForm newForm = new TableForm();
                        newForm.Show();        
                    }
                    else
                    {
                        label4.Visible = true;      
                    }
                }
                connection.Close();
            }
        }

    }
}
