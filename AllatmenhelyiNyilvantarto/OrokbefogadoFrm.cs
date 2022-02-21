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

        internal OrokbefogadoFrm(Orokbefogado modosit) :this()
        {
            orokbefogado = modosit;
            txb_nev.Text = orokbefogado.Nev;
            txb_lakcim.Text = orokbefogado.Lakcim;
            txb_email.Text = orokbefogado.Email;
            dateTimePicker1.Value = orokbefogado.SzuletesiDatum;
            dateTimePicker1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (orokbefogado == null)
                {
                    orokbefogado = new Orokbefogado(txb_nev.Text, txb_lakcim.Text, txb_email.Text, dateTimePicker1.Value);
                    AdatbazisKezelo.OrokbefogadoFelvitel(orokbefogado); 
                }
                else
                {
                    orokbefogado.Nev = txb_nev.Text;
                    orokbefogado.Lakcim = txb_lakcim.Text;
                    orokbefogado.Email = txb_email.Text;
                    AdatbazisKezelo.OrokbefogadoModositas(orokbefogado);
                }
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
