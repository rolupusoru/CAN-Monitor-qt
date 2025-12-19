namespace CanMonitor.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTreeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTreeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortItemsLiveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableColumnsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableIdMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableDlcMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableCountMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enablePeriodMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableRawDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableDecodedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableFormatMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulatorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commanderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commanderDirectoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCommanderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cansoleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCansoleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel generalStatusLabel;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.FlowLayoutPanel connectionPanel;
        private System.Windows.Forms.ComboBox adapterComboBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Button startSimulationButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label formatLabel;
        private System.Windows.Forms.TextBox formatStringTextBox;
        private System.Windows.Forms.SplitContainer treeAndGridSplit;
        private System.Windows.Forms.TreeView frameTree;
        private System.Windows.Forms.DataGridView frameGrid;
        private System.Windows.Forms.FlowLayoutPanel transmitPanel;
        private System.Windows.Forms.Label sendIdLabel;
        private System.Windows.Forms.TextBox sendIdTextBox;
        private System.Windows.Forms.Label sendDataLabel;
        private System.Windows.Forms.TextBox sendDataTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dlcColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rawDataColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn decodedDataColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formatColumn;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadTreeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveTreeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            sortItemsLiveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enableColumnsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enableIdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enableDlcMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enableCountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enablePeriodMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enableRawDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enableDecodedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            enableFormatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            traceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            simulatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            commanderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            commanderDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newCommanderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            cansoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openCansoleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip = new System.Windows.Forms.StatusStrip();
            connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            generalStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            mainLayout = new System.Windows.Forms.TableLayoutPanel();
            connectionPanel = new System.Windows.Forms.FlowLayoutPanel();
            adapterComboBox = new System.Windows.Forms.ComboBox();
            connectButton = new System.Windows.Forms.Button();
            disconnectButton = new System.Windows.Forms.Button();
            startSimulationButton = new System.Windows.Forms.Button();
            clearButton = new System.Windows.Forms.Button();
            formatLabel = new System.Windows.Forms.Label();
            formatStringTextBox = new System.Windows.Forms.TextBox();
            treeAndGridSplit = new System.Windows.Forms.SplitContainer();
            frameTree = new System.Windows.Forms.TreeView();
            frameGrid = new System.Windows.Forms.DataGridView();
            idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dlcColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            countColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            periodColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            rawDataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            decodedDataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            formatColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            transmitPanel = new System.Windows.Forms.FlowLayoutPanel();
            sendIdLabel = new System.Windows.Forms.Label();
            sendIdTextBox = new System.Windows.Forms.TextBox();
            sendDataLabel = new System.Windows.Forms.Label();
            sendDataTextBox = new System.Windows.Forms.TextBox();
            sendButton = new System.Windows.Forms.Button();
            mainMenuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            mainLayout.SuspendLayout();
            connectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeAndGridSplit).BeginInit();
            treeAndGridSplit.Panel1.SuspendLayout();
            treeAndGridSplit.Panel2.SuspendLayout();
            treeAndGridSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)frameGrid).BeginInit();
            transmitPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileMenuItem, viewMenuItem, toolsMenuItem, commanderMenuItem, cansoleMenuItem, helpMenuItem });
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new System.Drawing.Size(1184, 28);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { loadTreeMenuItem, saveTreeMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new System.Drawing.Size(46, 24);
            fileMenuItem.Text = "File";
            // 
            // loadTreeMenuItem
            // 
            loadTreeMenuItem.Name = "loadTreeMenuItem";
            loadTreeMenuItem.Size = new System.Drawing.Size(158, 26);
            loadTreeMenuItem.Text = "Load Tree";
            // 
            // saveTreeMenuItem
            // 
            saveTreeMenuItem.Name = "saveTreeMenuItem";
            saveTreeMenuItem.Size = new System.Drawing.Size(158, 26);
            saveTreeMenuItem.Text = "Save Tree";
            // 
            // viewMenuItem
            // 
            viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { sortItemsLiveMenuItem, enableColumnsMenuItem });
            viewMenuItem.Name = "viewMenuItem";
            viewMenuItem.Size = new System.Drawing.Size(55, 24);
            viewMenuItem.Text = "View";
            // 
            // sortItemsLiveMenuItem
            // 
            sortItemsLiveMenuItem.Checked = true;
            sortItemsLiveMenuItem.CheckOnClick = true;
            sortItemsLiveMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            sortItemsLiveMenuItem.Name = "sortItemsLiveMenuItem";
            sortItemsLiveMenuItem.Size = new System.Drawing.Size(196, 26);
            sortItemsLiveMenuItem.Text = "Sort Items Live";
            // 
            // enableColumnsMenuItem
            // 
            enableColumnsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { enableIdMenuItem, enableDlcMenuItem, enableCountMenuItem, enablePeriodMenuItem, enableRawDataMenuItem, enableDecodedMenuItem, enableFormatMenuItem });
            enableColumnsMenuItem.Name = "enableColumnsMenuItem";
            enableColumnsMenuItem.Size = new System.Drawing.Size(196, 26);
            enableColumnsMenuItem.Text = "Enable Columns";
            // 
            // enableIdMenuItem
            // 
            enableIdMenuItem.Checked = true;
            enableIdMenuItem.CheckOnClick = true;
            enableIdMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            enableIdMenuItem.Name = "enableIdMenuItem";
            enableIdMenuItem.Size = new System.Drawing.Size(206, 26);
            enableIdMenuItem.Text = "ID";
            // 
            // enableDlcMenuItem
            // 
            enableDlcMenuItem.Checked = true;
            enableDlcMenuItem.CheckOnClick = true;
            enableDlcMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            enableDlcMenuItem.Name = "enableDlcMenuItem";
            enableDlcMenuItem.Size = new System.Drawing.Size(206, 26);
            enableDlcMenuItem.Text = "DLC";
            // 
            // enableCountMenuItem
            // 
            enableCountMenuItem.Checked = true;
            enableCountMenuItem.CheckOnClick = true;
            enableCountMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            enableCountMenuItem.Name = "enableCountMenuItem";
            enableCountMenuItem.Size = new System.Drawing.Size(206, 26);
            enableCountMenuItem.Text = "Count";
            // 
            // enablePeriodMenuItem
            // 
            enablePeriodMenuItem.Checked = true;
            enablePeriodMenuItem.CheckOnClick = true;
            enablePeriodMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            enablePeriodMenuItem.Name = "enablePeriodMenuItem";
            enablePeriodMenuItem.Size = new System.Drawing.Size(206, 26);
            enablePeriodMenuItem.Text = "Period";
            // 
            // enableRawDataMenuItem
            // 
            enableRawDataMenuItem.Checked = true;
            enableRawDataMenuItem.CheckOnClick = true;
            enableRawDataMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            enableRawDataMenuItem.Name = "enableRawDataMenuItem";
            enableRawDataMenuItem.Size = new System.Drawing.Size(206, 26);
            enableRawDataMenuItem.Text = "Raw Data";
            // 
            // enableDecodedMenuItem
            // 
            enableDecodedMenuItem.Checked = true;
            enableDecodedMenuItem.CheckOnClick = true;
            enableDecodedMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            enableDecodedMenuItem.Name = "enableDecodedMenuItem";
            enableDecodedMenuItem.Size = new System.Drawing.Size(206, 26);
            enableDecodedMenuItem.Text = "Decoded Data";
            // 
            // enableFormatMenuItem
            // 
            enableFormatMenuItem.Checked = true;
            enableFormatMenuItem.CheckOnClick = true;
            enableFormatMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            enableFormatMenuItem.Name = "enableFormatMenuItem";
            enableFormatMenuItem.Size = new System.Drawing.Size(206, 26);
            enableFormatMenuItem.Text = "Format String";
            // 
            // toolsMenuItem
            // 
            toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { traceMenuItem, simulatorMenuItem });
            toolsMenuItem.Name = "toolsMenuItem";
            toolsMenuItem.Size = new System.Drawing.Size(58, 24);
            toolsMenuItem.Text = "Tools";
            // 
            // traceMenuItem
            // 
            traceMenuItem.Name = "traceMenuItem";
            traceMenuItem.Size = new System.Drawing.Size(208, 26);
            traceMenuItem.Text = "Trace";
            // 
            // simulatorMenuItem
            // 
            simulatorMenuItem.Name = "simulatorMenuItem";
            simulatorMenuItem.Size = new System.Drawing.Size(208, 26);
            simulatorMenuItem.Text = "Tritium Simulator";
            // 
            // commanderMenuItem
            // 
            commanderMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { commanderDirectoryMenuItem, newCommanderMenuItem });
            commanderMenuItem.Name = "commanderMenuItem";
            commanderMenuItem.Size = new System.Drawing.Size(92, 24);
            commanderMenuItem.Text = "Commander";
            // 
            // commanderDirectoryMenuItem
            // 
            commanderDirectoryMenuItem.Name = "commanderDirectoryMenuItem";
            commanderDirectoryMenuItem.Size = new System.Drawing.Size(245, 26);
            commanderDirectoryMenuItem.Text = "Set Commander Directory";
            // 
            // newCommanderMenuItem
            // 
            newCommanderMenuItem.Name = "newCommanderMenuItem";
            newCommanderMenuItem.Size = new System.Drawing.Size(245, 26);
            newCommanderMenuItem.Text = "New Commander";
            // 
            // cansoleMenuItem
            // 
            cansoleMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openCansoleMenuItem });
            cansoleMenuItem.Name = "cansoleMenuItem";
            cansoleMenuItem.Size = new System.Drawing.Size(77, 24);
            cansoleMenuItem.Text = "Cansole";
            // 
            // openCansoleMenuItem
            // 
            openCansoleMenuItem.Name = "openCansoleMenuItem";
            openCansoleMenuItem.Size = new System.Drawing.Size(207, 26);
            openCansoleMenuItem.Text = "Open Cansole ...";
            // 
            // helpMenuItem
            // 
            helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aboutMenuItem });
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new System.Drawing.Size(55, 24);
            helpMenuItem.Text = "Help";
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new System.Drawing.Size(133, 26);
            aboutMenuItem.Text = "About";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { connectionStatusLabel, generalStatusLabel });
            statusStrip.Location = new System.Drawing.Point(0, 669);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(1184, 26);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // connectionStatusLabel
            // 
            connectionStatusLabel.Name = "connectionStatusLabel";
            connectionStatusLabel.Size = new System.Drawing.Size(157, 20);
            connectionStatusLabel.Text = "Adapter: disconnected";
            // 
            // generalStatusLabel
            // 
            generalStatusLabel.Name = "generalStatusLabel";
            generalStatusLabel.Size = new System.Drawing.Size(50, 20);
            generalStatusLabel.Text = "Ready";
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainLayout.Controls.Add(connectionPanel, 0, 0);
            mainLayout.Controls.Add(treeAndGridSplit, 0, 1);
            mainLayout.Controls.Add(transmitPanel, 0, 2);
            mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayout.Location = new System.Drawing.Point(0, 28);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            mainLayout.Size = new System.Drawing.Size(1184, 641);
            mainLayout.TabIndex = 1;
            // 
            // connectionPanel
            // 
            connectionPanel.AutoSize = true;
            connectionPanel.Controls.Add(adapterComboBox);
            connectionPanel.Controls.Add(connectButton);
            connectionPanel.Controls.Add(disconnectButton);
            connectionPanel.Controls.Add(startSimulationButton);
            connectionPanel.Controls.Add(clearButton);
            connectionPanel.Controls.Add(formatLabel);
            connectionPanel.Controls.Add(formatStringTextBox);
            connectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            connectionPanel.Location = new System.Drawing.Point(4, 4);
            connectionPanel.Margin = new System.Windows.Forms.Padding(4);
            connectionPanel.Name = "connectionPanel";
            connectionPanel.Padding = new System.Windows.Forms.Padding(4);
            connectionPanel.Size = new System.Drawing.Size(1176, 40);
            connectionPanel.TabIndex = 0;
            connectionPanel.WrapContents = false;
            // 
            // adapterComboBox
            // 
            adapterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            adapterComboBox.Items.AddRange(new object[] { "Simulation Adapter" });
            adapterComboBox.Location = new System.Drawing.Point(8, 8);
            adapterComboBox.Margin = new System.Windows.Forms.Padding(4);
            adapterComboBox.MinimumSize = new System.Drawing.Size(150, 0);
            adapterComboBox.Name = "adapterComboBox";
            adapterComboBox.Size = new System.Drawing.Size(150, 28);
            adapterComboBox.TabIndex = 0;
            adapterComboBox.SelectedIndex = 0;
            // 
            // connectButton
            // 
            connectButton.AutoSize = true;
            connectButton.Location = new System.Drawing.Point(166, 8);
            connectButton.Margin = new System.Windows.Forms.Padding(4);
            connectButton.Name = "connectButton";
            connectButton.Size = new System.Drawing.Size(78, 29);
            connectButton.TabIndex = 1;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            // 
            // disconnectButton
            // 
            disconnectButton.AutoSize = true;
            disconnectButton.Location = new System.Drawing.Point(252, 8);
            disconnectButton.Margin = new System.Windows.Forms.Padding(4);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new System.Drawing.Size(96, 29);
            disconnectButton.TabIndex = 2;
            disconnectButton.Text = "Disconnect";
            disconnectButton.UseVisualStyleBackColor = true;
            // 
            // startSimulationButton
            // 
            startSimulationButton.AutoSize = true;
            startSimulationButton.Location = new System.Drawing.Point(356, 8);
            startSimulationButton.Margin = new System.Windows.Forms.Padding(4);
            startSimulationButton.Name = "startSimulationButton";
            startSimulationButton.Size = new System.Drawing.Size(132, 29);
            startSimulationButton.TabIndex = 3;
            startSimulationButton.Text = "Start Simulation";
            startSimulationButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            clearButton.AutoSize = true;
            clearButton.Location = new System.Drawing.Point(496, 8);
            clearButton.Margin = new System.Windows.Forms.Padding(4);
            clearButton.Name = "clearButton";
            clearButton.Size = new System.Drawing.Size(58, 29);
            clearButton.TabIndex = 4;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            // 
            // formatLabel
            // 
            formatLabel.AutoSize = true;
            formatLabel.Location = new System.Drawing.Point(562, 12);
            formatLabel.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            formatLabel.Name = "formatLabel";
            formatLabel.Size = new System.Drawing.Size(99, 20);
            formatLabel.TabIndex = 5;
            formatLabel.Text = "Format string:";
            // 
            // formatStringTextBox
            // 
            formatStringTextBox.Location = new System.Drawing.Point(669, 8);
            formatStringTextBox.Margin = new System.Windows.Forms.Padding(4);
            formatStringTextBox.MinimumSize = new System.Drawing.Size(220, 0);
            formatStringTextBox.Name = "formatStringTextBox";
            formatStringTextBox.PlaceholderText = "u8,u16,U32";
            formatStringTextBox.Size = new System.Drawing.Size(260, 27);
            formatStringTextBox.TabIndex = 6;
            // 
            // treeAndGridSplit
            // 
            treeAndGridSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            treeAndGridSplit.Location = new System.Drawing.Point(4, 52);
            treeAndGridSplit.Margin = new System.Windows.Forms.Padding(4);
            treeAndGridSplit.Name = "treeAndGridSplit";
            // 
            // treeAndGridSplit.Panel1
            // 
            treeAndGridSplit.Panel1.Controls.Add(frameTree);
            // 
            // treeAndGridSplit.Panel2
            // 
            treeAndGridSplit.Panel2.Controls.Add(frameGrid);
            treeAndGridSplit.Size = new System.Drawing.Size(1176, 527);
            treeAndGridSplit.SplitterDistance = 240;
            treeAndGridSplit.TabIndex = 1;
            // 
            // frameTree
            // 
            frameTree.Dock = System.Windows.Forms.DockStyle.Fill;
            frameTree.Location = new System.Drawing.Point(0, 0);
            frameTree.Margin = new System.Windows.Forms.Padding(4);
            frameTree.Name = "frameTree";
            frameTree.Size = new System.Drawing.Size(240, 527);
            frameTree.TabIndex = 0;
            // 
            // frameGrid
            // 
            frameGrid.AllowUserToAddRows = false;
            frameGrid.AllowUserToDeleteRows = false;
            frameGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            frameGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            frameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            frameGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { idColumn, dlcColumn, countColumn, periodColumn, rawDataColumn, decodedDataColumn, formatColumn });
            frameGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            frameGrid.Location = new System.Drawing.Point(0, 0);
            frameGrid.Margin = new System.Windows.Forms.Padding(4);
            frameGrid.Name = "frameGrid";
            frameGrid.ReadOnly = true;
            frameGrid.RowHeadersVisible = false;
            frameGrid.RowHeadersWidth = 51;
            frameGrid.RowTemplate.Height = 29;
            frameGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            frameGrid.Size = new System.Drawing.Size(932, 527);
            frameGrid.TabIndex = 0;
            // 
            // idColumn
            // 
            idColumn.HeaderText = "ID";
            idColumn.MinimumWidth = 6;
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            // 
            // dlcColumn
            // 
            dlcColumn.HeaderText = "DLC";
            dlcColumn.MinimumWidth = 6;
            dlcColumn.Name = "dlcColumn";
            dlcColumn.ReadOnly = true;
            // 
            // countColumn
            // 
            countColumn.HeaderText = "Count";
            countColumn.MinimumWidth = 6;
            countColumn.Name = "countColumn";
            countColumn.ReadOnly = true;
            // 
            // periodColumn
            // 
            periodColumn.HeaderText = "Period (ms)";
            periodColumn.MinimumWidth = 6;
            periodColumn.Name = "periodColumn";
            periodColumn.ReadOnly = true;
            // 
            // rawDataColumn
            // 
            rawDataColumn.HeaderText = "Raw Data";
            rawDataColumn.MinimumWidth = 6;
            rawDataColumn.Name = "rawDataColumn";
            rawDataColumn.ReadOnly = true;
            // 
            // decodedDataColumn
            // 
            decodedDataColumn.HeaderText = "Decoded Data";
            decodedDataColumn.MinimumWidth = 6;
            decodedDataColumn.Name = "decodedDataColumn";
            decodedDataColumn.ReadOnly = true;
            // 
            // formatColumn
            // 
            formatColumn.HeaderText = "Format";
            formatColumn.MinimumWidth = 6;
            formatColumn.Name = "formatColumn";
            formatColumn.ReadOnly = true;
            // 
            // transmitPanel
            // 
            transmitPanel.AutoSize = true;
            transmitPanel.Controls.Add(sendIdLabel);
            transmitPanel.Controls.Add(sendIdTextBox);
            transmitPanel.Controls.Add(sendDataLabel);
            transmitPanel.Controls.Add(sendDataTextBox);
            transmitPanel.Controls.Add(sendButton);
            transmitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            transmitPanel.Location = new System.Drawing.Point(4, 587);
            transmitPanel.Margin = new System.Windows.Forms.Padding(4);
            transmitPanel.Name = "transmitPanel";
            transmitPanel.Padding = new System.Windows.Forms.Padding(4);
            transmitPanel.Size = new System.Drawing.Size(1176, 50);
            transmitPanel.TabIndex = 2;
            transmitPanel.WrapContents = false;
            // 
            // sendIdLabel
            // 
            sendIdLabel.AutoSize = true;
            sendIdLabel.Location = new System.Drawing.Point(8, 12);
            sendIdLabel.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            sendIdLabel.Name = "sendIdLabel";
            sendIdLabel.Size = new System.Drawing.Size(101, 20);
            sendIdLabel.TabIndex = 0;
            sendIdLabel.Text = "Send ID (hex):";
            // 
            // sendIdTextBox
            // 
            sendIdTextBox.Location = new System.Drawing.Point(117, 8);
            sendIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            sendIdTextBox.Name = "sendIdTextBox";
            sendIdTextBox.PlaceholderText = "0x123";
            sendIdTextBox.Size = new System.Drawing.Size(100, 27);
            sendIdTextBox.TabIndex = 1;
            // 
            // sendDataLabel
            // 
            sendDataLabel.AutoSize = true;
            sendDataLabel.Location = new System.Drawing.Point(225, 12);
            sendDataLabel.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            sendDataLabel.Name = "sendDataLabel";
            sendDataLabel.Size = new System.Drawing.Size(121, 20);
            sendDataLabel.TabIndex = 2;
            sendDataLabel.Text = "Data (hex bytes):";
            // 
            // sendDataTextBox
            // 
            sendDataTextBox.Location = new System.Drawing.Point(354, 8);
            sendDataTextBox.Margin = new System.Windows.Forms.Padding(4);
            sendDataTextBox.MinimumSize = new System.Drawing.Size(220, 0);
            sendDataTextBox.Name = "sendDataTextBox";
            sendDataTextBox.PlaceholderText = "01 02 03";
            sendDataTextBox.Size = new System.Drawing.Size(260, 27);
            sendDataTextBox.TabIndex = 3;
            // 
            // sendButton
            // 
            sendButton.AutoSize = true;
            sendButton.Location = new System.Drawing.Point(622, 8);
            sendButton.Margin = new System.Windows.Forms.Padding(4);
            sendButton.Name = "sendButton";
            sendButton.Size = new System.Drawing.Size(57, 29);
            sendButton.TabIndex = 4;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1184, 695);
            Controls.Add(mainLayout);
            Controls.Add(statusStrip);
            Controls.Add(mainMenuStrip);
            MainMenuStrip = mainMenuStrip;
            MinimumSize = new System.Drawing.Size(1024, 640);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "CAN Monitor";
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            connectionPanel.ResumeLayout(false);
            connectionPanel.PerformLayout();
            treeAndGridSplit.Panel1.ResumeLayout(false);
            treeAndGridSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeAndGridSplit).EndInit();
            treeAndGridSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)frameGrid).EndInit();
            transmitPanel.ResumeLayout(false);
            transmitPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
