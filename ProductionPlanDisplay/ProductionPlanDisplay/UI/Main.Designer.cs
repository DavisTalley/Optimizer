namespace ProductionPlanDisplay.UI
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListProcessLog = new System.Windows.Forms.ListBox();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ToolMain = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.Main_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this._Main_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Main_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Main_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Main_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolMain)).BeginInit();
            this.Main_Fill_Panel.ClientArea.SuspendLayout();
            this.Main_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ListProcessLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 588);
            this.panel1.TabIndex = 0;
            // 
            // ListProcessLog
            // 
            this.ListProcessLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListProcessLog.FormattingEnabled = true;
            this.ListProcessLog.Location = new System.Drawing.Point(0, 0);
            this.ListProcessLog.Name = "ListProcessLog";
            this.ListProcessLog.Size = new System.Drawing.Size(639, 588);
            this.ListProcessLog.TabIndex = 0;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 588);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            ultraStatusPanel1.Key = "sbPanMessage";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel2.Key = "sbPanProgress";
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel2.Width = 200;
            ultraStatusPanel3.Key = "sbPanDate";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel4.Key = "sbPanTime";
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel4.Width = 90;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4});
            this.ultraStatusBar1.Size = new System.Drawing.Size(2014, 23);
            this.ultraStatusBar1.TabIndex = 1;
            this.ultraStatusBar1.Text = "ultraStatusBar1";
            // 
            // ToolMain
            // 
            this.ToolMain.DesignerFlags = 1;
            this.ToolMain.DockWithinContainer = this;
            this.ToolMain.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            // 
            // Main_Fill_Panel
            // 
            // 
            // Main_Fill_Panel.ClientArea
            // 
            this.Main_Fill_Panel.ClientArea.Controls.Add(this.panel1);
            this.Main_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.Main_Fill_Panel.Name = "Main_Fill_Panel";
            this.Main_Fill_Panel.Size = new System.Drawing.Size(2014, 588);
            this.Main_Fill_Panel.TabIndex = 2;
            // 
            // _Main_Toolbars_Dock_Area_Left
            // 
            this._Main_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Main_Toolbars_Dock_Area_Left.BackColor = System.Drawing.SystemColors.Control;
            this._Main_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Main_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Main_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._Main_Toolbars_Dock_Area_Left.Name = "_Main_Toolbars_Dock_Area_Left";
            this._Main_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 588);
            this._Main_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolMain;
            // 
            // _Main_Toolbars_Dock_Area_Right
            // 
            this._Main_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Main_Toolbars_Dock_Area_Right.BackColor = System.Drawing.SystemColors.Control;
            this._Main_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Main_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Main_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(2014, 0);
            this._Main_Toolbars_Dock_Area_Right.Name = "_Main_Toolbars_Dock_Area_Right";
            this._Main_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 588);
            this._Main_Toolbars_Dock_Area_Right.ToolbarsManager = this.ToolMain;
            // 
            // _Main_Toolbars_Dock_Area_Top
            // 
            this._Main_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Main_Toolbars_Dock_Area_Top.BackColor = System.Drawing.SystemColors.Control;
            this._Main_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Main_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Main_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Main_Toolbars_Dock_Area_Top.Name = "_Main_Toolbars_Dock_Area_Top";
            this._Main_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(2014, 0);
            this._Main_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolMain;
            // 
            // _Main_Toolbars_Dock_Area_Bottom
            // 
            this._Main_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Main_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control;
            this._Main_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Main_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Main_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 588);
            this._Main_Toolbars_Dock_Area_Bottom.Name = "_Main_Toolbars_Dock_Area_Bottom";
            this._Main_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(2014, 0);
            this._Main_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolMain;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2014, 611);
            this.Controls.Add(this.Main_Fill_Panel);
            this.Controls.Add(this._Main_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._Main_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._Main_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this._Main_Toolbars_Dock_Area_Top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolMain)).EndInit();
            this.Main_Fill_Panel.ClientArea.ResumeLayout(false);
            this.Main_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox ListProcessLog;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ToolMain;
        private Infragistics.Win.Misc.UltraPanel Main_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Main_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Main_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Main_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Main_Toolbars_Dock_Area_Top;
    }
}

