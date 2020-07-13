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

namespace Drugstore
{
    public partial class SoldForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=Drugstore;Integrated Security=True");
        public SoldForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\Drugstore\\money.jpg");
            BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Form1.Current.Show();
        }

        private void SoldForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'drugstoreDataSet2.Sold' table. You can move, or remove it, as needed.
            this.soldTableAdapter.Fill(this.drugstoreDataSet2.Sold);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand  cmd = new SqlCommand("Select Sum(Price * Quantity) from Sold",con);
            object i = cmd.ExecuteScalar();

            MessageBox.Show(i.ToString());
        }
    }
}
