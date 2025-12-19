namespace CanMonitor.WinForms
{
    partial class SimulatorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label simulatorLabel;

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
            simulatorLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // simulatorLabel
            // 
            simulatorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            simulatorLabel.Location = new System.Drawing.Point(0, 0);
            simulatorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            simulatorLabel.Name = "simulatorLabel";
            simulatorLabel.Padding = new System.Windows.Forms.Padding(12);
            simulatorLabel.Size = new System.Drawing.Size(400, 200);
            simulatorLabel.TabIndex = 0;
            simulatorLabel.Text = "Tritium simulator placeholder. Add simulator controls here.";
            simulatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SimulatorForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 200);
            Controls.Add(simulatorLabel);
            Name = "SimulatorForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Tritium Simulator";
            ResumeLayout(false);
        }

        #endregion
    }
}
