namespace ProductionPlanDisplay.UI.Controls
{
    partial class TaktTime
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.panState = new Infragistics.Win.Misc.UltraPanel();
            this.lblTakt = new Infragistics.Win.Misc.UltraLabel();
            this.panState.ClientArea.SuspendLayout();
            this.panState.SuspendLayout();
            this.SuspendLayout();
            // 
            // panState
            // 
            appearance1.BackColor = System.Drawing.Color.Black;
            this.panState.Appearance = appearance1;
            // 
            // panState.ClientArea
            // 
            this.panState.ClientArea.Controls.Add(this.lblTakt);
            this.panState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panState.Location = new System.Drawing.Point(0, 0);
            this.panState.Name = "panState";
            this.panState.Size = new System.Drawing.Size(457, 48);
            this.panState.TabIndex = 0;
            // 
            // lblTakt
            // 
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextVAlignAsString = "Middle";
            this.lblTakt.Appearance = appearance2;
            this.lblTakt.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTakt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTakt.Location = new System.Drawing.Point(0, 0);
            this.lblTakt.Name = "lblTakt";
            this.lblTakt.Size = new System.Drawing.Size(36, 48);
            this.lblTakt.TabIndex = 0;
            this.lblTakt.Text = "OFF";
            // 
            // TaktTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panState);
            this.Name = "TaktTime";
            this.Size = new System.Drawing.Size(457, 48);
            this.panState.ClientArea.ResumeLayout(false);
            this.panState.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel panState;
        private Infragistics.Win.Misc.UltraLabel lblTakt;
    }
}
