using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NameListLib;

namespace NameList
{
    public partial class NameListForm : Form
    {
        private NameListLib.INameList names = new NameListLib.NameList();

        public NameListForm()
        {
            InitializeComponent();
            // well, this means I'm not gonna use the GetNames() method
            namesLB.DataSource = names;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameTB.Text.Length > 0)
            {
                names.Add(nameTB.Text);
                RefreshNamesLB();
            }
        }

        private void clearBTN_Click(object sender, EventArgs e)
        {
            names.Clear();
            RefreshNamesLB();
        }

        private void RefreshNamesLB()
        {
            // hacky
            namesLB.DataSource = null;
            namesLB.DataSource = names;
        }
    }
}
