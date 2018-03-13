namespace DailyPractice
{
    partial class MainScreen
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
            this.SampleCubeView = new System.Windows.Forms.PictureBox();
            this.SetupPositionButton = new System.Windows.Forms.Button();
            this.PositionBox = new System.Windows.Forms.TextBox();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.DaysBox = new System.Windows.Forms.TextBox();
            this.DaysLabel = new System.Windows.Forms.Label();
            this.AddPositionButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.AlgSetSelector = new System.Windows.Forms.ComboBox();
            this.ChangeAlgorithmButton = new System.Windows.Forms.Button();
            this.AlgorithmBox = new System.Windows.Forms.TextBox();
            this.AlgLabel = new System.Windows.Forms.Label();
            this.ConstructPositionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SampleCubeView)).BeginInit();
            this.SuspendLayout();
            // 
            // SampleCubeView
            // 
            this.SampleCubeView.Location = new System.Drawing.Point(99, 12);
            this.SampleCubeView.Name = "SampleCubeView";
            this.SampleCubeView.Size = new System.Drawing.Size(499, 448);
            this.SampleCubeView.TabIndex = 1;
            this.SampleCubeView.TabStop = false;
            this.SampleCubeView.Paint += new System.Windows.Forms.PaintEventHandler(this.SampleCubeView_Paint);
            // 
            // SetupPositionButton
            // 
            this.SetupPositionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetupPositionButton.Location = new System.Drawing.Point(56, 646);
            this.SetupPositionButton.Name = "SetupPositionButton";
            this.SetupPositionButton.Size = new System.Drawing.Size(217, 49);
            this.SetupPositionButton.TabIndex = 6;
            this.SetupPositionButton.TabStop = false;
            this.SetupPositionButton.Text = "View Position";
            this.SetupPositionButton.UseVisualStyleBackColor = true;
            this.SetupPositionButton.Click += new System.EventHandler(this.SetupPositionButton_Click);
            // 
            // PositionBox
            // 
            this.PositionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionBox.Location = new System.Drawing.Point(313, 507);
            this.PositionBox.Name = "PositionBox";
            this.PositionBox.Size = new System.Drawing.Size(204, 38);
            this.PositionBox.TabIndex = 5;
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionLabel.Location = new System.Drawing.Point(50, 507);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(244, 36);
            this.PositionLabel.TabIndex = 4;
            this.PositionLabel.Text = "Position Number:";
            // 
            // DaysBox
            // 
            this.DaysBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaysBox.Location = new System.Drawing.Point(146, 572);
            this.DaysBox.Name = "DaysBox";
            this.DaysBox.Size = new System.Drawing.Size(371, 38);
            this.DaysBox.TabIndex = 7;
            // 
            // DaysLabel
            // 
            this.DaysLabel.AutoSize = true;
            this.DaysLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DaysLabel.Location = new System.Drawing.Point(50, 572);
            this.DaysLabel.Name = "DaysLabel";
            this.DaysLabel.Size = new System.Drawing.Size(90, 36);
            this.DaysLabel.TabIndex = 8;
            this.DaysLabel.Text = "Days:";
            // 
            // AddPositionButton
            // 
            this.AddPositionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPositionButton.Location = new System.Drawing.Point(296, 646);
            this.AddPositionButton.Name = "AddPositionButton";
            this.AddPositionButton.Size = new System.Drawing.Size(221, 49);
            this.AddPositionButton.TabIndex = 9;
            this.AddPositionButton.TabStop = false;
            this.AddPositionButton.Text = "Add Position";
            this.AddPositionButton.UseVisualStyleBackColor = true;
            this.AddPositionButton.Click += new System.EventHandler(this.AddPositionButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunButton.Location = new System.Drawing.Point(575, 572);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(143, 122);
            this.RunButton.TabIndex = 10;
            this.RunButton.Text = "Run!";
            this.RunButton.UseCompatibleTextRendering = true;
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // AlgSetSelector
            // 
            this.AlgSetSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgSetSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgSetSelector.FormattingEnabled = true;
            this.AlgSetSelector.Location = new System.Drawing.Point(563, 506);
            this.AlgSetSelector.Name = "AlgSetSelector";
            this.AlgSetSelector.Size = new System.Drawing.Size(169, 37);
            this.AlgSetSelector.TabIndex = 11;
            this.AlgSetSelector.SelectedValueChanged += new System.EventHandler(this.AlgSetSelector_SelectedValueChanged);
            // 
            // ChangeAlgorithmButton
            // 
            this.ChangeAlgorithmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeAlgorithmButton.Location = new System.Drawing.Point(635, 444);
            this.ChangeAlgorithmButton.Name = "ChangeAlgorithmButton";
            this.ChangeAlgorithmButton.Size = new System.Drawing.Size(126, 45);
            this.ChangeAlgorithmButton.TabIndex = 14;
            this.ChangeAlgorithmButton.TabStop = false;
            this.ChangeAlgorithmButton.Text = "Change";
            this.ChangeAlgorithmButton.UseVisualStyleBackColor = true;
            this.ChangeAlgorithmButton.Visible = false;
            // 
            // AlgorithmBox
            // 
            this.AlgorithmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmBox.Location = new System.Drawing.Point(87, 452);
            this.AlgorithmBox.Name = "AlgorithmBox";
            this.AlgorithmBox.Size = new System.Drawing.Size(542, 30);
            this.AlgorithmBox.TabIndex = 13;
            this.AlgorithmBox.Visible = false;
            // 
            // AlgLabel
            // 
            this.AlgLabel.AutoSize = true;
            this.AlgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgLabel.Location = new System.Drawing.Point(12, 452);
            this.AlgLabel.Name = "AlgLabel";
            this.AlgLabel.Size = new System.Drawing.Size(48, 29);
            this.AlgLabel.TabIndex = 12;
            this.AlgLabel.Text = "Alg";
            this.AlgLabel.Visible = false;
            // 
            // ConstructPositionButton
            // 
            this.ConstructPositionButton.Location = new System.Drawing.Point(619, 47);
            this.ConstructPositionButton.Name = "ConstructPositionButton";
            this.ConstructPositionButton.Size = new System.Drawing.Size(142, 31);
            this.ConstructPositionButton.TabIndex = 15;
            this.ConstructPositionButton.Text = "Construct position";
            this.ConstructPositionButton.UseVisualStyleBackColor = true;
            this.ConstructPositionButton.Click += new System.EventHandler(this.ConstructPositionButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.ConstructPositionButton);
            this.Controls.Add(this.ChangeAlgorithmButton);
            this.Controls.Add(this.AlgorithmBox);
            this.Controls.Add(this.AlgLabel);
            this.Controls.Add(this.AlgSetSelector);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.AddPositionButton);
            this.Controls.Add(this.DaysLabel);
            this.Controls.Add(this.DaysBox);
            this.Controls.Add(this.SetupPositionButton);
            this.Controls.Add(this.PositionBox);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.SampleCubeView);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SampleCubeView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SampleCubeView;
        private System.Windows.Forms.Button SetupPositionButton;
        private System.Windows.Forms.TextBox PositionBox;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.TextBox DaysBox;
        private System.Windows.Forms.Label DaysLabel;
        private System.Windows.Forms.Button AddPositionButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.ComboBox AlgSetSelector;
        private System.Windows.Forms.Button ChangeAlgorithmButton;
        private System.Windows.Forms.TextBox AlgorithmBox;
        private System.Windows.Forms.Label AlgLabel;
        private System.Windows.Forms.Button ConstructPositionButton;
    }
}

