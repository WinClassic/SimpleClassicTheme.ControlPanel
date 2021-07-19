
namespace SimpleClassicTheme.ControlPanel.DisplayProperties.Controls
{
    partial class AppearancePreview
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
            this.SuspendLayout();
            // 
            // AppearancePreview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Name = "AppearancePreview";
            this.Size = new System.Drawing.Size(347, 185);
            this.Load += new System.EventHandler(this.AppearancePreview_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AppearancePreview_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
