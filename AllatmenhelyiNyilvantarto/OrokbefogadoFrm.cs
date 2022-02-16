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
    public partial class OrokbefogadoFrm : Form
    {
        Orokbefogado orokbefogado;

        public OrokbefogadoFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                orokbefogado = new Orokbefogado(txb_nev.Text, txb_lakcim.Text, txb_email.Text, dateTimePicker1.Value);
                AdatbazisKezelo.OrokbefogadoFelvitele(orokbefogado);
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.InnerException.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }
    }
}
