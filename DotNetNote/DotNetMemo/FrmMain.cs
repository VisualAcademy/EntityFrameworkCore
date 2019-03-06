using DotNetNote.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DotNetMemo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            using (var context = new DotNetNoteContext())
            {
                var ideas = context.Ideas.OrderBy(i => i.Id).ToList();

                dataGridView1.DataSource = ideas;
            }
        }
    }
}
