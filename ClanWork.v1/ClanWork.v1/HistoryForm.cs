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
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
            BackgroundImage = Image.FromFile("E:\\war3\\Projects\\ClanWork\\Mafia.png");
            BackgroundImageLayout = ImageLayout.Stretch;

            ClanWork db = new ClanWork();
            db.Histories.Load();

            dataGridView1.DataSource = db.Histories.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            ActionForm.Current.Show();
        }
    }
}
