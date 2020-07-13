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
    public partial class LoginForm : Form
    {
        public static Label label5 = new Label();
        public static LoginForm Current;
        public static int ID;
        public static string Namez;
        public LoginForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\ClanWork\\Mafia.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            Current = this;
           
        }
        public static void Changer()
        {
            label5.Visible = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            label5.Location = new Point(42, 85);
            label5.Text = "Invalid login or password";
            label5.Size = new Size(123, 13);
            label5.Visible = false;
            Controls.Add(label5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hide();
            NewSchoolForm nf = new NewSchoolForm();
            nf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=ClanWork;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select Log,Pass from Logins where Log=@UserName and Pass =@Password;", con);
                cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                SqlCommand c = new SqlCommand("Select Memberid From Logins Where Log=@1 AND Pass=@2",con);
                c.Parameters.AddWithValue("@1",textBox1.Text);
                c.Parameters.AddWithValue("@2",textBox2.Text);
                ID = int.Parse(c.ExecuteScalar().ToString());
                Namez = textBox1.Text;
                con.Close();
                int i = ds.Tables[0].Rows.Count;
                if (i == 1)
                {
                    Hide();
                    ActionForm nf = new ActionForm();
                    nf.Show();
                }  
            }
            catch (Exception ex)
            {
                label5.Visible = true;
            }
        }
    }
}
    
        
    

   
    

