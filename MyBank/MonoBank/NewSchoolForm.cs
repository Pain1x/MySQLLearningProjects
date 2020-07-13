using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MonoBank
{
    public partial class NewSchoolForm : Form
    {
        public static string i;
        public static NewSchoolForm Current;
        public NewSchoolForm()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("E:\\war3\\Projects\\MonoBank\\1.jfif");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Current = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            HelloSQL.Current.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "") 
            {
                string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=MonoBank;Integrated Security=True"; ;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT dbo.Customers ON INSERT into Customers(ID,FirstName,SecondName,PhoneNumber) VALUES (@i,@FirstName,@SecondName,@PhoneNumber) SET IDENTITY_INSERT dbo.Customers OFF", connection);
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@SecondName", textBox2.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@i", int.Parse(i));
                cmd.ExecuteNonQuery();
                SqlCommand cm = new SqlCommand("INSERT into CustomersLogs(ID,Login,Pass) VALUES (@i,@Login,@Pass)", connection);
                cm.Parameters.AddWithValue("@Login", textBox3.Text);
                cm.Parameters.AddWithValue("@Pass", textBox4.Text);
                cm.Parameters.AddWithValue("@i", int.Parse(i));
                cm.ExecuteNonQuery();
                SqlCommand c = new SqlCommand("INSERT into Chambers(ID,Money) VALUES (@i,default)", connection);
                c.Parameters.AddWithValue("@i", int.Parse(i));
                c.ExecuteNonQuery();

                connection.Close();
                label1.TextAlign = ContentAlignment.TopCenter;
                label1.Text = "You are registred succsesfully!";
         
            }
        }
        private void NewSchoolForm_Load(object sender, EventArgs e)
        {
            i = HelloSQL.counter.ToString() + 1;
        }
    }
}
