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
    public partial class GondozoFrm : Form
    {
        Gondozo gondozo;
        public GondozoFrm()
        {
            InitializeComponent();
        }

        internal GondozoFrm(Gondozo modosit) : this()
        {
            gondozo = modosit;
            dateTimePicker1.Value = gondozo.SzuletesiDatum;
            txb_nev.Text = gondozo.Nev;
            dateTimePicker1.Enabled = false;
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (gondozo == null)
                {
                    gondozo = new Gondozo(txb_nev.Text, dateTimePicker1.Value);
                    AdatbazisKezelo.GondozoFelvitel(gondozo); 
                }
                else
                {
                    gondozo.Nev = txb_nev.Text;
                    AdatbazisKezelo.GondozoModositas(gondozo);
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
