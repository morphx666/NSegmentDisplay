namespace NSegmentDisplay {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.LabelHelp1 = new System.Windows.Forms.Label();
            this.LabelHelp2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelHelp1
            // 
            this.LabelHelp1.AutoSize = true;
            this.LabelHelp1.Location = new System.Drawing.Point(15, 12);
            this.LabelHelp1.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.LabelHelp1.Name = "LabelHelp1";
            this.LabelHelp1.Size = new System.Drawing.Size(350, 17);
            this.LabelHelp1.TabIndex = 0;
            this.LabelHelp1.Text = "Use Left/Right arrows to change supported display modes";
            // 
            // LabelHelp2
            // 
            this.LabelHelp2.AutoSize = true;
            this.LabelHelp2.Location = new System.Drawing.Point(15, 35);
            this.LabelHelp2.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.LabelHelp2.Name = "LabelHelp2";
            this.LabelHelp2.Size = new System.Drawing.Size(314, 17);
            this.LabelHelp2.TabIndex = 0;
            this.LabelHelp2.Text = "Use Up/Down arrows to change segments\' thickness";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(964, 401);
            this.Controls.Add(this.LabelHelp2);
            this.Controls.Add(this.LabelHelp1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NSegment Display";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelHelp1;
        private System.Windows.Forms.Label LabelHelp2;
    }
}

