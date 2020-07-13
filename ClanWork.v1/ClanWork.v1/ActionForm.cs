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
    public partial class ActionForm : Form
    {
      public static  ActionForm Current;
      public static string Pos;
        public ActionForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\ClanWork\\Mafia.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            Current = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            LoginForm.Changer();
            LoginForm.Current.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            BankForm nf = new  BankForm();
            nf.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=ClanWork;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Members SET Job = 'Done' WHERE ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", LoginForm.ID);
            cmd.ExecuteNonQuery();
            SqlCommand c = new SqlCommand("Insert into History VALUES(@1,@2)", connection);
            c.Parameters.AddWithValue("@1",Pos + " " + LoginForm.Namez + " done job");
            c.Parameters.AddWithValue("@2", DateTime.Now);
            c.ExecuteNonQuery();
            
            connection.Close();
            MessageBox.Show("The job is done!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            MembersForm nf = new MembersForm();
            nf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            NewMembForm nf = new NewMembForm();
            nf.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Pos == "King")
            {
                Hide();
                HistoryForm nf = new HistoryForm();
                nf.Show();
            }
            else
            {
                MessageBox.Show("You don't have rights to do given action!");
            }
        }

        private void ActionForm_Load(object sender, EventArgs e)
        {
            using (ClanWork db = new ClanWork())
            {
                var pos = from p in db.Members
                          where p.id == LoginForm.ID
                            select p;
                foreach (Member p in pos)
                {
                    Pos = p.Position;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Pos == "King" | Pos == "Queen" | Pos == "Rook")
            {
                Hide();
                ChangePosForm nf = new ChangePosForm();
                nf.Show();
            }
            else
            {
                MessageBox.Show("You don't have rights to do given action!");
            }
        }
    }
}
