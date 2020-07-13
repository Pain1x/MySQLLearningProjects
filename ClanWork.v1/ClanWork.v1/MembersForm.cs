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
    public partial class MembersForm : Form
    {
        public MembersForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\ClanWork\\Mafia.png");
            BackgroundImageLayout = ImageLayout.Stretch;

            ClanWork db = new ClanWork();
            db.Members.Load();

            dataGridView1.DataSource = db.Members.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            ActionForm.Current.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (ActionForm.Pos=="King" | ActionForm.Pos == "Queen" | ActionForm.Pos == "Rook" )
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    ClanWork db = new ClanWork();

                    Member memb = db.Members.Find(id);
                    db.Members.Remove(memb);



                    db.SaveChanges();


                    dataGridView1.Update();
                    dataGridView1.RefreshEdit();

                    string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=ClanWork;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand c = new SqlCommand("Insert into History VALUES(@1,@2)", connection);
                        c.Parameters.AddWithValue("@1", ActionForm.Pos + " " + LoginForm.Namez + " " + "kicked " + memb.Position + " " + memb.FirstName);
                        c.Parameters.AddWithValue("@2", DateTime.Now);
                        c.ExecuteNonQuery();
                        connection.Close();
                    }

                }

            }
            else
            {
                MessageBox.Show("You don't have rights to do given action!");
            }
           
        }
    }
}
