using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClanWork.v1
{
    public partial class BankForm : Form
    {
        public BankForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\ClanWork\\Mafia.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            ActionForm.Current.Show();
        }

        private void BankForm_Load(object sender, EventArgs e)
        {
            using (ClanWork db = new ClanWork())
            {
                var money = from m in db.Banks
                            where m.id == 1
                            select m;
                foreach (Bank m in money)
                {
                    textBox2.Text = m.Money.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=ClanWork;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (textBox1.Text != "" & decimal.Parse(textBox1.Text) > 0)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Bank SET Money = Money +@SUM", connection);
                    cmd.Parameters.AddWithValue("@SUM", decimal.Parse(textBox1.Text));
                    cmd.ExecuteNonQuery();

                    SqlCommand command = new SqlCommand("Select Money from Bank", connection);
                    SqlDataReader da = command.ExecuteReader();
                    while (da.Read())
                    {
                        textBox2.Text = da.GetValue(0).ToString();
                    }

                    connection.Close();
                    connection.Open();
                    SqlCommand c = new SqlCommand("Insert into History VALUES(@1,@2)", connection);
                    c.Parameters.AddWithValue("@1", ActionForm.Pos + " " + LoginForm.Namez + " " + "put " + decimal.Parse(textBox1.Text) + " $");
                    c.Parameters.AddWithValue("@2", DateTime.Now);
                    c.ExecuteNonQuery();
                    connection.Close();


                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ActionForm.Pos=="King" | ActionForm.Pos=="Queen")
            {
                string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=ClanWork;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (textBox1.Text != "" & decimal.Parse(textBox1.Text) <= decimal.Parse(textBox2.Text) & decimal.Parse(textBox1.Text) > 0)
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Bank SET Money = Money -@SUM", connection);
                        cmd.Parameters.AddWithValue("@SUM", decimal.Parse(textBox1.Text));
                        cmd.ExecuteNonQuery();

                        SqlCommand command = new SqlCommand("Select Money from Bank", connection);
                        SqlDataReader da = command.ExecuteReader();
                        while (da.Read())
                        {
                            textBox2.Text = da.GetValue(0).ToString();
                        }
                        connection.Close();
                        connection.Open();
                        SqlCommand c = new SqlCommand("Insert into History VALUES(@1,@2)", connection);
                        c.Parameters.AddWithValue("@1", ActionForm.Pos + " " + LoginForm.Namez + " " + "withdrawn "+ decimal.Parse(textBox1.Text) +" $");
                        c.Parameters.AddWithValue("@2", DateTime.Now);
                        c.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("You don't have rights to do given action!");
            }
        }
    }
}
