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
            this.GridColorFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.Rand_Button = new System.Windows.Forms.Button();
            this.Submit_TextBox = new System.Windows.Forms.TextBox();
            this.Submit_Template_Button = new System.Windows.Forms.Button();
            this.ManualTick_Button = new System.Windows.Forms.Button();
            this.FullSymmetric_Button = new System.Windows.Forms.Button();
            this.Start_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GenerationTimer = new System.Windows.Forms.Timer(this.components);
            this.Generation_Ctr_Label = new System.Windows.Forms.Label();
            this.Generation_TextOver_label = new System.Windows.Forms.Label();
            this.PanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridColorFlowPanel
            // 
            this.GridColorFlowPanel.AutoScroll = true;
            this.GridColorFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridColorFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.GridColorFlowPanel.Name = "GridColorFlowPanel";
            this.GridColorFlowPanel.Size = new System.Drawing.Size(1117, 637);
            this.GridColorFlowPanel.TabIndex = 0;
            this.GridColorFlowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GridColorFlowPanel_Paint);
            this.GridColorFlowPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridPanel_MouseDown);
            // 
            // PanelBottom
            // 
            this.PanelBottom.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.PanelBottom.Location = new System.Drawing.Point(0, 530);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(1117, 107);
            this.PanelBottom.TabIndex = 1;
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
            this.Submit_TextBox.Location = new System.Drawing.Point(574, 68);
            this.Submit_TextBox.Name = "Submit_TextBox";
            this.Submit_TextBox.Size = new System.Drawing.Size(100, 20);
            this.Submit_TextBox.TabIndex = 5;
            this.Submit_TextBox.Visible = false;
            // 
            // Submit_Template_Button
            // 
            this.Submit_Template_Button.Location = new System.Drawing.Point(698, 66);
            this.Submit_Template_Button.Name = "Submit_Template_Button";
            this.Submit_Template_Button.Size = new System.Drawing.Size(106, 23);
            this.Submit_Template_Button.TabIndex = 4;
            this.Submit_Template_Button.Text = "Submit";
            this.Submit_Template_Button.UseVisualStyleBackColor = true;
            this.Submit_Template_Button.Visible = false;
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
            this.Start_Button.Location = new System.Drawing.Point(13, 66);
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
            // Generation_Ctr_Label
            // 
            this.Generation_Ctr_Label.AutoSize = true;
            this.Generation_Ctr_Label.Location = new System.Drawing.Point(494, 66);
            this.Generation_Ctr_Label.Name = "Generation_Ctr_Label";
            this.Generation_Ctr_Label.Size = new System.Drawing.Size(13, 13);
            this.Generation_Ctr_Label.TabIndex = 7;
            this.Generation_Ctr_Label.Text = "0";
           
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 637);
            this.Controls.Add(this.PanelBottom);
            this.Controls.Add(this.GridColorFlowPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.PanelBottom.ResumeLayout(false);
            this.PanelBottom.PerformLayout();
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
    }
}

