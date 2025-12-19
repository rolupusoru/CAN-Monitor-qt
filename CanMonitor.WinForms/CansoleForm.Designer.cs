namespace CanMonitor.WinForms
{
    partial class CansoleForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox cansoleTextBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cansoleTextBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // cansoleTextBox
            // 
            cansoleTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            cansoleTextBox.Location = new System.Drawing.Point(0, 0);
            cansoleTextBox.Margin = new System.Windows.Forms.Padding(4);
            cansoleTextBox.Multiline = true;
            cansoleTextBox.Name = "cansoleTextBox";
            cansoleTextBox.PlaceholderText = "Interactive Cansole placeholder";
            cansoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            cansoleTextBox.Size = new System.Drawing.Size(500, 320);
            cansoleTextBox.TabIndex = 0;
            // 
            // CansoleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(500, 320);
            Controls.Add(cansoleTextBox);
            Name = "CansoleForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Cansole";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
