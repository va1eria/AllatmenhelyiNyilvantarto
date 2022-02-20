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
        Orokbefogadas orokbefogadas;

        internal OrokbefogadasFrm(Allat allat)
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
            dateTimePicker_Orokbefogadas.Value = DateTime.Now;
            dateTimePicker_Utoell.Value = dateTimePicker_Orokbefogadas.Value.AddMonths(1);
            dateTimePicker_Utoell.Enabled = false;
            //comboBox_Allat.DataSource = AdatbazisKezelo.AllatokFelolvasas();
            comboBox_Orokbefogado.DataSource = AdatbazisKezelo.OrokbefogadokFelolvasas();
        }
        // TODO orokbefogadas modositas
        internal OrokbefogadasFrm(Orokbefogadas modosit, Allat allat) : this(allat)
        {
            orokbefogadas = modosit;
            comboBox_Allat.SelectedItem = allat;
            comboBox_Allat.Enabled = false;
            dateTimePicker_Orokbefogadas.Value = orokbefogadas.OrokbefogadasDatuma;
            dateTimePicker_Orokbefogadas.Enabled = false;
            dateTimePicker_Utoell.Value = orokbefogadas.UtoellenorzesDatuma;
            checkBox_Utoell.Checked = orokbefogadas.SikeresUtoellenorzes;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (orokbefogadas == null)
                {
                    orokbefogadas = new Orokbefogadas(dateTimePicker_Orokbefogadas.Value, dateTimePicker_Utoell.Value, checkBox_Utoell.Checked);
                    AdatbazisKezelo.OrokbefogadasFelvitele((Orokbefogado)comboBox_Orokbefogado.SelectedItem, allat, orokbefogadas); 
                }
                //else
                //{//TODO orokbefogadas modosit
                //    orokbefogadas.OrokbefogadasDatuma = dateTimePicker_Orokbefogadas.Value;
                //    orokbefogadas.UtoellenorzesDatuma = dateTimePicker_Utoell.Value;
                //    orokbefogadas.SikeresUtoellenorzes = checkBox_Utoell.Checked;
                //    AdatbazisKezelo.OrokbefogadasModositas((Orokbefogado)comboBox_Orokbefogado.SelectedItem, allat, orokbefogadas);
                //}
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

        private void dateTimePicker_Orokbefogadas_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_Utoell.Value = dateTimePicker_Orokbefogadas.Value.AddMonths(1);
        }
    }
}
