namespace Cubing.ConstructPosition
{
    partial class SetupForm
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
            this.CubeBox = new System.Windows.Forms.PictureBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.OrangeLabel = new System.Windows.Forms.Label();
            this.RedLabel = new System.Windows.Forms.Label();
            this.UndoButton = new System.Windows.Forms.Button();
            this.SetUpOllButton = new System.Windows.Forms.Button();
            this.SetUpOllcpButton = new System.Windows.Forms.Button();
            this.SetUpZbllButton = new System.Windows.Forms.Button();
            this.SetUpEllcpButton = new System.Windows.Forms.Button();
            this.SetUp1lllButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CubeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CubeBox
            // 
            this.CubeBox.Location = new System.Drawing.Point(12, 12);
            this.CubeBox.Name = "CubeBox";
            this.CubeBox.Size = new System.Drawing.Size(502, 445);
            this.CubeBox.TabIndex = 0;
            this.CubeBox.TabStop = false;
            this.CubeBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CubeBox_Paint);
            this.CubeBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CubeBox_MouseClick);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(84, 437);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(15, 20);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "r";
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenLabel.ForeColor = System.Drawing.Color.Green;
            this.GreenLabel.Location = new System.Drawing.Point(732, 175);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(65, 58);
            this.GreenLabel.TabIndex = 2;
            this.GreenLabel.Text = "G";
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueLabel.ForeColor = System.Drawing.Color.Blue;
            this.BlueLabel.Location = new System.Drawing.Point(617, 175);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(59, 58);
            this.BlueLabel.TabIndex = 3;
            this.BlueLabel.Text = "B";
            // 
            // OrangeLabel
            // 
            this.OrangeLabel.AutoSize = true;
            this.OrangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrangeLabel.ForeColor = System.Drawing.Color.Orange;
            this.OrangeLabel.Location = new System.Drawing.Point(673, 93);
            this.OrangeLabel.Name = "OrangeLabel";
            this.OrangeLabel.Size = new System.Drawing.Size(65, 58);
            this.OrangeLabel.TabIndex = 4;
            this.OrangeLabel.Text = "O";
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedLabel.ForeColor = System.Drawing.Color.Red;
            this.RedLabel.Location = new System.Drawing.Point(676, 246);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(62, 58);
            this.RedLabel.TabIndex = 5;
            this.RedLabel.Text = "R";
            // 
            // UndoButton
            // 
            this.UndoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UndoButton.Location = new System.Drawing.Point(627, 337);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(123, 37);
            this.UndoButton.TabIndex = 6;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // SetUpOllButton
            // 
            this.SetUpOllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetUpOllButton.Location = new System.Drawing.Point(31, 523);
            this.SetUpOllButton.Name = "SetUpOllButton";
            this.SetUpOllButton.Size = new System.Drawing.Size(170, 31);
            this.SetUpOllButton.TabIndex = 7;
            this.SetUpOllButton.Text = "Set Up OLL";
            this.SetUpOllButton.UseVisualStyleBackColor = true;
            this.SetUpOllButton.Click += new System.EventHandler(this.SetUpOllButton_Click);
            // 
            // SetUpOllcpButton
            // 
            this.SetUpOllcpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetUpOllcpButton.Location = new System.Drawing.Point(246, 523);
            this.SetUpOllcpButton.Name = "SetUpOllcpButton";
            this.SetUpOllcpButton.Size = new System.Drawing.Size(170, 31);
            this.SetUpOllcpButton.TabIndex = 8;
            this.SetUpOllcpButton.Text = "Set Up OLLCP";
            this.SetUpOllcpButton.UseVisualStyleBackColor = true;
            this.SetUpOllcpButton.Click += new System.EventHandler(this.SetUpOllcpButton_Click);
            // 
            // SetUpZbllButton
            // 
            this.SetUpZbllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetUpZbllButton.Location = new System.Drawing.Point(433, 523);
            this.SetUpZbllButton.Name = "SetUpZbllButton";
            this.SetUpZbllButton.Size = new System.Drawing.Size(170, 31);
            this.SetUpZbllButton.TabIndex = 9;
            this.SetUpZbllButton.Text = "Set Up ZBLL";
            this.SetUpZbllButton.UseVisualStyleBackColor = true;
            this.SetUpZbllButton.Click += new System.EventHandler(this.SetUpZbllButton_Click);
            // 
            // SetUpEllcpButton
            // 
            this.SetUpEllcpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetUpEllcpButton.Location = new System.Drawing.Point(433, 560);
            this.SetUpEllcpButton.Name = "SetUpEllcpButton";
            this.SetUpEllcpButton.Size = new System.Drawing.Size(170, 31);
            this.SetUpEllcpButton.TabIndex = 10;
            this.SetUpEllcpButton.Text = "Set Up ELLCP";
            this.SetUpEllcpButton.UseVisualStyleBackColor = true;
            this.SetUpEllcpButton.Click += new System.EventHandler(this.SetUpEllcpButton_Click);
            // 
            // SetUp1lllButton
            // 
            this.SetUp1lllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetUp1lllButton.Location = new System.Drawing.Point(433, 597);
            this.SetUp1lllButton.Name = "SetUp1lllButton";
            this.SetUp1lllButton.Size = new System.Drawing.Size(170, 31);
            this.SetUp1lllButton.TabIndex = 11;
            this.SetUp1lllButton.Text = "Set Up 1LLL";
            this.SetUp1lllButton.UseVisualStyleBackColor = true;
            this.SetUp1lllButton.Click += new System.EventHandler(this.SetUp1lllButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(698, 539);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(123, 37);
            this.CancelButton.TabIndex = 12;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 640);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SetUp1lllButton);
            this.Controls.Add(this.SetUpEllcpButton);
            this.Controls.Add(this.SetUpZbllButton);
            this.Controls.Add(this.SetUpOllcpButton);
            this.Controls.Add(this.SetUpOllButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.RedLabel);
            this.Controls.Add(this.OrangeLabel);
            this.Controls.Add(this.BlueLabel);
            this.Controls.Add(this.GreenLabel);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.CubeBox);
            this.Name = "SetupForm";
            this.Text = "Setup Position";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.CubeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CubeBox;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.Label BlueLabel;
        private System.Windows.Forms.Label OrangeLabel;
        private System.Windows.Forms.Label RedLabel;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button SetUpOllButton;
        private System.Windows.Forms.Button SetUpOllcpButton;
        private System.Windows.Forms.Button SetUpZbllButton;
        private System.Windows.Forms.Button SetUpEllcpButton;
        private System.Windows.Forms.Button SetUp1lllButton;
        private System.Windows.Forms.Button CancelButton;
    }
}

