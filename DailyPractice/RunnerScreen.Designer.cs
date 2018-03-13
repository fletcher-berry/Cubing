namespace DailyPractice
{
    partial class RunnerScreen
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
            this.AlgLabel = new System.Windows.Forms.Label();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.CubePicture = new System.Windows.Forms.PictureBox();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CubePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // AlgLabel
            // 
            this.AlgLabel.AutoSize = true;
            this.AlgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgLabel.Location = new System.Drawing.Point(85, 572);
            this.AlgLabel.Name = "AlgLabel";
            this.AlgLabel.Size = new System.Drawing.Size(471, 33);
            this.AlgLabel.TabIndex = 6;
            this.AlgLabel.Text = "R U R\' U\' R\' F R2 U\' R\' U\' R U R\' F\'";
            // 
            // NumberLabel
            // 
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberLabel.Location = new System.Drawing.Point(76, 71);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(45, 25);
            this.NumberLabel.TabIndex = 5;
            this.NumberLabel.Text = "243";
            // 
            // CubePicture
            // 
            this.CubePicture.Location = new System.Drawing.Point(24, 28);
            this.CubePicture.Name = "CubePicture";
            this.CubePicture.Size = new System.Drawing.Size(715, 561);
            this.CubePicture.TabIndex = 4;
            this.CubePicture.TabStop = false;
            this.CubePicture.Paint += new System.Windows.Forms.PaintEventHandler(this.CubePicture_Paint);
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(591, 650);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(122, 47);
            this.BackButton.TabIndex = 7;
            this.BackButton.TabStop = false;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // RunnerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.AlgLabel);
            this.Controls.Add(this.NumberLabel);
            this.Controls.Add(this.CubePicture);
            this.Name = "RunnerScreen";
            this.Text = "RunnerScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RunnerScreen_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RunnerScreen_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.CubePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AlgLabel;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.PictureBox CubePicture;
        private System.Windows.Forms.Button BackButton;
    }
}