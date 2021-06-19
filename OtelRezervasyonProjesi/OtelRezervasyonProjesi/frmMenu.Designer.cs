
namespace OtelRezervasyonProjesi
{
    partial class frmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.mstMdiMenu = new System.Windows.Forms.MenuStrip();
            this.GirisYap = new System.Windows.Forms.ToolStripMenuItem();
            this.mstMdiMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstMdiMenu
            // 
            this.mstMdiMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GirisYap});
            this.mstMdiMenu.Location = new System.Drawing.Point(0, 0);
            this.mstMdiMenu.Name = "mstMdiMenu";
            this.mstMdiMenu.Size = new System.Drawing.Size(1023, 24);
            this.mstMdiMenu.TabIndex = 1;
            this.mstMdiMenu.Text = "menuStrip1";
            // 
            // GirisYap
            // 
            this.GirisYap.Name = "GirisYap";
            this.GirisYap.Size = new System.Drawing.Size(64, 20);
            this.GirisYap.Text = "Giriş Yap";
            this.GirisYap.Click += new System.EventHandler(this.GirisYap_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 626);
            this.Controls.Add(this.mstMdiMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mstMdiMenu;
            this.Name = "frmMenu";
            this.Text = "Form1";
            this.mstMdiMenu.ResumeLayout(false);
            this.mstMdiMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstMdiMenu;
        private System.Windows.Forms.ToolStripMenuItem GirisYap;
    }
}

