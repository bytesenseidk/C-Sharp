
namespace ResourceApp_GUI
{
    partial class Form1
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
            this.splitline_nyheder = new System.Windows.Forms.Label();
            this.splitline_center = new System.Windows.Forms.Label();
            this.splitline_tidszone = new System.Windows.Forms.Label();
            this.toplabel_klima = new System.Windows.Forms.Label();
            this.toplabel_lager = new System.Windows.Forms.Label();
            this.toplabel_tidszoner = new System.Windows.Forms.Label();
            this.toplabel_nyheder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // splitline_nyheder
            // 
            this.splitline_nyheder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitline_nyheder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.splitline_nyheder.Location = new System.Drawing.Point(0, 354);
            this.splitline_nyheder.Name = "splitline_nyheder";
            this.splitline_nyheder.Size = new System.Drawing.Size(802, 2);
            this.splitline_nyheder.TabIndex = 0;
            this.splitline_nyheder.Text = "_______________________________________________________________";
            // 
            // splitline_center
            // 
            this.splitline_center.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitline_center.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.splitline_center.Location = new System.Drawing.Point(323, 1);
            this.splitline_center.Name = "splitline_center";
            this.splitline_center.Size = new System.Drawing.Size(2, 355);
            this.splitline_center.TabIndex = 1;
            this.splitline_center.Text = "_______________________________________________________________";
            // 
            // splitline_tidszone
            // 
            this.splitline_tidszone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitline_tidszone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.splitline_tidszone.Location = new System.Drawing.Point(-1, 239);
            this.splitline_tidszone.Name = "splitline_tidszone";
            this.splitline_tidszone.Size = new System.Drawing.Size(326, 2);
            this.splitline_tidszone.TabIndex = 2;
            this.splitline_tidszone.Text = "_______________________________________________________________";
            // 
            // toplabel_klima
            // 
            this.toplabel_klima.AutoSize = true;
            this.toplabel_klima.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplabel_klima.Location = new System.Drawing.Point(23, 4);
            this.toplabel_klima.Name = "toplabel_klima";
            this.toplabel_klima.Size = new System.Drawing.Size(277, 25);
            this.toplabel_klima.TabIndex = 3;
            this.toplabel_klima.Text = "Temperatur og Fugtighed";
            // 
            // toplabel_lager
            // 
            this.toplabel_lager.AutoSize = true;
            this.toplabel_lager.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplabel_lager.Location = new System.Drawing.Point(492, 3);
            this.toplabel_lager.Name = "toplabel_lager";
            this.toplabel_lager.Size = new System.Drawing.Size(136, 25);
            this.toplabel_lager.TabIndex = 4;
            this.toplabel_lager.Text = "Lagerstatus";
            // 
            // toplabel_tidszoner
            // 
            this.toplabel_tidszoner.AutoSize = true;
            this.toplabel_tidszoner.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplabel_tidszoner.Location = new System.Drawing.Point(97, 245);
            this.toplabel_tidszoner.Name = "toplabel_tidszoner";
            this.toplabel_tidszoner.Size = new System.Drawing.Size(116, 25);
            this.toplabel_tidszoner.TabIndex = 5;
            this.toplabel_tidszoner.Text = "Tidszoner";
            // 
            // toplabel_nyheder
            // 
            this.toplabel_nyheder.AutoSize = true;
            this.toplabel_nyheder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplabel_nyheder.Location = new System.Drawing.Point(351, 360);
            this.toplabel_nyheder.Name = "toplabel_nyheder";
            this.toplabel_nyheder.Size = new System.Drawing.Size(100, 25);
            this.toplabel_nyheder.TabIndex = 6;
            this.toplabel_nyheder.Text = "Nyheder";
            this.toplabel_nyheder.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toplabel_nyheder);
            this.Controls.Add(this.toplabel_tidszoner);
            this.Controls.Add(this.toplabel_lager);
            this.Controls.Add(this.toplabel_klima);
            this.Controls.Add(this.splitline_tidszone);
            this.Controls.Add(this.splitline_center);
            this.Controls.Add(this.splitline_nyheder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label splitline_nyheder;
        private System.Windows.Forms.Label splitline_center;
        private System.Windows.Forms.Label splitline_tidszone;
        private System.Windows.Forms.Label toplabel_klima;
        private System.Windows.Forms.Label toplabel_lager;
        private System.Windows.Forms.Label toplabel_tidszoner;
        private System.Windows.Forms.Label toplabel_nyheder;
    }
}

