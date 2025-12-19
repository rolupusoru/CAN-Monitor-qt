namespace CanMonitor.WinForms
{
    partial class CommanderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox commanderListBox;

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
            commanderListBox = new System.Windows.Forms.ListBox();
            SuspendLayout();
            // 
            // commanderListBox
            // 
            commanderListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            commanderListBox.FormattingEnabled = true;
            commanderListBox.ItemHeight = 20;
            commanderListBox.Items.AddRange(new object[] { "PCM Commander", "HV Commander", "Motor Commander" });
            commanderListBox.Location = new System.Drawing.Point(0, 0);
            commanderListBox.Margin = new System.Windows.Forms.Padding(4);
            commanderListBox.Name = "commanderListBox";
            commanderListBox.Size = new System.Drawing.Size(320, 260);
            commanderListBox.TabIndex = 0;
            // 
            // CommanderForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(320, 260);
            Controls.Add(commanderListBox);
            Name = "CommanderForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Commander";
            ResumeLayout(false);
        }

        #endregion
    }
}
