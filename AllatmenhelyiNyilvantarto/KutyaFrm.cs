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
    public partial class KutyaFrm : Form
    {
        Gondozo gondozo;
        Kutya kutya;
        Orokbefogadas orokbefogadas;

        internal KutyaFrm()
        {
            InitializeComponent();
            comboBox_Nem.DataSource = Enum.GetValues(typeof(Nem));
            comboBox_Szor.DataSource = Enum.GetValues(typeof(Szor));
            comboBox_Gondozo.DataSource = AdatbazisKezelo.GondozokFelolvasas();
            //checkBox_orokbefogadva.Enabled = false;
        }

        internal KutyaFrm(Kutya modosit) : this()
        {
            btn_Orokbef.Enabled = true;
            btn_OrokbefModosit.Enabled = true;
            kutya = modosit;
            textBox_Nev.Text = kutya.Nev;
            textBox_Nev.ReadOnly = true;
            textBox_Chip.Text = kutya.Chipszam;
            richTextBox1.Text = kutya.Leiras;
            comboBox_Szor.SelectedItem = kutya.Szor;
            comboBox_Nem.SelectedItem = kutya.Nem;
            comboBox_Nem.Enabled = false;
            numericUpDown1.Value = (decimal)kutya.Suly;
            dateTimePicker_Szuletesi.Value = kutya.SzuletesiDatum;
            dateTimePicker_Szuletesi.Enabled = false;
            dateTimePicker_Bekerules.Value = kutya.BekerulesiDatum;
            dateTimePicker_Bekerules.Enabled = false;
            checkBox_ivartalan.Checked = kutya.Ivartalanitott;
            checkBox_macskaval_tarthato.Checked = kutya.MacskavalTarthato;
            checkBox_kutyaval_tarthato.Checked = kutya.KutyavalTarthato;
            checkBox_gyerekkel_tarthato.Checked = kutya.GyerekkelTarthato;
            checkBox_szobatiszta.Checked = kutya.Szobatiszta;
            checkBox_lakasban.Checked = kutya.LakasbanTarthato;
            checkBox_egyedul.Checked = kutya.EgyedulHagyhato;
            checkBox_orokbefogadva.Checked = kutya.Gazdas;
            if (kutya.Gazdas)
            {
                label_Orokbefogadonal.Visible = true;
                btn_Orokbef.Enabled = false;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (kutya == null)
                {
                    gondozo = (Gondozo)comboBox_Gondozo.SelectedItem;
                    kutya = new Kutya(
                        textBox_Nev.Text,
                        textBox_Chip.Text,
                        richTextBox1.Text,
                        (Szor)comboBox_Szor.SelectedItem,
                        (Nem)comboBox_Nem.SelectedItem,
                        (double)numericUpDown1.Value,
                        (DateTime)dateTimePicker_Szuletesi.Value,
                        (DateTime)dateTimePicker_Bekerules.Value,
                        (bool)checkBox_ivartalan.Checked,
                        (bool)checkBox_macskaval_tarthato.Checked,
                        (bool)checkBox_kutyaval_tarthato.Checked,
                        (bool)checkBox_gyerekkel_tarthato.Checked,
                        (bool)checkBox_szobatiszta.Checked,
                        (bool)checkBox_lakasban.Checked,
                        (bool)checkBox_egyedul.Checked,
                        (bool)checkBox_orokbefogadva.Checked,
                        gondozo
                        );
                    AdatbazisKezelo.AllatFelvitel(gondozo, kutya);
                }
                else
                {
                    kutya.Chipszam = textBox_Chip.Text;
                    kutya.Leiras = richTextBox1.Text;
                    kutya.Szor = (Szor)comboBox_Szor.SelectedItem;
                    kutya.Suly = (double)numericUpDown1.Value;
                    kutya.Ivartalanitott = checkBox_ivartalan.Checked;
                    kutya.MacskavalTarthato = checkBox_macskaval_tarthato.Checked;
                    kutya.KutyavalTarthato = checkBox_kutyaval_tarthato.Checked;
                    kutya.GyerekkelTarthato = checkBox_gyerekkel_tarthato.Checked;
                    kutya.Gazdas = checkBox_orokbefogadva.Checked;
                    kutya.Gondozo = gondozo;
                    kutya.Szobatiszta = checkBox_szobatiszta.Checked;
                    kutya.LakasbanTarthato = checkBox_lakasban.Checked;
                    kutya.EgyedulHagyhato = checkBox_egyedul.Checked;

                    AdatbazisKezelo.AllatModositas(kutya);
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

        private void btn_Orokbef_Click(object sender, EventArgs e)
        {
            OrokbefogadasFrm frm = new OrokbefogadasFrm(kutya);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                checkBox_orokbefogadva.Checked = true;
                label_Orokbefogadonal.Visible = true;
            }
        }

        private void btn_OrokbefModosit_Click(object sender, EventArgs e)
        {
            if (kutya.Gazdas)
            {
                orokbefogadas = AdatbazisKezelo.OrokbefogadasFelolvasas(kutya);
                OrokbefogadasFrm frm = new OrokbefogadasFrm(orokbefogadas, kutya);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AdatbazisKezelo.OrokbefogadasModositas(kutya, orokbefogadas);
                }
            }
        }
    }
}
