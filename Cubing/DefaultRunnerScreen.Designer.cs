namespace ZbllDemo
{
    partial class DefaultRunnerScreen
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
            this.CubePicture = new System.Windows.Forms.PictureBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.AlgLabel = new System.Windows.Forms.Label();
            this.HelpLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CubePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // CubePicture
            // 
            this.CubePicture.Location = new System.Drawing.Point(24, -26);
            this.CubePicture.Name = "CubePicture";
            this.CubePicture.Size = new System.Drawing.Size(715, 561);
            this.CubePicture.TabIndex = 0;
            this.CubePicture.TabStop = false;
            this.CubePicture.Paint += new System.Windows.Forms.PaintEventHandler(this.CubePicture_Paint);
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(53, 658);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(122, 47);
            this.BackButton.TabIndex = 1;
            this.BackButton.TabStop = false;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NumberLabel
            // 
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberLabel.Location = new System.Drawing.Point(74, 86);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(45, 25);
            this.NumberLabel.TabIndex = 2;
            this.NumberLabel.Text = "243";
            // 
            // AlgLabel
            // 
            this.AlgLabel.AutoSize = true;
            this.AlgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgLabel.Location = new System.Drawing.Point(83, 587);
            this.AlgLabel.Name = "AlgLabel";
            this.AlgLabel.Size = new System.Drawing.Size(471, 33);
            this.AlgLabel.TabIndex = 3;
            this.AlgLabel.Text = "R U R\' U\' R\' F R2 U\' R\' U\' R U R\' F\'";
            // 
            // HelpLabel
            // 
            this.HelpLabel.AutoSize = true;
            this.HelpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpLabel.Location = new System.Drawing.Point(249, 658);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(318, 20);
            this.HelpLabel.TabIndex = 4;
            this.HelpLabel.Text = "Press spacebar to move to next position. ";
            // 
            // DefaultRunnerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.HelpLabel);
            this.Controls.Add(this.AlgLabel);
            this.Controls.Add(this.NumberLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CubePicture);
            this.Name = "DefaultRunnerScreen";
            this.Text = "RunnerScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RunnerScreen_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RunnerScreen_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.CubePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CubePicture;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.Label AlgLabel;
        private System.Windows.Forms.Label HelpLabel;
    }
}