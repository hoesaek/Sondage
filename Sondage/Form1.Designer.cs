namespace Sondage
{
    partial class Form1
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
            menuStrip1 = new MenuStrip();
            nouveauSondageToolStripMenuItem = new ToolStripMenuItem();
            consulterUnAncienSondageToolStripMenuItem = new ToolStripMenuItem();
            ajouterUnNouveauSondageToolStripMenuItem = new ToolStripMenuItem();
            progressBarTempsRestant = new ProgressBar();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { nouveauSondageToolStripMenuItem, consulterUnAncienSondageToolStripMenuItem, ajouterUnNouveauSondageToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1582, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // nouveauSondageToolStripMenuItem
            // 
            nouveauSondageToolStripMenuItem.Name = "nouveauSondageToolStripMenuItem";
            nouveauSondageToolStripMenuItem.Size = new Size(145, 24);
            nouveauSondageToolStripMenuItem.Text = "Nouveau Sondage";
            nouveauSondageToolStripMenuItem.Click += nouveauSondageToolStripMenuItem_Click;
            // 
            // consulterUnAncienSondageToolStripMenuItem
            // 
            consulterUnAncienSondageToolStripMenuItem.Name = "consulterUnAncienSondageToolStripMenuItem";
            consulterUnAncienSondageToolStripMenuItem.Size = new Size(129, 24);
            consulterUnAncienSondageToolStripMenuItem.Text = "Ancien sondage";
            consulterUnAncienSondageToolStripMenuItem.Click += consulterUnAncienSondageToolStripMenuItem_Click;
            // 
            // ajouterUnNouveauSondageToolStripMenuItem
            // 
            ajouterUnNouveauSondageToolStripMenuItem.Name = "ajouterUnNouveauSondageToolStripMenuItem";
            ajouterUnNouveauSondageToolStripMenuItem.Size = new Size(143, 24);
            ajouterUnNouveauSondageToolStripMenuItem.Text = "Sondage en Cours";
            ajouterUnNouveauSondageToolStripMenuItem.Click += ajouterUnNouveauSondageToolStripMenuItem_Click;
            // 
            // progressBarTempsRestant
            // 
            progressBarTempsRestant.Location = new Point(263, 992);
            progressBarTempsRestant.Name = "progressBarTempsRestant";
            progressBarTempsRestant.Size = new Size(1125, 29);
            progressBarTempsRestant.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(639, 302);
            button1.Name = "button1";
            button1.Size = new Size(201, 86);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 853);
            Controls.Add(button1);
            Controls.Add(progressBarTempsRestant);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sondage";
            Load += Form1_Load;
            Leave += Form1_Leave;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ProgressBar progressBarTempsRestant;
        private ToolStripMenuItem ajouterUnNouveauSondageToolStripMenuItem;
        private ToolStripMenuItem consulterUnAncienSondageToolStripMenuItem;
        private ToolStripMenuItem nouveauSondageToolStripMenuItem;
        private Button button1;
    }
}
