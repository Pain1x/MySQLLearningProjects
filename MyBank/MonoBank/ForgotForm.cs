using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MonoBank
{
    public partial class ForgotForm : Form
    {
        public static ForgotForm Current;
        public static string ID;
        public ForgotForm()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("E:\\war3\\Projects\\MonoBank\\1.jfif");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Current = this;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            LogForm.Current.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=MonoBank;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select ID,SecondName,PhoneNumber from Customers", con);
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                ID = da.GetValue(0).ToString();
                string SecondName = da.GetValue(1).ToString();
                string Phone = da.GetValue(2).ToString();
                if (textBox1.Text == SecondName & textBox2.Text == Phone)
                {
                    NewPassForm nf = new NewPassForm();
                    nf.Show();
                    Close();
                }
            }
            con.Close();
        }
    }
}
