namespace AllatmenhelyiNyilvantarto
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Kilepes = new System.Windows.Forms.Button();
            this.btn_OrokbefogadasAdatai = new System.Windows.Forms.Button();
            this.btn_AllatTorles = new System.Windows.Forms.Button();
            this.btn_AllatModosit = new System.Windows.Forms.Button();
            this.btn_UjAllat = new System.Windows.Forms.Button();
            this.listBox_Gazdasok = new System.Windows.Forms.ListBox();
            this.listBox_Allatok = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_GondozoModosit = new System.Windows.Forms.Button();
            this.btn_UjGondozo = new System.Windows.Forms.Button();
            this.btn_OrokbeTorol = new System.Windows.Forms.Button();
            this.btn_OrokbeModosit = new System.Windows.Forms.Button();
            this.btn_UjOrokbe = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox_Gondozok = new System.Windows.Forms.ListBox();
            this.listBox_Orokbefogadok = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox_Macskak = new System.Windows.Forms.RichTextBox();
            this.richTextBox_GazdasKutyak = new System.Windows.Forms.RichTextBox();
            this.richTextBox_GazdasMacskak = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Kutyak = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btn_Kilepes);
            this.tabPage1.Controls.Add(this.btn_OrokbefogadasAdatai);
            this.tabPage1.Controls.Add(this.btn_AllatTorles);
            this.tabPage1.Controls.Add(this.btn_AllatModosit);
            this.tabPage1.Controls.Add(this.btn_UjAllat);
            this.tabPage1.Controls.Add(this.listBox_Gazdasok);
            this.tabPage1.Controls.Add(this.listBox_Allatok);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(712, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "           Állatok            ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(228, 211);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(160, 28);
            this.comboBox2.TabIndex = 10;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(228, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 28);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Gazdás állatok";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Gazdára váró állatok";
            // 
            // btn_Kilepes
            // 
            this.btn_Kilepes.Location = new System.Drawing.Point(448, 361);
            this.btn_Kilepes.Name = "btn_Kilepes";
            this.btn_Kilepes.Size = new System.Drawing.Size(214, 33);
            this.btn_Kilepes.TabIndex = 6;
            this.btn_Kilepes.Text = "Kilépés";
            this.btn_Kilepes.UseVisualStyleBackColor = true;
            this.btn_Kilepes.Click += new System.EventHandler(this.btn_Kilepes_Click);
            // 
            // btn_OrokbefogadasAdatai
            // 
            this.btn_OrokbefogadasAdatai.Location = new System.Drawing.Point(448, 250);
            this.btn_OrokbefogadasAdatai.Name = "btn_OrokbefogadasAdatai";
            this.btn_OrokbefogadasAdatai.Size = new System.Drawing.Size(214, 33);
            this.btn_OrokbefogadasAdatai.TabIndex = 5;
            this.btn_OrokbefogadasAdatai.Text = "Örökbefogadás adatai";
            this.btn_OrokbefogadasAdatai.UseVisualStyleBackColor = true;
            this.btn_OrokbefogadasAdatai.Click += new System.EventHandler(this.btn_OrokbefogadasAdatai_Click);
            // 
            // btn_AllatTorles
            // 
            this.btn_AllatTorles.Location = new System.Drawing.Point(448, 169);
            this.btn_AllatTorles.Name = "btn_AllatTorles";
            this.btn_AllatTorles.Size = new System.Drawing.Size(214, 33);
            this.btn_AllatTorles.TabIndex = 4;
            this.btn_AllatTorles.Text = "Állat törlése";
            this.btn_AllatTorles.UseVisualStyleBackColor = true;
            this.btn_AllatTorles.Click += new System.EventHandler(this.btn_AllatTorles_Click);
            // 
            // btn_AllatModosit
            // 
            this.btn_AllatModosit.Location = new System.Drawing.Point(448, 114);
            this.btn_AllatModosit.Name = "btn_AllatModosit";
            this.btn_AllatModosit.Size = new System.Drawing.Size(214, 33);
            this.btn_AllatModosit.TabIndex = 3;
            this.btn_AllatModosit.Text = "Állat módosítása";
            this.btn_AllatModosit.UseVisualStyleBackColor = true;
            this.btn_AllatModosit.Click += new System.EventHandler(this.btn_AllatModosit_Click);
            // 
            // btn_UjAllat
            // 
            this.btn_UjAllat.Location = new System.Drawing.Point(448, 58);
            this.btn_UjAllat.Name = "btn_UjAllat";
            this.btn_UjAllat.Size = new System.Drawing.Size(214, 33);
            this.btn_UjAllat.TabIndex = 2;
            this.btn_UjAllat.Text = "Új állat";
            this.btn_UjAllat.UseVisualStyleBackColor = true;
            this.btn_UjAllat.Click += new System.EventHandler(this.btn_UjAllat_Click);
            // 
            // listBox_Gazdasok
            // 
            this.listBox_Gazdasok.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox_Gazdasok.FormattingEnabled = true;
            this.listBox_Gazdasok.ItemHeight = 20;
            this.listBox_Gazdasok.Location = new System.Drawing.Point(22, 250);
            this.listBox_Gazdasok.Name = "listBox_Gazdasok";
            this.listBox_Gazdasok.Size = new System.Drawing.Size(366, 144);
            this.listBox_Gazdasok.TabIndex = 1;
            this.listBox_Gazdasok.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_Gazdasok_DrawItem);
            this.listBox_Gazdasok.SelectedIndexChanged += new System.EventHandler(this.listBox_Gazdasok_SelectedIndexChanged);
            // 
            // listBox_Allatok
            // 
            this.listBox_Allatok.FormattingEnabled = true;
            this.listBox_Allatok.ItemHeight = 20;
            this.listBox_Allatok.Location = new System.Drawing.Point(22, 58);
            this.listBox_Allatok.Name = "listBox_Allatok";
            this.listBox_Allatok.Size = new System.Drawing.Size(366, 144);
            this.listBox_Allatok.TabIndex = 0;
            this.listBox_Allatok.SelectedIndexChanged += new System.EventHandler(this.listBox_Allatok_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_GondozoModosit);
            this.tabPage2.Controls.Add(this.btn_UjGondozo);
            this.tabPage2.Controls.Add(this.btn_OrokbeTorol);
            this.tabPage2.Controls.Add(this.btn_OrokbeModosit);
            this.tabPage2.Controls.Add(this.btn_UjOrokbe);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.listBox_Gondozok);
            this.tabPage2.Controls.Add(this.listBox_Orokbefogadok);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(712, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "            Személyek            ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_GondozoModosit
            // 
            this.btn_GondozoModosit.Location = new System.Drawing.Point(446, 304);
            this.btn_GondozoModosit.Name = "btn_GondozoModosit";
            this.btn_GondozoModosit.Size = new System.Drawing.Size(214, 33);
            this.btn_GondozoModosit.TabIndex = 18;
            this.btn_GondozoModosit.Text = "Gondozó módosítása";
            this.btn_GondozoModosit.UseVisualStyleBackColor = true;
            this.btn_GondozoModosit.Click += new System.EventHandler(this.btn_GondozoModosit_Click);
            // 
            // btn_UjGondozo
            // 
            this.btn_UjGondozo.Location = new System.Drawing.Point(446, 250);
            this.btn_UjGondozo.Name = "btn_UjGondozo";
            this.btn_UjGondozo.Size = new System.Drawing.Size(214, 33);
            this.btn_UjGondozo.TabIndex = 17;
            this.btn_UjGondozo.Text = "Új gondozó";
            this.btn_UjGondozo.UseVisualStyleBackColor = true;
            this.btn_UjGondozo.Click += new System.EventHandler(this.btn_UjGondozo_Click);
            // 
            // btn_OrokbeTorol
            // 
            this.btn_OrokbeTorol.Location = new System.Drawing.Point(446, 169);
            this.btn_OrokbeTorol.Name = "btn_OrokbeTorol";
            this.btn_OrokbeTorol.Size = new System.Drawing.Size(214, 33);
            this.btn_OrokbeTorol.TabIndex = 16;
            this.btn_OrokbeTorol.Text = "Örökbefogadó törlése";
            this.btn_OrokbeTorol.UseVisualStyleBackColor = true;
            this.btn_OrokbeTorol.Click += new System.EventHandler(this.btn_OrokbeTorol_Click);
            // 
            // btn_OrokbeModosit
            // 
            this.btn_OrokbeModosit.Location = new System.Drawing.Point(446, 112);
            this.btn_OrokbeModosit.Name = "btn_OrokbeModosit";
            this.btn_OrokbeModosit.Size = new System.Drawing.Size(214, 33);
            this.btn_OrokbeModosit.TabIndex = 15;
            this.btn_OrokbeModosit.Text = "Örökbefogadó módosítása";
            this.btn_OrokbeModosit.UseVisualStyleBackColor = true;
            this.btn_OrokbeModosit.Click += new System.EventHandler(this.btn_OrokbeModosit_Click);
            // 
            // btn_UjOrokbe
            // 
            this.btn_UjOrokbe.Location = new System.Drawing.Point(446, 58);
            this.btn_UjOrokbe.Name = "btn_UjOrokbe";
            this.btn_UjOrokbe.Size = new System.Drawing.Size(214, 33);
            this.btn_UjOrokbe.TabIndex = 14;
            this.btn_UjOrokbe.Text = "Új örökbefogadó";
            this.btn_UjOrokbe.UseVisualStyleBackColor = true;
            this.btn_UjOrokbe.Click += new System.EventHandler(this.btn_UjOrokbe_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Gondozók";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Örökbefogadók";
            // 
            // listBox_Gondozok
            // 
            this.listBox_Gondozok.FormattingEnabled = true;
            this.listBox_Gondozok.ItemHeight = 20;
            this.listBox_Gondozok.Location = new System.Drawing.Point(20, 250);
            this.listBox_Gondozok.Name = "listBox_Gondozok";
            this.listBox_Gondozok.Size = new System.Drawing.Size(366, 144);
            this.listBox_Gondozok.TabIndex = 11;
            this.listBox_Gondozok.SelectedIndexChanged += new System.EventHandler(this.listBox_Gazdasok_SelectedIndexChanged);
            // 
            // listBox_Orokbefogadok
            // 
            this.listBox_Orokbefogadok.FormattingEnabled = true;
            this.listBox_Orokbefogadok.ItemHeight = 20;
            this.listBox_Orokbefogadok.Location = new System.Drawing.Point(20, 58);
            this.listBox_Orokbefogadok.Name = "listBox_Orokbefogadok";
            this.listBox_Orokbefogadok.Size = new System.Drawing.Size(366, 144);
            this.listBox_Orokbefogadok.TabIndex = 10;
            this.listBox_Orokbefogadok.SelectedIndexChanged += new System.EventHandler(this.listBox_Orokbefogadok_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox_Macskak);
            this.tabPage3.Controls.Add(this.richTextBox_GazdasKutyak);
            this.tabPage3.Controls.Add(this.richTextBox_GazdasMacskak);
            this.tabPage3.Controls.Add(this.richTextBox_Kutyak);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(712, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "            Statisztika            ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Macskak
            // 
            this.richTextBox_Macskak.Enabled = false;
            this.richTextBox_Macskak.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Macskak.ForeColor = System.Drawing.Color.OrangeRed;
            this.richTextBox_Macskak.Location = new System.Drawing.Point(437, 94);
            this.richTextBox_Macskak.Name = "richTextBox_Macskak";
            this.richTextBox_Macskak.Size = new System.Drawing.Size(100, 96);
            this.richTextBox_Macskak.TabIndex = 9;
            this.richTextBox_Macskak.Text = "";
            // 
            // richTextBox_GazdasKutyak
            // 
            this.richTextBox_GazdasKutyak.Enabled = false;
            this.richTextBox_GazdasKutyak.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_GazdasKutyak.ForeColor = System.Drawing.Color.Green;
            this.richTextBox_GazdasKutyak.Location = new System.Drawing.Point(105, 272);
            this.richTextBox_GazdasKutyak.Name = "richTextBox_GazdasKutyak";
            this.richTextBox_GazdasKutyak.Size = new System.Drawing.Size(100, 96);
            this.richTextBox_GazdasKutyak.TabIndex = 8;
            this.richTextBox_GazdasKutyak.Text = "";
            // 
            // richTextBox_GazdasMacskak
            // 
            this.richTextBox_GazdasMacskak.Enabled = false;
            this.richTextBox_GazdasMacskak.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_GazdasMacskak.ForeColor = System.Drawing.Color.Green;
            this.richTextBox_GazdasMacskak.Location = new System.Drawing.Point(437, 272);
            this.richTextBox_GazdasMacskak.Name = "richTextBox_GazdasMacskak";
            this.richTextBox_GazdasMacskak.Size = new System.Drawing.Size(100, 96);
            this.richTextBox_GazdasMacskak.TabIndex = 7;
            this.richTextBox_GazdasMacskak.Text = "";
            // 
            // richTextBox_Kutyak
            // 
            this.richTextBox_Kutyak.Enabled = false;
            this.richTextBox_Kutyak.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Kutyak.ForeColor = System.Drawing.Color.OrangeRed;
            this.richTextBox_Kutyak.Location = new System.Drawing.Point(105, 94);
            this.richTextBox_Kutyak.Name = "richTextBox_Kutyak";
            this.richTextBox_Kutyak.Size = new System.Drawing.Size(100, 96);
            this.richTextBox_Kutyak.TabIndex = 6;
            this.richTextBox_Kutyak.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(450, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "Macskák";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(123, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Kutyák";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(450, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Macskák";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Kutyák";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(262, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Örökbefogadott";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(233, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Örökbefogadásra váró";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3600000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 461);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Állatmenhelyi nyilvántartó";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Kilepes;
        private System.Windows.Forms.Button btn_OrokbefogadasAdatai;
        private System.Windows.Forms.Button btn_AllatTorles;
        private System.Windows.Forms.Button btn_AllatModosit;
        private System.Windows.Forms.Button btn_UjAllat;
        private System.Windows.Forms.ListBox listBox_Gazdasok;
        private System.Windows.Forms.ListBox listBox_Allatok;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_GondozoModosit;
        private System.Windows.Forms.Button btn_UjGondozo;
        private System.Windows.Forms.Button btn_OrokbeTorol;
        private System.Windows.Forms.Button btn_OrokbeModosit;
        private System.Windows.Forms.Button btn_UjOrokbe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_Gondozok;
        private System.Windows.Forms.ListBox listBox_Orokbefogadok;
        private System.Windows.Forms.RichTextBox richTextBox_Macskak;
        private System.Windows.Forms.RichTextBox richTextBox_GazdasKutyak;
        private System.Windows.Forms.RichTextBox richTextBox_GazdasMacskak;
        private System.Windows.Forms.RichTextBox richTextBox_Kutyak;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

