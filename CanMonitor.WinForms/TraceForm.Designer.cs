namespace CanMonitor.WinForms
{
    partial class TraceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox traceTextBox;

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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            traceTextBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // traceTextBox
            // 
            traceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            traceTextBox.Location = new System.Drawing.Point(0, 0);
            traceTextBox.Margin = new System.Windows.Forms.Padding(4);
            traceTextBox.Multiline = true;
            traceTextBox.Name = "traceTextBox";
            traceTextBox.PlaceholderText = "Trace output will appear here";
            traceTextBox.ReadOnly = true;
            traceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            traceTextBox.Size = new System.Drawing.Size(600, 400);
            traceTextBox.TabIndex = 0;
            // 
            // TraceForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(600, 400);
            Controls.Add(traceTextBox);
            Name = "TraceForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Trace";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
