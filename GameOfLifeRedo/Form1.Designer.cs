namespace GameOfLifeRedo
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GridColorFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.Information_groupBox = new System.Windows.Forms.GroupBox();
            this.Information_TextBox = new System.Windows.Forms.RichTextBox();
            this.Vorlagenname_label = new System.Windows.Forms.Label();
            this.ElapsedTime = new System.Windows.Forms.Label();
            this.GroupBoxVersionChange = new System.Windows.Forms.GroupBox();
            this.DecBelow = new System.Windows.Forms.NumericUpDown();
            this.DecAbove = new System.Windows.Forms.NumericUpDown();
            this.IncBelow = new System.Windows.Forms.NumericUpDown();
            this.IncAbove = new System.Windows.Forms.NumericUpDown();
            this.button_fertig_regeln_anpassen = new System.Windows.Forms.Button();
            this.Generation_TextOver_label = new System.Windows.Forms.Label();
            this.Generation_Ctr_Label = new System.Windows.Forms.Label();
            this.Rand_Button = new System.Windows.Forms.Button();
            this.Submit_TextBox = new System.Windows.Forms.TextBox();
            this.Submit_Template_Button = new System.Windows.Forms.Button();
            this.ManualTick_Button = new System.Windows.Forms.Button();
            this.FullSymmetric_Button = new System.Windows.Forms.Button();
            this.Start_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GenerationTimer = new System.Windows.Forms.Timer(this.components);
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.neues_Spiel = new System.Windows.Forms.MenuItem();
            this.VorlageSpeichern_MenuItem = new System.Windows.Forms.MenuItem();
            this.AnfangsZustand_MenuItem = new System.Windows.Forms.MenuItem();
            this.Checkpunkt_MenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.Auswählen_menuItem = new System.Windows.Forms.MenuItem();
            this.Einfügen_menuItem = new System.Windows.Forms.MenuItem();
            this.Vorlagen_menuItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.Regeln_anpassen_menu_down = new System.Windows.Forms.MenuItem();
            this.Kopieren_MenuItem = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SizeofcellupDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.MaxSpeed_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ResetSizeBtn = new System.Windows.Forms.Button();
            this.PanelBottom.SuspendLayout();
            this.Information_groupBox.SuspendLayout();
            this.GroupBoxVersionChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecBelow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecAbove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncBelow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncAbove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeofcellupDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSpeed_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // GridColorFlowPanel
            // 
            this.GridColorFlowPanel.AutoScroll = true;
            this.GridColorFlowPanel.BackColor = System.Drawing.Color.White;
            this.GridColorFlowPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridColorFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridColorFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.GridColorFlowPanel.Name = "GridColorFlowPanel";
            this.GridColorFlowPanel.Size = new System.Drawing.Size(1904, 980);
            this.GridColorFlowPanel.TabIndex = 0;
            this.GridColorFlowPanel.SizeChanged += new System.EventHandler(this.GridColorSizeChanged);
            this.GridColorFlowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GridColorFlowPanel_Paint);
            this.GridColorFlowPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridPanel_MouseDown);
            this.GridColorFlowPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridColorFlowPanel_MouseMove);
            this.GridColorFlowPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GridColorFlowPanel_MouseUp);
            this.GridColorFlowPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.GridColorFlowPanel_MouseWheel);
            // 
            // PanelBottom
            // 
            this.PanelBottom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PanelBottom.Controls.Add(this.Information_groupBox);
            this.PanelBottom.Controls.Add(this.Vorlagenname_label);
            this.PanelBottom.Controls.Add(this.ElapsedTime);
            this.PanelBottom.Controls.Add(this.GroupBoxVersionChange);
            this.PanelBottom.Controls.Add(this.Generation_TextOver_label);
            this.PanelBottom.Controls.Add(this.Generation_Ctr_Label);
            this.PanelBottom.Controls.Add(this.Rand_Button);
            this.PanelBottom.Controls.Add(this.Submit_TextBox);
            this.PanelBottom.Controls.Add(this.Submit_Template_Button);
            this.PanelBottom.Controls.Add(this.ManualTick_Button);
            this.PanelBottom.Controls.Add(this.FullSymmetric_Button);
            this.PanelBottom.Controls.Add(this.Start_Button);
            this.PanelBottom.Controls.Add(this.button1);
            this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottom.Location = new System.Drawing.Point(0, 837);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(1904, 143);
            this.PanelBottom.TabIndex = 1;
            // 
            // Information_groupBox
            // 
            this.Information_groupBox.Controls.Add(this.Information_TextBox);
            this.Information_groupBox.Location = new System.Drawing.Point(5, 55);
            this.Information_groupBox.Name = "Information_groupBox";
            this.Information_groupBox.Size = new System.Drawing.Size(124, 67);
            this.Information_groupBox.TabIndex = 16;
            this.Information_groupBox.TabStop = false;
            this.Information_groupBox.Visible = false;
            // 
            // Information_TextBox
            // 
            this.Information_TextBox.Location = new System.Drawing.Point(-2, 9);
            this.Information_TextBox.Name = "Information_TextBox";
            this.Information_TextBox.Size = new System.Drawing.Size(126, 58);
            this.Information_TextBox.TabIndex = 0;
            this.Information_TextBox.Text = "";
            // 
            // Vorlagenname_label
            // 
            this.Vorlagenname_label.AutoSize = true;
            this.Vorlagenname_label.Location = new System.Drawing.Point(252, 66);
            this.Vorlagenname_label.Name = "Vorlagenname_label";
            this.Vorlagenname_label.Size = new System.Drawing.Size(75, 13);
            this.Vorlagenname_label.TabIndex = 15;
            this.Vorlagenname_label.Text = "Vorlagenname";
            this.Vorlagenname_label.Visible = false;
            // 
            // ElapsedTime
            // 
            this.ElapsedTime.AutoSize = true;
            this.ElapsedTime.Location = new System.Drawing.Point(573, 51);
            this.ElapsedTime.Name = "ElapsedTime";
            this.ElapsedTime.Size = new System.Drawing.Size(35, 13);
            this.ElapsedTime.TabIndex = 14;
            this.ElapsedTime.Text = "label1";
            this.ElapsedTime.Visible = false;
            // 
            // GroupBoxVersionChange
            // 
            this.GroupBoxVersionChange.Controls.Add(this.ResetSizeBtn);
            this.GroupBoxVersionChange.Controls.Add(this.MaxSpeed_numericUpDown);
            this.GroupBoxVersionChange.Controls.Add(this.label6);
            this.GroupBoxVersionChange.Controls.Add(this.label5);
            this.GroupBoxVersionChange.Controls.Add(this.SizeofcellupDown);
            this.GroupBoxVersionChange.Controls.Add(this.label4);
            this.GroupBoxVersionChange.Controls.Add(this.label3);
            this.GroupBoxVersionChange.Controls.Add(this.label2);
            this.GroupBoxVersionChange.Controls.Add(this.label1);
            this.GroupBoxVersionChange.Controls.Add(this.DecBelow);
            this.GroupBoxVersionChange.Controls.Add(this.DecAbove);
            this.GroupBoxVersionChange.Controls.Add(this.IncBelow);
            this.GroupBoxVersionChange.Controls.Add(this.IncAbove);
            this.GroupBoxVersionChange.Controls.Add(this.button_fertig_regeln_anpassen);
            this.GroupBoxVersionChange.Location = new System.Drawing.Point(1080, 5);
            this.GroupBoxVersionChange.Name = "GroupBoxVersionChange";
            this.GroupBoxVersionChange.Size = new System.Drawing.Size(313, 126);
            this.GroupBoxVersionChange.TabIndex = 13;
            this.GroupBoxVersionChange.TabStop = false;
            this.GroupBoxVersionChange.Text = "Regeln anpassen";
            this.GroupBoxVersionChange.Visible = false;
            // 
            // DecBelow
            // 
            this.DecBelow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.DecBelow.Location = new System.Drawing.Point(9, 41);
            this.DecBelow.Name = "DecBelow";
            this.DecBelow.Size = new System.Drawing.Size(36, 23);
            this.DecBelow.TabIndex = 17;
            this.DecBelow.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.DecBelow.ValueChanged += new System.EventHandler(this.DecBelow_ValueChanged);
            // 
            // DecAbove
            // 
            this.DecAbove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.DecAbove.Location = new System.Drawing.Point(252, 41);
            this.DecAbove.Name = "DecAbove";
            this.DecAbove.Size = new System.Drawing.Size(36, 23);
            this.DecAbove.TabIndex = 16;
            this.DecAbove.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.DecAbove.ValueChanged += new System.EventHandler(this.DecAbove_ValueChanged);
            // 
            // IncBelow
            // 
            this.IncBelow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.IncBelow.Location = new System.Drawing.Point(194, 41);
            this.IncBelow.Name = "IncBelow";
            this.IncBelow.Size = new System.Drawing.Size(36, 23);
            this.IncBelow.TabIndex = 15;
            this.IncBelow.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.IncBelow.ValueChanged += new System.EventHandler(this.IncBelow_ValueChanged);
            // 
            // IncAbove
            // 
            this.IncAbove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.IncAbove.Location = new System.Drawing.Point(71, 41);
            this.IncAbove.Name = "IncAbove";
            this.IncAbove.Size = new System.Drawing.Size(36, 23);
            this.IncAbove.TabIndex = 14;
            this.IncAbove.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.IncAbove.ValueChanged += new System.EventHandler(this.IncAbove_ValueChanged);
            // 
            // button_fertig_regeln_anpassen
            // 
            this.button_fertig_regeln_anpassen.Location = new System.Drawing.Point(213, 94);
            this.button_fertig_regeln_anpassen.Name = "button_fertig_regeln_anpassen";
            this.button_fertig_regeln_anpassen.Size = new System.Drawing.Size(75, 23);
            this.button_fertig_regeln_anpassen.TabIndex = 13;
            this.button_fertig_regeln_anpassen.Text = "Fertig";
            this.button_fertig_regeln_anpassen.UseVisualStyleBackColor = true;
            this.button_fertig_regeln_anpassen.Click += new System.EventHandler(this.Button_fertig_regeln_anpassen_Click);
            // 
            // Generation_TextOver_label
            // 
            this.Generation_TextOver_label.AutoSize = true;
            this.Generation_TextOver_label.Location = new System.Drawing.Point(486, 30);
            this.Generation_TextOver_label.Name = "Generation_TextOver_label";
            this.Generation_TextOver_label.Size = new System.Drawing.Size(59, 13);
            this.Generation_TextOver_label.TabIndex = 8;
            this.Generation_TextOver_label.Text = "Generation";
            // 
            // Generation_Ctr_Label
            // 
            this.Generation_Ctr_Label.AutoSize = true;
            this.Generation_Ctr_Label.Location = new System.Drawing.Point(505, 50);
            this.Generation_Ctr_Label.Name = "Generation_Ctr_Label";
            this.Generation_Ctr_Label.Size = new System.Drawing.Size(13, 13);
            this.Generation_Ctr_Label.TabIndex = 7;
            this.Generation_Ctr_Label.Text = "0";
            // 
            // Rand_Button
            // 
            this.Rand_Button.Location = new System.Drawing.Point(935, 78);
            this.Rand_Button.Name = "Rand_Button";
            this.Rand_Button.Size = new System.Drawing.Size(117, 23);
            this.Rand_Button.TabIndex = 6;
            this.Rand_Button.Text = "Random";
            this.Rand_Button.UseVisualStyleBackColor = true;
            this.Rand_Button.Click += new System.EventHandler(this.Rand_Button_Click);
            // 
            // Submit_TextBox
            // 
            this.Submit_TextBox.Location = new System.Drawing.Point(252, 89);
            this.Submit_TextBox.Name = "Submit_TextBox";
            this.Submit_TextBox.Size = new System.Drawing.Size(100, 20);
            this.Submit_TextBox.TabIndex = 5;
            this.Submit_TextBox.Visible = false;
            // 
            // Submit_Template_Button
            // 
            this.Submit_Template_Button.Location = new System.Drawing.Point(369, 86);
            this.Submit_Template_Button.Name = "Submit_Template_Button";
            this.Submit_Template_Button.Size = new System.Drawing.Size(106, 23);
            this.Submit_Template_Button.TabIndex = 4;
            this.Submit_Template_Button.Text = "Submit";
            this.Submit_Template_Button.UseVisualStyleBackColor = true;
            this.Submit_Template_Button.Visible = false;
            this.Submit_Template_Button.Click += new System.EventHandler(this.Submit_Template_Button_Click);
            // 
            // ManualTick_Button
            // 
            this.ManualTick_Button.Location = new System.Drawing.Point(935, 13);
            this.ManualTick_Button.Name = "ManualTick_Button";
            this.ManualTick_Button.Size = new System.Drawing.Size(117, 23);
            this.ManualTick_Button.TabIndex = 3;
            this.ManualTick_Button.Text = "Manual Tick";
            this.ManualTick_Button.UseVisualStyleBackColor = true;
            this.ManualTick_Button.Click += new System.EventHandler(this.ManualTick_Button_Click);
            // 
            // FullSymmetric_Button
            // 
            this.FullSymmetric_Button.Location = new System.Drawing.Point(935, 46);
            this.FullSymmetric_Button.Name = "FullSymmetric_Button";
            this.FullSymmetric_Button.Size = new System.Drawing.Size(117, 23);
            this.FullSymmetric_Button.TabIndex = 2;
            this.FullSymmetric_Button.Text = "Full Symmetric";
            this.FullSymmetric_Button.UseVisualStyleBackColor = true;
            this.FullSymmetric_Button.Click += new System.EventHandler(this.FullSymmetric_Button_Click);
            // 
            // Start_Button
            // 
            this.Start_Button.BackColor = System.Drawing.Color.Silver;
            this.Start_Button.Location = new System.Drawing.Point(5, 3);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(124, 46);
            this.Start_Button.TabIndex = 1;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = false;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GenerationTimer
            // 
            this.GenerationTimer.Interval = 50;
            this.GenerationTimer.Tick += new System.EventHandler(this.GenerationTimer_Tick);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.Vorlagen_menuItem,
            this.menuItem5,
            this.menuItem8});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.neues_Spiel,
            this.VorlageSpeichern_MenuItem,
            this.AnfangsZustand_MenuItem,
            this.Checkpunkt_MenuItem});
            this.menuItem1.Text = "Datei";
            // 
            // neues_Spiel
            // 
            this.neues_Spiel.Index = 0;
            this.neues_Spiel.Text = "Neues Spiel";
            this.neues_Spiel.Click += new System.EventHandler(this.neues_Spiel_MenuItem_Click);
            // 
            // VorlageSpeichern_MenuItem
            // 
            this.VorlageSpeichern_MenuItem.Index = 1;
            this.VorlageSpeichern_MenuItem.Text = "Vorlage speichern";
            this.VorlageSpeichern_MenuItem.Click += new System.EventHandler(this.VorlageSpeichern_MenuItem_Click);
            // 
            // AnfangsZustand_MenuItem
            // 
            this.AnfangsZustand_MenuItem.Index = 2;
            this.AnfangsZustand_MenuItem.Text = "Anfangszustand wiederherstellen";
            this.AnfangsZustand_MenuItem.Click += new System.EventHandler(this.AnfangsZustand_MenuItem_Click);
            // 
            // Checkpunkt_MenuItem
            // 
            this.Checkpunkt_MenuItem.Index = 3;
            this.Checkpunkt_MenuItem.Text = "Checkpunkt setzen";
            this.Checkpunkt_MenuItem.Click += new System.EventHandler(this.Checkpunkt_MenuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Auswählen_menuItem,
            this.Kopieren_MenuItem,
            this.Einfügen_menuItem});
            this.menuItem2.Text = "Bearbeiten";
            // 
            // Auswählen_menuItem
            // 
            this.Auswählen_menuItem.Index = 0;
            this.Auswählen_menuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.Auswählen_menuItem.Text = "Auswählen";
            this.Auswählen_menuItem.Click += new System.EventHandler(this.Kopieren_menuItem_Click);
            // 
            // Einfügen_menuItem
            // 
            this.Einfügen_menuItem.Enabled = false;
            this.Einfügen_menuItem.Index = 2;
            this.Einfügen_menuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.Einfügen_menuItem.Text = "Einfügen";
            this.Einfügen_menuItem.Click += new System.EventHandler(this.Einfügen_menuItem_Click);
            // 
            // Vorlagen_menuItem
            // 
            this.Vorlagen_menuItem.Index = 2;
            this.Vorlagen_menuItem.Text = "Vorlagen";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem7,
            this.menuItem9,
            this.menuItem3,
            this.menuItem4,
            this.menuItem10,
            this.menuItem11,
            this.menuItem12});
            this.menuItem5.Text = "Hilfe";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menuItem6.Text = "Was ist Game of Life?";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "Regeln";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 4;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Regeln_anpassen_menu_down});
            this.menuItem8.Text = "Version";
            // 
            // Regeln_anpassen_menu_down
            // 
            this.Regeln_anpassen_menu_down.Index = 0;
            this.Regeln_anpassen_menu_down.Text = "Regeln anpassen";
            this.Regeln_anpassen_menu_down.Click += new System.EventHandler(this.RegelnAnpassenMenu_Click);
            // 
            // Kopieren_MenuItem
            // 
            this.Kopieren_MenuItem.Enabled = false;
            this.Kopieren_MenuItem.Index = 1;
            this.Kopieren_MenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.Kopieren_MenuItem.Text = "Kopieren";
            this.Kopieren_MenuItem.Click += new System.EventHandler(this.Kopieren_MenuItem_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "DecBelow";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "IncBelow";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "DecAbove";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "IncAbove";
            this.label4.Visible = false;
            // 
            // SizeofcellupDown
            // 
            this.SizeofcellupDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.SizeofcellupDown.Location = new System.Drawing.Point(9, 94);
            this.SizeofcellupDown.Name = "SizeofcellupDown";
            this.SizeofcellupDown.Size = new System.Drawing.Size(36, 23);
            this.SizeofcellupDown.TabIndex = 22;
            this.SizeofcellupDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Size Of Cell";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "Wie manipuliere ich die Zellen?";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "Zustand zurücksetzen";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Text = "Eigene Vorlagen speichern";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 5;
            this.menuItem10.Text = "Den Programmablauf schneller machen";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 6;
            this.menuItem11.Text = "Über das Manipulieren von Regeln";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 7;
            this.menuItem12.Text = "Kopieren und Einfügen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Max Speed (ms/Gen)";
            // 
            // MaxSpeed_numericUpDown
            // 
            this.MaxSpeed_numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.MaxSpeed_numericUpDown.Location = new System.Drawing.Point(146, 94);
            this.MaxSpeed_numericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.MaxSpeed_numericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxSpeed_numericUpDown.Name = "MaxSpeed_numericUpDown";
            this.MaxSpeed_numericUpDown.Size = new System.Drawing.Size(36, 23);
            this.MaxSpeed_numericUpDown.TabIndex = 25;
            this.MaxSpeed_numericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxSpeed_numericUpDown.ValueChanged += new System.EventHandler(this.MaxSpeed_numericUpDown_ValueChanged);
            // 
            // ResetSizeBtn
            // 
            this.ResetSizeBtn.Location = new System.Drawing.Point(51, 94);
            this.ResetSizeBtn.Name = "ResetSizeBtn";
            this.ResetSizeBtn.Size = new System.Drawing.Size(55, 23);
            this.ResetSizeBtn.TabIndex = 26;
            this.ResetSizeBtn.Text = "Reset";
            this.ResetSizeBtn.UseVisualStyleBackColor = true;
            this.ResetSizeBtn.Click += new System.EventHandler(this.ResetSizeBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 980);
            this.Controls.Add(this.PanelBottom);
            this.Controls.Add(this.GridColorFlowPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Game of Life by Tim E";
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.PanelBottom.ResumeLayout(false);
            this.PanelBottom.PerformLayout();
            this.Information_groupBox.ResumeLayout(false);
            this.GroupBoxVersionChange.ResumeLayout(false);
            this.GroupBoxVersionChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecBelow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecAbove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncBelow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncAbove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeofcellupDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSpeed_numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel GridColorFlowPanel;
        private System.Windows.Forms.Panel PanelBottom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer GenerationTimer;
        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Button FullSymmetric_Button;
        private System.Windows.Forms.Button ManualTick_Button;
        private System.Windows.Forms.Button Submit_Template_Button;
        private System.Windows.Forms.TextBox Submit_TextBox;
        private System.Windows.Forms.Button Rand_Button;
        private System.Windows.Forms.Label Generation_TextOver_label;
        private System.Windows.Forms.Label Generation_Ctr_Label;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem neues_Spiel;
        private System.Windows.Forms.MenuItem Vorlagen_menuItem;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.GroupBox GroupBoxVersionChange;
        private System.Windows.Forms.MenuItem Regeln_anpassen_menu_down;
        private System.Windows.Forms.Button button_fertig_regeln_anpassen;
        private System.Windows.Forms.Label ElapsedTime;
        private System.Windows.Forms.NumericUpDown DecBelow;
        private System.Windows.Forms.NumericUpDown DecAbove;
        private System.Windows.Forms.NumericUpDown IncBelow;
        private System.Windows.Forms.NumericUpDown IncAbove;
        private System.Windows.Forms.Label Vorlagenname_label;
        private System.Windows.Forms.MenuItem VorlageSpeichern_MenuItem;
        private System.Windows.Forms.MenuItem Checkpunkt_MenuItem;
        private System.Windows.Forms.MenuItem AnfangsZustand_MenuItem;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem Auswählen_menuItem;
        private System.Windows.Forms.MenuItem Einfügen_menuItem;
        private System.Windows.Forms.GroupBox Information_groupBox;
        private System.Windows.Forms.RichTextBox Information_TextBox;
        private System.Windows.Forms.MenuItem Kopieren_MenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown SizeofcellupDown;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.NumericUpDown MaxSpeed_numericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ResetSizeBtn;
    }
}

