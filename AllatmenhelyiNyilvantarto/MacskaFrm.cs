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
    public partial class MacskaFrm : Form
    {
        Gondozo gondozo;
        Macska macska;
        Orokbefogado orokbefogado;

        internal MacskaFrm()
        {
            InitializeComponent();
            comboBox_Nem.DataSource = Enum.GetValues(typeof(Nem));
            comboBox_Szor.DataSource = Enum.GetValues(typeof(Szor));
            comboBox_Gondozo.DataSource = AdatbazisKezelo.GondozokFelolvasas();
        }

        internal MacskaFrm(Macska modosit) : this()
        {
            macska = modosit;
            textBox_Nev.Text = macska.Nev;
            textBox_Nev.ReadOnly = true;
            textBox_Chip.Text = macska.Chipszam;
            richTextBox1.Text = macska.Leiras;
            comboBox_Szor.SelectedItem = macska.Szor;
            comboBox_Nem.SelectedItem = macska.Nem;
            comboBox_Nem.Enabled = false;
            numericUpDown1.Value = (decimal)macska.Suly;
            dateTimePicker_Szuletesi.Value = macska.SzuletesiDatum;
            dateTimePicker_Szuletesi.Enabled = false;
            dateTimePicker_Bekerulesi.Value = macska.BekerulesiDatum;
            dateTimePicker_Bekerulesi.Enabled = false;
            checkBox_ivartalan.Checked = macska.Ivartalanitott;
            checkBox_macskaval_tarthato.Checked = macska.MacskavalTarthato;
            checkBox_kutyaval_tarthato.Checked = macska.KutyavalTarthato;
            checkBox_gyerekkel_tarthato.Checked = macska.GyerekkelTarthato;
            checkBox_kijaros.Checked = macska.Kijaros;
            checkBox_orokbefogadva.Checked = macska.Gazdas;
            AdatbazisKezelo.AllatModositas(macska);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (macska == null)
                {
                    gondozo = (Gondozo)comboBox_Gondozo.SelectedItem;
                    macska = new Macska(
                        textBox_Nev.Text,
                        textBox_Chip.Text,
                        richTextBox1.Text,
                        (Szor)comboBox_Szor.SelectedItem,
                        (Nem)comboBox_Nem.SelectedItem,
                        (double)numericUpDown1.Value,
                        (DateTime)dateTimePicker_Szuletesi.Value,
                        (DateTime)dateTimePicker_Bekerulesi.Value,
                        (bool)checkBox_ivartalan.Checked,
                        (bool)checkBox_macskaval_tarthato.Checked,
                        (bool)checkBox_kutyaval_tarthato.Checked,
                        (bool)checkBox_gyerekkel_tarthato.Checked,
                        (bool)checkBox_kijaros.Checked,
                        (bool)checkBox_orokbefogadva.Checked,
                        gondozo
                        );
                    AdatbazisKezelo.AllatFelvitel(gondozo, macska);
                }
                //else
                //{
                //    allat.Chipszam = textBox_Chip.Text;
                //    allat.Leiras = richTextBox1.Text;
                //    allat.Szor = (Szor)comboBox_Szor.SelectedItem;
                //    allat.Suly = (double)numericUpDown1.Value;
                //    allat.Ivartalanitott = checkBox_ivartalan.Checked;
                //    allat.MacskavalTarthato = checkBox_macskaval_tarthato.Checked;
                //    allat.KutyavalTarthato = checkBox_kutyaval_tarthato.Checked;
                //    allat.GyerekkelTarthato = checkBox_gyerekkel_tarthato.Checked;
                //    allat.Gazdas = checkBox_orokbefogadva.Checked;
                //    allat.Gondozo = gondozo;
                //    if (allat is Macska macska)
                //    {
                //        macska.Kijaros = checkBox_kijaros.Checked;
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

        private void btn_Orokbefogadas_Click(object sender, EventArgs e)
        {
            OrokbefogadasFrm frm = new OrokbefogadasFrm(macska, orokbefogado);
            frm.ShowDialog();
        }
    }
}
