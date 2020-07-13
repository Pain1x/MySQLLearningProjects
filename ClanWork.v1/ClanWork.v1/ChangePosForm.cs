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
    public partial class ChangePosForm : Form
    {
        public static int lastID;
        public ChangePosForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\ClanWork\\Mafia.png");
            BackgroundImageLayout = ImageLayout.Stretch;

            using (ClanWork db = new ClanWork())
            {
                comboBox1.DataSource = db.Members.ToList();
            }

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            ActionForm.Current.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Member mb = comboBox1.SelectedItem as Member;
            textBox1.Text = mb.Position;
            lastID = mb.id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=ClanWork;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Members SET Position = @SUM WHERE ID=@ID", connection);
                cmd.Parameters.AddWithValue("@SUM",comboBox2.Text);
                cmd.Parameters.AddWithValue("@ID", lastID);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            using (ClanWork db = new ClanWork())
            {
                comboBox1.DataSource = db.Members.ToList();
            }
            comboBox1.Focus();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand c = new SqlCommand("Insert into History VALUES(@1,@2)", connection);
                c.Parameters.AddWithValue("@1", ActionForm.Pos + " " + LoginForm.Namez + " changed position of " + comboBox1.SelectedIndex + " from " +textBox1.Text +" to " + comboBox2.Text);
                c.Parameters.AddWithValue("@2", DateTime.Now);
                c.ExecuteNonQuery();
                connection.Close();
            }


        }
    }
}
