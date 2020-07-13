using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClanWork.v1
{
    public partial class NewSchoolForm : Form
    {
        int i = 0;
        public NewSchoolForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\ClanWork\\Mafia.png");
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            LoginForm.Current.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                ClanWork db = new ClanWork();
                db.NewMembTabs.Load();

                NewMembTab nm = new NewMembTab();
                try
                {
                    nm.FirstName = textBox1.Text;
                    nm.LastName = textBox2.Text;

                    nm.Log = textBox3.Text;
                    nm.Pass = textBox4.Text;

                    nm.WantedPosition = comboBox1.SelectedItem.ToString();

                    db.NewMembTabs.Add(nm);
                    db.SaveChanges();
                    label6.Visible = true;
                    i++;
                }

                catch(Exception ex)
                {
                    label7.Visible = true;
                }
            }
                
            }

        }
    }

