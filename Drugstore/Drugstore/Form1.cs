using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Drugstore
{
   
    public partial class Form1 : Form
    {
       public static Form1 Current;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=Drugstore;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\Drugstore\\drugstore.jfif");
            BackgroundImageLayout = ImageLayout.Stretch;

            Current = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'drugstoreDataSet.Stash' table. You can move, or remove it, as needed.
            this.stashTableAdapter.Fill(this.drugstoreDataSet.Stash);

            comboBox1.SelectedIndex = 1;
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    stashBindingSource.Filter = string.Empty;
                }
                else
                    stashBindingSource.Filter = string.Format("{0}='{1}'",comboBox1.Text,textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            DeliveryForm nf = new DeliveryForm();
            nf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from stash", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            SoldForm nf = new SoldForm();
            nf.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CurrentForm nf = new CurrentForm();
            nf.Show();
        }
    }
}
