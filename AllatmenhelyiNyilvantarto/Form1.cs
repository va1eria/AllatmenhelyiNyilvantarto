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
    public partial class Form1 : Form
    {
        string[] kategoria = new string[3] { "Összes", "Kutya", "Macska" };
        Gondozo gondozo;
        List<Kutya> kutyak = new List<Kutya>();
        List<Macska> macskak = new List<Macska>();
        List<Allat> gazdasok = new List<Allat>();
        public Form1()
        {
            InitializeComponent();
            TesztAdatok();
            comboBox1.DataSource = kategoria;
        }
        void TesztAdatok()
        {
            if (gondozo == null)
            {
                gondozo = new Gondozo("Gipsz Jakab", new DateTime(1990, 06, 14));
                AdatbazisKezelo.GondozoFelvitel(gondozo);
            }
            LBFrissit();
        }

        void LBFrissit()
        {
            listBox_Gondozok.DataSource = null;
            listBox_Gondozok.DataSource = AdatbazisKezelo.GondozokFelolvasas();
            listBox_Orokbefogadok.DataSource = null;
            listBox_Orokbefogadok.DataSource = AdatbazisKezelo.OrokbefogadokFelolvasas();
            //listBox_Allatok.DataSource = null;
            //listBox_Allatok.DataSource = AdatbazisKezelo.AllatokFelolvasas();
        }

        private void btn_UjAllat_Click(object sender, EventArgs e)
        {
            AllatFrm frm = new AllatFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                comboBox1_SelectedIndexChanged(sender, e);
                LBFrissit();
            }
        }

        private void btn_UjGondozo_Click(object sender, EventArgs e)
        {
            GondozoFrm frm = new GondozoFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LBFrissit();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_Allatok.DataSource = null;
            kutyak.Clear();
            macskak.Clear();
            List<Allat> allatok = AdatbazisKezelo.AllatokFelolvasas();

            foreach (Allat allat in allatok)
            {
                if (allat is Kutya kutya)
                {
                    kutyak.Add(kutya);
                }
                else if (allat is Macska macska)
                {
                    macskak.Add(macska);
                }
            }

            switch (comboBox1.SelectedItem.ToString())
            {
                case "Összes":
                    listBox_Allatok.DataSource = AdatbazisKezelo.AllatokFelolvasas();
                    break;
                case "Kutya":
                    listBox_Allatok.DataSource = kutyak;
                    break;
                case "Macska":
                    listBox_Allatok.DataSource = macskak;
                    break;
            }
        }

        private void btn_UjOrokbe_Click(object sender, EventArgs e)
        {
            OrokbefogadoFrm frm = new OrokbefogadoFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LBFrissit();
            }
        }

        private void btn_AllatModosit_Click(object sender, EventArgs e)
        {
            if (listBox_Allatok.SelectedItem != null)
            {
                if ((Allat)listBox_Allatok.SelectedItem is Kutya)
                {
                    KutyaFrm frm = new KutyaFrm((Kutya)listBox_Allatok.SelectedItem);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LBFrissit();
                    }
                }
                else if ((Allat)listBox_Allatok.SelectedItem is Macska)
                {
                    MacskaFrm frm = new MacskaFrm((Macska)listBox_Allatok.SelectedItem);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LBFrissit();
                    }
                }
            }
        }

        private void btn_Kilepes_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Biztosan kilép a programból?", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }



        }

        private void btn_OrokbefogadasAdatai_Click(object sender, EventArgs e)
        {
            if (listBox_Allatok.SelectedItem != null)
            {
                OrokbefogadasFrm frm = new OrokbefogadasFrm((Allat)listBox_Allatok.SelectedItem);
                frm.ShowDialog();
            }
        }
    }
}
