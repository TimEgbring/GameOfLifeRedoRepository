﻿namespace GameOfLifeRedo
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
            this.Start_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GenerationTimer = new System.Windows.Forms.Timer(this.components);
            this.PanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridColorFlowPanel
            // 
            this.GridColorFlowPanel.AutoScroll = true;
            this.GridColorFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridColorFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.GridColorFlowPanel.Name = "GridColorFlowPanel";
            this.GridColorFlowPanel.Size = new System.Drawing.Size(1105, 700);
            this.GridColorFlowPanel.TabIndex = 0;
            this.GridColorFlowPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GridColorFlowPanel_Paint);
            // 
            // PanelBottom
            // 
            this.PanelBottom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PanelBottom.Controls.Add(this.Start_Button);
            this.PanelBottom.Controls.Add(this.button1);
            this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottom.Location = new System.Drawing.Point(0, 593);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(1105, 107);
            this.PanelBottom.TabIndex = 1;
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
            this.GenerationTimer.Tick += new System.EventHandler(this.GenerationTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 700);
            this.Controls.Add(this.PanelBottom);
            this.Controls.Add(this.GridColorFlowPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.PanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel GridColorFlowPanel;
        private System.Windows.Forms.Panel PanelBottom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer GenerationTimer;
        private System.Windows.Forms.Button Start_Button;
    }
}
