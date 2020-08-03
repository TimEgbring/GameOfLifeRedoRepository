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
            this.Vorlagen_menuItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.Regeln_anpassen_menu_down = new System.Windows.Forms.MenuItem();
            this.PanelBottom.SuspendLayout();
            this.GroupBoxVersionChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecBelow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecAbove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncBelow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncAbove)).BeginInit();
            this.SuspendLayout();
            // 
            // GridColorFlowPanel
            // 
            this.GridColorFlowPanel.AutoScroll = true;
            this.GridColorFlowPanel.BackColor = System.Drawing.Color.White;
            this.GridColorFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridColorFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.GridColorFlowPanel.Name = "GridColorFlowPanel";
            this.GridColorFlowPanel.Size = new System.Drawing.Size(1904, 980);
            this.GridColorFlowPanel.TabIndex = 0;
            this.GridColorFlowPanel.SizeChanged += new System.EventHandler(this.GridColorSizeChanged);
            this.GridColorFlowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GridColorFlowPanel_Paint);
            this.GridColorFlowPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridPanel_MouseDown);
            // 
            // PanelBottom
            // 
            this.PanelBottom.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.PanelBottom.Location = new System.Drawing.Point(0, 790);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(1904, 190);
            this.PanelBottom.TabIndex = 1;
            // 
            // Vorlagenname_label
            // 
            this.Vorlagenname_label.AutoSize = true;
            this.Vorlagenname_label.Location = new System.Drawing.Point(302, 90);
            this.Vorlagenname_label.Name = "Vorlagenname_label";
            this.Vorlagenname_label.Size = new System.Drawing.Size(75, 13);
            this.Vorlagenname_label.TabIndex = 15;
            this.Vorlagenname_label.Text = "Vorlagenname";
            this.Vorlagenname_label.Visible = false;
            // 
            // ElapsedTime
            // 
            this.ElapsedTime.AutoSize = true;
            this.ElapsedTime.Location = new System.Drawing.Point(540, 66);
            this.ElapsedTime.Name = "ElapsedTime";
            this.ElapsedTime.Size = new System.Drawing.Size(35, 13);
            this.ElapsedTime.TabIndex = 14;
            this.ElapsedTime.Text = "label1";
            this.ElapsedTime.Visible = false;
            // 
            // GroupBoxVersionChange
            // 
            this.GroupBoxVersionChange.Controls.Add(this.DecBelow);
            this.GroupBoxVersionChange.Controls.Add(this.DecAbove);
            this.GroupBoxVersionChange.Controls.Add(this.IncBelow);
            this.GroupBoxVersionChange.Controls.Add(this.IncAbove);
            this.GroupBoxVersionChange.Controls.Add(this.button_fertig_regeln_anpassen);
            this.GroupBoxVersionChange.Location = new System.Drawing.Point(632, 0);
            this.GroupBoxVersionChange.Name = "GroupBoxVersionChange";
            this.GroupBoxVersionChange.Size = new System.Drawing.Size(228, 187);
            this.GroupBoxVersionChange.TabIndex = 13;
            this.GroupBoxVersionChange.TabStop = false;
            this.GroupBoxVersionChange.Text = "Regeln anpassen";
            this.GroupBoxVersionChange.Visible = false;
            // 
            // DecBelow
            // 
            this.DecBelow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.DecBelow.Location = new System.Drawing.Point(6, 95);
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
            this.DecAbove.Location = new System.Drawing.Point(172, 95);
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
            this.IncBelow.Location = new System.Drawing.Point(130, 95);
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
            this.IncAbove.Location = new System.Drawing.Point(48, 95);
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
            this.button_fertig_regeln_anpassen.Location = new System.Drawing.Point(147, 158);
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
            this.Generation_TextOver_label.Location = new System.Drawing.Point(475, 46);
            this.Generation_TextOver_label.Name = "Generation_TextOver_label";
            this.Generation_TextOver_label.Size = new System.Drawing.Size(59, 13);
            this.Generation_TextOver_label.TabIndex = 8;
            this.Generation_TextOver_label.Text = "Generation";
            // 
            // Generation_Ctr_Label
            // 
            this.Generation_Ctr_Label.AutoSize = true;
            this.Generation_Ctr_Label.Location = new System.Drawing.Point(494, 66);
            this.Generation_Ctr_Label.Name = "Generation_Ctr_Label";
            this.Generation_Ctr_Label.Size = new System.Drawing.Size(13, 13);
            this.Generation_Ctr_Label.TabIndex = 7;
            this.Generation_Ctr_Label.Text = "0";
            // 
            // Rand_Button
            // 
            this.Rand_Button.Location = new System.Drawing.Point(912, 68);
            this.Rand_Button.Name = "Rand_Button";
            this.Rand_Button.Size = new System.Drawing.Size(75, 23);
            this.Rand_Button.TabIndex = 6;
            this.Rand_Button.Text = "Random";
            this.Rand_Button.UseVisualStyleBackColor = true;
            this.Rand_Button.Click += new System.EventHandler(this.Rand_Button_Click);
            // 
            // Submit_TextBox
            // 
            this.Submit_TextBox.Location = new System.Drawing.Point(302, 113);
            this.Submit_TextBox.Name = "Submit_TextBox";
            this.Submit_TextBox.Size = new System.Drawing.Size(100, 20);
            this.Submit_TextBox.TabIndex = 5;
            this.Submit_TextBox.Visible = false;
            // 
            // Submit_Template_Button
            // 
            this.Submit_Template_Button.Location = new System.Drawing.Point(419, 110);
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
            this.ManualTick_Button.Location = new System.Drawing.Point(912, 11);
            this.ManualTick_Button.Name = "ManualTick_Button";
            this.ManualTick_Button.Size = new System.Drawing.Size(117, 23);
            this.ManualTick_Button.TabIndex = 3;
            this.ManualTick_Button.Text = "Manual Tick";
            this.ManualTick_Button.UseVisualStyleBackColor = true;
            this.ManualTick_Button.Click += new System.EventHandler(this.ManualTick_Button_Click);
            // 
            // FullSymmetric_Button
            // 
            this.FullSymmetric_Button.Location = new System.Drawing.Point(912, 41);
            this.FullSymmetric_Button.Name = "FullSymmetric_Button";
            this.FullSymmetric_Button.Size = new System.Drawing.Size(117, 23);
            this.FullSymmetric_Button.TabIndex = 2;
            this.FullSymmetric_Button.Text = "Full Symmetric";
            this.FullSymmetric_Button.UseVisualStyleBackColor = true;
            this.FullSymmetric_Button.Click += new System.EventHandler(this.FullSymmetric_Button_Click);
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(3, 72);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(124, 32);
            this.Start_Button.TabIndex = 1;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GenerationTimer
            // 
            this.GenerationTimer.Interval = 10;
            this.GenerationTimer.Tick += new System.EventHandler(this.GenerationTimer_Tick);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
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
            // Vorlagen_menuItem
            // 
            this.Vorlagen_menuItem.Index = 1;
            this.Vorlagen_menuItem.Text = "Vorlagen";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem7});
            this.menuItem5.Text = "Hilfe";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "Was ist Game of Life?";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "Regeln";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 980);
            this.Controls.Add(this.PanelBottom);
            this.Controls.Add(this.GridColorFlowPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Game of Life by Tim E";
            this.PanelBottom.ResumeLayout(false);
            this.PanelBottom.PerformLayout();
            this.GroupBoxVersionChange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DecBelow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DecAbove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncBelow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncAbove)).EndInit();
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
    }
}

