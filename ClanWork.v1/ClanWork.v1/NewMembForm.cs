using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClanWork.v1
{
    public partial class NewMembForm : Form
    {
        public NewMembForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\ClanWork\\Mafia.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClanWork db = new ClanWork();
            db.NewMembTabs.Load();

            dataGridView1.DataSource = db.NewMembTabs.Local.ToBindingList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            ActionForm.Current.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ActionForm.Pos == "Pawn")
            {
                MessageBox.Show("You don't have rights to do given action!");
            }
            else
            {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-J8I3ABH,1433;Initial Catalog=ClanWork;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Members ORDER BY ID DESC", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    ClanWork db = new ClanWork();
                    NewMembTab nm = db.NewMembTabs.Find(id);
                    Login lg = new Login { Log = nm.Log, Pass = nm.Pass, Memberid = i + 1 };
                    Member mb = new Member { FirstName = nm.FirstName, LastName = nm.LastName, Position = nm.WantedPosition, Job = "Not yet", id = i + 1 };

                    db.Logins.Add(lg);
                    db.Members.Add(mb);
                    db.NewMembTabs.Remove(nm);
                     
                    try
                    {

                        db.SaveChanges();
                        dataGridView1.Update();
                        dataGridView1.RefreshEdit();
                    }

                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());

                            foreach (DbValidationError err in validationError.ValidationErrors)
                            {
                                MessageBox.Show(err.ErrorMessage + "");
                            }
                        }
                    }


                    string connectionString = @"Data Source=.\MSSQLSERVER,1433;Initial Catalog=ClanWork;Integrated Security=True";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand c = new SqlCommand("Insert into History VALUES(@1,@2)", connection);
                        c.Parameters.AddWithValue("@1", ActionForm.Pos + " " + LoginForm.Namez + " " + "invited " + mb.Position + " " + mb.FirstName);
                        c.Parameters.AddWithValue("@2", DateTime.Now);
                        c.ExecuteNonQuery();
                        connection.Close();
                        
                    }

                }
            }
        }
    }
}
