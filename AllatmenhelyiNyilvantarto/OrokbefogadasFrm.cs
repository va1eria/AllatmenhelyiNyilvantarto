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
    public partial class OrokbefogadasFrm : Form
    {
        Allat allat;
        //Orokbefogado orokbefogado;

        internal OrokbefogadasFrm(Allat allat, Orokbefogado orokbefogado)
        {
            InitializeComponent();
            if (allat is Kutya kutya)
            {
                this.allat = kutya;
            }
            else if (allat is Macska macska)
            {
                this.allat = macska;
            }
            comboBox_Allat.DataSource = AdatbazisKezelo.AllatokFelolvasas();
            comboBox_Orokbefogado.DataSource = AdatbazisKezelo.OrokbefogadokFelolvasas();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                Orokbefogadas orokbefogadas = new Orokbefogadas(dateTimePicker_Orokbefogadas.Value, dateTimePicker_Utoell.Value, checkBox_Utoell.Checked);
                AdatbazisKezelo.OrokbefogadasFelvitele((Orokbefogado)comboBox_Orokbefogado.SelectedItem, allat, orokbefogadas);
            }
            catch (ABKivetel ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
