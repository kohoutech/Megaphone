namespace Megaphone
{
    partial class MegaWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MegaWindow));
            this.SignalsStatus = new System.Windows.Forms.StatusStrip();
            this.SignalsMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsTransportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterTimer = new System.Windows.Forms.Timer(this.components);
            this.signalsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SignalsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SignalsStatus
            // 
            this.SignalsStatus.Location = new System.Drawing.Point(0, 99);
            this.SignalsStatus.Name = "SignalsStatus";
            this.SignalsStatus.Size = new System.Drawing.Size(689, 22);
            this.SignalsStatus.TabIndex = 0;
            this.SignalsStatus.Text = "statusStrip1";
            // 
            // SignalsMenu
            // 
            this.SignalsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.transportMenuItem,
            this.helpMenuItem});
            this.SignalsMenu.Location = new System.Drawing.Point(0, 0);
            this.SignalsMenu.Name = "SignalsMenu";
            this.SignalsMenu.Size = new System.Drawing.Size(689, 24);
            this.SignalsMenu.TabIndex = 1;
            this.SignalsMenu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem,
            this.closeFileMenuItem,
            this.fileMenuSeparator1,
            this.exitFileMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "&File";
            this.fileMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileMenuItem.Image")));
            this.openFileMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileMenuItem.Size = new System.Drawing.Size(167, 22);
            this.openFileMenuItem.Text = "&Open File";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // closeFileMenuItem
            // 
            this.closeFileMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.closeFileMenuItem.Enabled = false;
            this.closeFileMenuItem.Name = "closeFileMenuItem";
            this.closeFileMenuItem.Size = new System.Drawing.Size(167, 22);
            this.closeFileMenuItem.Text = "&Close File";
            this.closeFileMenuItem.Click += new System.EventHandler(this.closeFileMenuItem_Click);
            // 
            // fileMenuSeparator1
            // 
            this.fileMenuSeparator1.Name = "fileMenuSeparator1";
            this.fileMenuSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // exitFileMenuItem
            // 
            this.exitFileMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitFileMenuItem.Name = "exitFileMenuItem";
            this.exitFileMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitFileMenuItem.Text = "E&xit";
            this.exitFileMenuItem.Click += new System.EventHandler(this.exitFileMenuItem_Click);
            // 
            // transportMenuItem
            // 
            this.transportMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsTransportMenuItem});
            this.transportMenuItem.Enabled = false;
            this.transportMenuItem.Name = "transportMenuItem";
            this.transportMenuItem.Size = new System.Drawing.Size(69, 20);
            this.transportMenuItem.Text = "Trans&port";
            // 
            // settingsTransportMenuItem
            // 
            this.settingsTransportMenuItem.Name = "settingsTransportMenuItem";
            this.settingsTransportMenuItem.Size = new System.Drawing.Size(169, 22);
            this.settingsTransportMenuItem.Text = "&Transport Settings";
            this.settingsTransportMenuItem.Click += new System.EventHandler(this.settingsTransportMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutHelpMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "&Help";
            // 
            // aboutHelpMenuItem
            // 
            this.aboutHelpMenuItem.Name = "aboutHelpMenuItem";
            this.aboutHelpMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutHelpMenuItem.Text = "&About...";
            this.aboutHelpMenuItem.Click += new System.EventHandler(this.aboutHelpMenuItem_Click);
            // 
            // masterTimer
            // 
            this.masterTimer.Interval = 50;
            this.masterTimer.Tick += new System.EventHandler(this.masterTimer_Tick);
            // 
            // signalsToolTip
            // 
            this.signalsToolTip.BackColor = System.Drawing.Color.Yellow;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "sx1";
            // 
            // MegaWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrchid;
            this.ClientSize = new System.Drawing.Size(689, 121);
            this.Controls.Add(this.SignalsStatus);
            this.Controls.Add(this.SignalsMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.SignalsMenu;
            this.MaximumSize = new System.Drawing.Size(705, 160);
            this.MinimumSize = new System.Drawing.Size(705, 160);
            this.Name = "MegaWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Megaphone";
            this.SignalsMenu.ResumeLayout(false);
            this.SignalsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SignalsStatus;
        private System.Windows.Forms.MenuStrip SignalsMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutHelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeFileMenuItem;
        private System.Windows.Forms.Timer masterTimer;
        private System.Windows.Forms.ToolStripMenuItem settingsTransportMenuItem;
        private System.Windows.Forms.ToolTip signalsToolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

