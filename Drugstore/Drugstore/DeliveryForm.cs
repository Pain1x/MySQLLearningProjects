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

namespace Drugstore
{
    public partial class DeliveryForm : Form
    {
        string Namez;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=Drugstore;Integrated Security=True");
        public DeliveryForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\Drugstore\\warehouse.jpg");
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Form1.Current.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Name from Stash where Name = @1", con);
            cmd.Parameters.AddWithValue("@1",textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Namez = dr.GetValue(0).ToString();
            }
            con.Close();
            con.Open();
            if (Namez == textBox1.Text & textBox2.Text == "" & textBox3.Text != "")
            {
                SqlCommand cа = new SqlCommand("Update Stash  Set Quantity= Quantity + @2 where Name = @3", con);
                cа.Parameters.AddWithValue("@2", textBox3.Text);
                cа.Parameters.AddWithValue("@3", textBox1.Text);
                cа.ExecuteNonQuery();
            }
            else if(Namez==textBox1.Text)
            {
                SqlCommand cф = new SqlCommand("Update Stash  Set Price=@1,Quantity=Quantity + @2 where Name = @3", con);
                cф.Parameters.AddWithValue("@1", textBox2.Text);
                cф.Parameters.AddWithValue("@2", textBox3.Text);
                cф.Parameters.AddWithValue("@3", textBox1.Text);
                cф.ExecuteNonQuery();
            }
           else
            {
                SqlCommand c = new SqlCommand("Insert into Stash  Values(@1,@2,@3)", con);
                c.Parameters.AddWithValue("@1", textBox1.Text);
                c.Parameters.AddWithValue("@2", textBox2.Text);
                c.Parameters.AddWithValue("@3", textBox3.Text);
                c.ExecuteNonQuery();
            }
            con.Close();

            SqlDataAdapter da = new SqlDataAdapter("select * from stash", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
         
        private void  DeliveryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'drugstoreDataSet1.Stash' table. You can move, or remove it, as needed.
            this.stashTableAdapter.Fill(this.drugstoreDataSet1.Stash);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Name from Stash", con);

            cmd.ExecuteNonQuery();

            SqlDataReader dr = cmd.ExecuteReader();

            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                mycoll.Add(dr.GetString(0));
            }
            textBox1.AutoCompleteCustomSource = mycoll;
            con.Close();  
        }

    }
}
