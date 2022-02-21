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
    public partial class OrokbefogadasAdataiFrm : Form
    {
        internal OrokbefogadasAdataiFrm(Allat allat)
        {
            InitializeComponent();
            Orokbefogadas orokbefogadas = AdatbazisKezelo.OrokbefogadasFelolvasas(allat);
            textBox_Allat.Text = allat.Nev;
            textBox_OrokbefDatum.Text = orokbefogadas.OrokbefogadasDatuma.ToShortDateString();
            textBox_Orokbefogado.Text = AdatbazisKezelo.OrokbefogadoKiolvasas(allat).Nev;
            textBox_Utoellenorzes.Text = orokbefogadas.UtoellenorzesDatuma.ToShortDateString();
            if (orokbefogadas.SikeresUtoellenorzes)
            {
                label5.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
