using Drugstore;
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
    public partial class CurrentForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=Drugstore;Integrated Security=True");
        public static object qua;
        public CurrentForm()
        {
            InitializeComponent();

            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\Drugstore\\cart.jpg");
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void CurrentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'drugstoreDataSet3.CurrentExchange' table. You can move, or remove it, as needed.
            this.currentExchangeTableAdapter.Fill(this.drugstoreDataSet3.CurrentExchange);

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

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm = new SqlCommand("DELETE CurrentExchange where ID>1", con);
            cm.ExecuteNonQuery();
            con.Close();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Sum(Price * Quantity) from CurrentExchange", con);
            object i = cmd.ExecuteScalar();
            MessageBox.Show(i.ToString());
            SqlCommand cm = new SqlCommand("INSERT INTO SOLD Select Name, Price, Quantity, (SELECT GETDATE())  from CurrentExchange", con);
            cm.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand q = new SqlCommand("Select Quantity from Stash where Name=@1", con);
            q.Parameters.AddWithValue("@1", textBox1.Text);
            SqlDataReader dr = q.ExecuteReader();
            while (dr.Read())
            {
                qua = dr.GetValue(0).ToString();
            }
            con.Close();


            if (int.Parse(qua.ToString()) >= int.Parse(textBox2.Text))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CurrentExchange VALUES(@1,(Select Price from Stash where Name = @1),@3,(Select Price * @3 from Stash where Name =@1))", con);
                cmd.Parameters.AddWithValue("@1", textBox1.Text);
                cmd.Parameters.AddWithValue("@3", textBox2.Text);
                cmd.ExecuteNonQuery();

                SqlCommand se = new SqlCommand("Update Stash Set Quantity=Quantity-@1 where Name=@2", con);
                se.Parameters.AddWithValue("@1", textBox2.Text);
                se.Parameters.AddWithValue("@2", textBox1.Text);
                se.ExecuteNonQuery();
                

                con.Close();
            }
            else
            {
                MessageBox.Show("You don't have so many in stock!");
            }

           




            SqlDataAdapter da = new SqlDataAdapter("select * from CurrentExchange", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand se = new SqlCommand("Update Stash Set Quantity=Quantity+@1 where Name=@2", con);
            se.Parameters.AddWithValue("@1", textBox2.Text);
            se.Parameters.AddWithValue("@2", textBox1.Text);
            se.ExecuteNonQuery();
            con.Close();
            DrugstoreEntities db = new DrugstoreEntities();
            db.CurrentExchanges.Load();

            if (dataGridView2.SelectedRows.Count > 0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                CurrentExchange ce = db.CurrentExchanges.Find(id);
                db.CurrentExchanges.Remove(ce);
                db.SaveChanges();

                SqlDataAdapter da = new SqlDataAdapter("select * from CurrentExchange", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;



            }
        }
    }
}
