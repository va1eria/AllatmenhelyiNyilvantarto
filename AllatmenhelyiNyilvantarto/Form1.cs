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
        readonly string[] kategoria = new string[3] { "Összes", "Kutya", "Macska" };
        Gondozo gondozo;
        Orokbefogado orokbefogado;
        Kutya kutya;
        Macska macska;
        List<Kutya> kutyak;
        List<Macska> macskak;
        List<Allat> gazdasok;
        List<Allat> nemGazdasok;
        List<Kutya> gazdasKutyak;
        List<Macska> gazdasMacskak;
        List<Allat> utoellenorzesreVarok = new List<Allat>();
        List<Allat> utoellenorzesSikeres = new List<Allat>();

        public Form1()
        {
            InitializeComponent();
            ProbaAdatok();
            comboBox1.DataSource = kategoria;
            //if (listBox_Allatok.SelectedIndex != -1)
            //{
            //    listBox_Gazdasok.Enabled = false;
            //}
        }
        //adatok felvitele nelkul ki lehessen probalni a programot
        void ProbaAdatok()
        {
            if (gondozo == null)
            {
                gondozo = new Gondozo("Gipsz Jakab", new DateTime(1990, 06, 14));
                AdatbazisKezelo.GondozoFelvitel(gondozo);
            }
            if (orokbefogado == null)
            {
                orokbefogado = new Orokbefogado("Matr Ica", "Budapest, Fő utca 1.", "ica@email.com", new DateTime(1984, 07, 02));
                AdatbazisKezelo.OrokbefogadoFelvitele(orokbefogado);
            }
            if (kutya == null)
            {
                kutya = new Kutya("Aliz", "123456", "játékos, nyüzsgő", Szor.rövid, Nem.hím, 13, new DateTime(2019, 06, 14), DateTime.Today, true, false, true, false, true, true, false, false, gondozo);
                AdatbazisKezelo.AllatFelvitel(gondozo, kutya);
            }
            if (macska == null)
            {
                macska = new Macska("Mása", "654321", "nyugodt, csendes", Szor.hosszú, Nem.nőstény, 5, new DateTime(2015, 06, 14), DateTime.Today, true, true, false, true, false, false, gondozo);
                AdatbazisKezelo.AllatFelvitel(gondozo, macska);
            }
            LBFrissit();
        }

        void GazdasLista()
        {
            gazdasok = new List<Allat>();
            nemGazdasok = new List<Allat>();
            List<Allat> allatok = AdatbazisKezelo.AllatokFelolvasas();

            if (allatok.Count != 0)
            {
                foreach (Allat allat in allatok.ToList())
                {
                    if (allat.Gazdas == true)
                    {
                        gazdasok.Add(allat);
                    }
                    else if (allat.Gazdas == false)
                    {
                        nemGazdasok.Add(allat);
                    }
                }
            }
        }

        void LBFrissit()
        {
            
            listBox_Gondozok.DataSource = null;
            listBox_Gondozok.DataSource = AdatbazisKezelo.GondozokFelolvasas();
            listBox_Orokbefogadok.DataSource = null;
            listBox_Orokbefogadok.DataSource = AdatbazisKezelo.OrokbefogadokFelolvasas();
            GazdasLista();
            NemGazdasKutyakMacskak();
            GazdasKutyakMacskak();
            listBox_Allatok.DataSource = null;
            listBox_Allatok.DataSource = nemGazdasok;
            listBox_Gazdasok.DataSource = null;
            listBox_Gazdasok.DataSource = gazdasok;
            Utoellenorzes();
            listBox_Allatok.SelectedItem = null;
            listBox_Gazdasok.SelectedItem = null;
            richTextBox_Kutyak.Text = kutyak.Count.ToString();
            richTextBox_Kutyak.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox_Macskak.Text = macskak.Count.ToString();
            richTextBox_Macskak.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox_GazdasKutyak.Text = gazdasKutyak.Count.ToString();
            richTextBox_GazdasKutyak.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox_GazdasMacskak.Text= gazdasMacskak.Count.ToString();
            richTextBox_GazdasMacskak.SelectionAlignment = HorizontalAlignment.Center;
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

        void NemGazdasKutyakMacskak()
        {
            listBox_Allatok.DataSource = null;
            kutyak = new List<Kutya>();
            macskak = new List<Macska>();
            foreach (Allat allat in nemGazdasok)
            {
                if (allat is Kutya kutya && kutya.Gazdas == false)
                {
                    kutyak.Add(kutya);
                }
                else if (allat is Macska macska && macska.Gazdas == false)
                {
                    macskak.Add(macska);
                }
            }
        }

        void GazdasKutyakMacskak()
        {
            gazdasKutyak = new List<Kutya>();
            gazdasMacskak = new List<Macska>();
            foreach (Allat allat in gazdasok)
            {
                if (allat is Kutya kutya && kutya.Gazdas == true)
                {
                    gazdasKutyak.Add(kutya);
                }
                else if (allat is Macska macska && macska.Gazdas == true)
                {
                    gazdasMacskak.Add(macska);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NemGazdasKutyakMacskak();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Összes":
                    listBox_Allatok.DataSource = nemGazdasok;
                    break;
                case "Kutya":
                    listBox_Allatok.DataSource = kutyak;
                    break;
                case "Macska":
                    listBox_Allatok.DataSource = macskak;
                    break;
            }
        }

        private void btn_AllatModosit_Click(object sender, EventArgs e)
        {
            ListBox kijelolt = null;
            if (listBox_Allatok.SelectedItem != null)
            {
                kijelolt = listBox_Allatok;
            }
            else if (listBox_Gazdasok.SelectedItem != null)
            {
                kijelolt = listBox_Gazdasok;
            }
            else
            {
                MessageBox.Show("Jelöljön ki egy állatot a módosításhoz!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
            if (kijelolt != null && kijelolt.SelectedItem is Kutya)
            {
                KutyaFrm frm = new KutyaFrm((Kutya)kijelolt.SelectedItem);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LBFrissit();
                }
            }
            else if (kijelolt != null && kijelolt.SelectedItem is Macska)
            {
                MacskaFrm frm = new MacskaFrm((Macska)kijelolt.SelectedItem);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LBFrissit();
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
            if (listBox_Gazdasok.SelectedItem != null)
            {
                OrokbefogadasAdataiFrm frm = new OrokbefogadasAdataiFrm((Allat)listBox_Gazdasok.SelectedItem);
                frm.ShowDialog();
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

        private void listBox_Allatok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ListBox).SelectedIndex != -1)
            {
                foreach (Control item in Controls)
                {
                    if (item is ListBox lbx && lbx != (ListBox)sender)
                    {
                        lbx.SelectedIndex = -1;
                    }
                }
            }
        }

        private void btn_AllatTorles_Click(object sender, EventArgs e)
        {
            ListBox kijelolt = null;
            if (listBox_Allatok.SelectedItem != null)
            {
                kijelolt = listBox_Allatok;
            }
            else if (listBox_Gazdasok.SelectedItem != null)
            {
                kijelolt = listBox_Gazdasok;
            }
            if (kijelolt != null && MessageBox.Show("Biztosan törli a kijelölt állatot?", "Biztosan?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AdatbazisKezelo.AllatTorles((Allat)kijelolt.SelectedItem);
                LBFrissit();
            }
            else
            {
                MessageBox.Show("A törléshez jelöljön ki egy állatot!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }

        public void Utoellenorzes()
        {
            List<string> utoellenorzesreVaroNevek = AdatbazisKezelo.UtoellenorzesEsedekes();
            List<string> utellenorzesSikeresNevek = AdatbazisKezelo.UtoellenorzesSikeres();
            utoellenorzesreVarok.Clear();
            utoellenorzesSikeres.Clear();
            foreach (Allat allat in gazdasok)
            {
                for (int i = 0; i < utoellenorzesreVaroNevek.Count; i++)
                {
                    if (allat.Nev == utoellenorzesreVaroNevek[i])
                    {
                        utoellenorzesreVarok.Add(allat);
                        listBox_Gazdasok.DataSource = null;
                        listBox_Gazdasok.DataSource = gazdasok;
                    }
                }
                for (int i = 0; i < utellenorzesSikeresNevek.Count; i++)
                {
                    if (allat.Nev == utellenorzesSikeresNevek[i])
                    {
                        utoellenorzesSikeres.Add(allat);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Utoellenorzes();
        }

        private void listBox_Gazdasok_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Brush myBrush = Brushes.Black;

            for (int i = 0; i < listBox_Gazdasok.Items.Count; i++)
            {
                if (utoellenorzesreVarok.Count != 0 && utoellenorzesreVarok.Contains(listBox_Gazdasok.Items[e.Index] as Allat))
                {
                    myBrush = Brushes.Red;
                    e.Graphics.DrawString(listBox_Gazdasok.Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                }
                else if (utoellenorzesSikeres.Count != 0 && utoellenorzesSikeres.Contains(listBox_Gazdasok.Items[e.Index] as Allat))
                {
                    myBrush = Brushes.Green;
                    e.Graphics.DrawString(listBox_Gazdasok.Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                }
                else
                {
                    e.Graphics.DrawString(listBox_Gazdasok.Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                }
            }
        }
    }
}
