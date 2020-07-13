using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MonoBank
{

    public partial class HelloSQL : Form
    {
        public static int counter;
        public  static HelloSQL Current;
        public HelloSQL()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("E:\\war3\\Projects\\MonoBank\\1.jfif");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Current = this;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=MonoBank;Integrated Security=True");
            SqlCommand countCom = new SqlCommand("SELECT COUNT(FirstName) FROM Customers", con);
            con.Open();
            counter = (int)countCom.ExecuteScalar();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Hide();
            LogForm nf = new LogForm();
            nf.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            NewSchoolForm newForm = new NewSchoolForm();
            newForm.Show();
        }
    }
}
