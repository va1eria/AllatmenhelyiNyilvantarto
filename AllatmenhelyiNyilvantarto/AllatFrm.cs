using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllatmenhelyiNyilvantarto
{
    public partial class AllatFrm : Form
    {
        public AllatFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KutyaFrm frm = new KutyaFrm();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MacskaFrm frm = new MacskaFrm();
            frm.ShowDialog();
        }
    }
}
