using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MonoBank
{
    public partial class LogForm : Form
    {
        public static string SetValueForText1 = "";
        public static string ID;
        public static LogForm Current;
      
        public LogForm()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("E:\\war3\\Projects\\MonoBank\\1.jfif");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Current = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=MonoBank;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from CustomersLogs", con);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    ID = da.GetValue(0).ToString();
                    string Log = da.GetValue(1).ToString();
                    string Pass = da.GetValue(2).ToString();
                    SetValueForText1 = ID;
                  if (textBox1.Text == Log & textBox2.Text == Pass)
                {
                    CustomerChamber newForm = new CustomerChamber();
                    newForm.Show();
                    Hide();
                }
                else if(textBox1.Text != "" & textBox2.Text != "")
                    {
                    label1.Visible = true;
                   }
                }
                con.Close();         
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            HelloSQL.Current.ShowDialog();          
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
            ForgotForm nf = new ForgotForm();
            nf.Show();
        }
    }
}
