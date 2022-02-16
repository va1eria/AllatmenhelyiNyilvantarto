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

        internal KutyaFrm()
        {
            InitializeComponent();
            comboBox_Nem.DataSource = Enum.GetValues(typeof(Nem));
            comboBox_Szor.DataSource = Enum.GetValues(typeof(Szor));
            comboBox_Gondozo.DataSource = AdatbazisKezelo.GondozokFelolvasas();
        }

        internal KutyaFrm(Kutya modosit) : this()
        {
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
            AdatbazisKezelo.AllatModositas(kutya);
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
                //else
                //{
                //    kutya.Chipszam = textBox_Chip.Text;
                //    allat.Leiras = richTextBox1.Text;
                //    allat.Szor = (Szor)comboBox_Szor.SelectedItem;
                //    allat.Suly = (double)numericUpDown1.Value;
                //    allat.Ivartalanitott = checkBox_ivartalan.Checked;
                //    allat.MacskavalTarthato = checkBox_macskaval_tarthato.Checked;
                //    allat.KutyavalTarthato = checkBox_kutyaval_tarthato.Checked;
                //    allat.GyerekkelTarthato = checkBox_gyerekkel_tarthato.Checked;
                //    allat.Gazdas = checkBox_orokbefogadva.Checked;
                //    allat.Gondozo = gondozo;
                //    if (allat is Kutya kutya)
                //    {
                //        kutya.Szobatiszta = checkBox_szobatiszta.Checked;
                //        kutya.LakasbanTarthato = checkBox_lakasban.Checked;
                //        kutya.EgyedulHagyhato = checkBox_egyedul.Checked;
                //    }
                //    AdatbazisKezelo.AllatModositas(allat);
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
    }
}
