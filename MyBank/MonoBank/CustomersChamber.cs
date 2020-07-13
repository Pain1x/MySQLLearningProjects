using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MonoBank
{
    public partial class CustomerChamber : Form
    {
        public static int counter;
        public static int i;
        public static decimal money;
        public static string FirstName;
        public static string LastName;
        public static CustomerChamber Current;
        public CustomerChamber()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("E:\\war3\\Projects\\MonoBank\\1.jfif");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            counter = HelloSQL.counter;
            Current = this;
        
    }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            HelloSQL.Current.ShowDialog();
        }

        private void CustomerChamber_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=MonoBank;Integrated Security=True");
            con.Open();
            textBox3.Text = LogForm.SetValueForText1;
            i = int.Parse(LogForm.SetValueForText1);
            SqlCommand cmd = new SqlCommand("Select Money from Chambers where ID =@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(LogForm.SetValueForText1));
            SqlDataReader da = cmd.ExecuteReader();
            da.Read();
            textBox1.Text = da.GetValue(0).ToString();
            con.Close();

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=MonoBank;Integrated Security=True");
            connection.Open();

            SqlCommand command = new SqlCommand("Select FirstName,SecondName from Customers Where ID=@ID", connection);
            command.Parameters.AddWithValue("@ID", int.Parse(LogForm.ID));
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                FirstName = dr.GetValue(0).ToString();
                LastName = dr.GetValue(1).ToString();
            }
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=MonoBank;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            { 
                money = decimal.Parse(textBox1.Text);
                if (textBox2.Text != "" & decimal.Parse(textBox2.Text) > 0) 
                {       
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Chambers SET Money = Money +@SUM WHERE ID=@ID", connection);
                        cmd.Parameters.AddWithValue("@SUM", decimal.Parse(textBox2.Text));
                        cmd.Parameters.AddWithValue("@ID", int.Parse(textBox3.Text));
                        cmd.ExecuteNonQuery();
                    SqlCommand command = new SqlCommand("Select Money from Chambers where ID =@ID", connection);
                    command.Parameters.AddWithValue("@ID", int.Parse(textBox3.Text));
                    SqlDataReader da = command.ExecuteReader();
                    while (da.Read()) 
                    {
                        textBox1.Text = da.GetValue(0).ToString();
                    }
      

                    connection.Close();

                    connection.Open();
                 
                        SqlCommand com = new SqlCommand("Insert into History Values (@FirstName,@LastName,@i,@SUM, @Date)", connection);
                        com.Parameters.AddWithValue("@SUM" ,"Put"  + " " + decimal.Parse(textBox2.Text) + "$");
                        com.Parameters.AddWithValue("@FirstName", FirstName);
                        com.Parameters.AddWithValue("@LastName", LastName);
                        com.Parameters.AddWithValue("@Date", DateTime.Now.ToString()); 
                        com.Parameters.AddWithValue("@i",i);
                        com.ExecuteNonQuery();
                    connection.Close();
                        
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=MonoBank;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
     
                money = decimal.Parse(textBox1.Text);
                if (textBox2.Text != "" & decimal.Parse(textBox2.Text) > 0 & decimal.Parse(textBox2.Text) <= money)
                {
                    
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Chambers SET Money = Money -@SUM WHERE ID=@ID", connection);
                        cmd.Parameters.AddWithValue("@SUM", decimal.Parse(textBox2.Text));
                        cmd.Parameters.AddWithValue("@ID", int.Parse(textBox3.Text));
                        cmd.ExecuteNonQuery();
                        SqlCommand command = new SqlCommand("Select Money from Chambers where ID =@ID", connection);
                        command.Parameters.AddWithValue("@ID", int.Parse(textBox3.Text));
                        SqlDataReader da = command.ExecuteReader();
                        while (da.Read())
                        {
                            textBox1.Text = da.GetValue(0).ToString();
                        }
                        connection.Close();

                        connection.Open();

                        SqlCommand com = new SqlCommand("Insert into History Values (@FirstName,@LastName,@i,@SUM, @Date)", connection);
                        com.Parameters.AddWithValue("@SUM", "Withdrawn" + " " + decimal.Parse(textBox2.Text) + "$");
                        com.Parameters.AddWithValue("@FirstName", FirstName);
                        com.Parameters.AddWithValue("@LastName", LastName);
                        com.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        com.Parameters.AddWithValue("@i", i);
                        com.ExecuteNonQuery();
                    connection.Close();
                    
                }
               
            }
        }
    }
}

