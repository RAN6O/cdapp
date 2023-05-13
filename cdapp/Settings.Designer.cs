namespace cdapp
{
    partial class Settings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.Transparency = new System.Windows.Forms.TextBox();
            this.lblTransparency = new System.Windows.Forms.Label();
            this.lblTool = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(88, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 31);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // Transparency
            // 
            this.Transparency.Location = new System.Drawing.Point(136, 24);
            this.Transparency.Name = "Transparency";
            this.Transparency.Size = new System.Drawing.Size(100, 23);
            this.Transparency.TabIndex = 26;
            // 
            // lblTransparency
            // 
            this.lblTransparency.AutoSize = true;
            this.lblTransparency.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTransparency.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTransparency.Location = new System.Drawing.Point(24, 24);
            this.lblTransparency.Name = "lblTransparency";
            this.lblTransparency.Size = new System.Drawing.Size(105, 21);
            this.lblTransparency.TabIndex = 25;
            this.lblTransparency.Text = "Transparency:";
            // 
            // lblTool
            // 
            this.lblTool.AutoSize = true;
            this.lblTool.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTool.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTool.Location = new System.Drawing.Point(40, 104);
            this.lblTool.Name = "lblTool";
            this.lblTool.Size = new System.Drawing.Size(196, 21);
            this.lblTool.TabIndex = 27;
            this.lblTool.Text = "Made by residente#2759";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(281, 137);
            this.Controls.Add(this.lblTool);
            this.Controls.Add(this.Transparency);
            this.Controls.Add(this.lblTransparency);
            this.Controls.Add(this.btnSave);
            this.ForeColor = System.Drawing.Color.Cornsilk;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSave;
        private TextBox Transparency;
        private Label lblTransparency;
        private Label lblTool;
    }
}