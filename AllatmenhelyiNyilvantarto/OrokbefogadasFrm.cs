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
            txb_allat.Text = allat.Nev;
            txb_allat.Enabled = false;
            dateTimePicker_Orokbefogadas.Value = DateTime.Now;
            dateTimePicker_Utoell.Value = dateTimePicker_Orokbefogadas.Value.AddMonths(1);
            dateTimePicker_Utoell.Enabled = false;
            comboBox_Orokbefogado.DataSource = AdatbazisKezelo.OrokbefogadokFelolvasas();
        }
        internal OrokbefogadasFrm(Orokbefogadas modosit, Allat allat) : this(allat)
        {
            orokbefogadas = modosit;
            txb_allat.Text = allat.Nev;
            txb_allat.Enabled = false;
            comboBox_Orokbefogado.Enabled = false;
            dateTimePicker_Orokbefogadas.Value = orokbefogadas.OrokbefogadasDatuma;
            dateTimePicker_Orokbefogadas.Enabled = false;
            dateTimePicker_Utoell.Value = orokbefogadas.UtoellenorzesDatuma;
            dateTimePicker_Utoell.Enabled = true;
            checkBox_Utoell.Checked = orokbefogadas.SikeresUtoellenorzes;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (orokbefogadas == null)
                {
                    orokbefogadas = new Orokbefogadas(dateTimePicker_Orokbefogadas.Value, dateTimePicker_Utoell.Value, checkBox_Utoell.Checked);
                    AdatbazisKezelo.OrokbefogadasFelvitel((Orokbefogado)comboBox_Orokbefogado.SelectedItem, allat, orokbefogadas); 
                }
                else
                {
                    if (dateTimePicker_Utoell.Value > dateTimePicker_Orokbefogadas.Value.AddDays(7))
                    {
                        orokbefogadas.UtoellenorzesDatuma = dateTimePicker_Utoell.Value; 
                    }
                    else
                    {
                        MessageBox.Show("Az utóellenőrzés dátuma legalább egy héttel az örökbefogadás dátuma után kell legyen!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                    }
                    orokbefogadas.SikeresUtoellenorzes = checkBox_Utoell.Checked;
                    AdatbazisKezelo.OrokbefogadasModositas(allat, orokbefogadas);
                }
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
