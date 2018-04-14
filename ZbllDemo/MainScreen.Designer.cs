namespace ZbllDemo
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
            this.PositionLabel = new System.Windows.Forms.Label();
            this.PositionBox = new System.Windows.Forms.TextBox();
            this.SetupPositionButton = new System.Windows.Forms.Button();
            this.RunLabel = new System.Windows.Forms.Label();
            this.RangeBox = new System.Windows.Forms.TextBox();
            this.RunRandomButton = new System.Windows.Forms.Button();
            this.SingleCycleButton = new System.Windows.Forms.Button();
            this.AlgLabel = new System.Windows.Forms.Label();
            this.AlgorithmBox = new System.Windows.Forms.TextBox();
            this.ChangeAlgorithmButton = new System.Windows.Forms.Button();
            this.AlgSetSelector = new System.Windows.Forms.ComboBox();
            this.AddSubsetButton = new System.Windows.Forms.Button();
            this.ViewSubsetsButton = new System.Windows.Forms.Button();
            this.ConstructPostionButton = new System.Windows.Forms.Button();
            this.RunFixedButton = new System.Windows.Forms.Button();
            this.RunFixedBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SampleCubeView)).BeginInit();
            this.SuspendLayout();
            // 
            // SampleCubeView
            // 
            this.SampleCubeView.Location = new System.Drawing.Point(142, 10);
            this.SampleCubeView.Name = "SampleCubeView";
            this.SampleCubeView.Size = new System.Drawing.Size(421, 389);
            this.SampleCubeView.TabIndex = 0;
            this.SampleCubeView.TabStop = false;
            this.SampleCubeView.Paint += new System.Windows.Forms.PaintEventHandler(this.SampleCubeView_Paint);
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionLabel.Location = new System.Drawing.Point(53, 523);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(252, 39);
            this.PositionLabel.TabIndex = 1;
            this.PositionLabel.Text = "Set Up Position";
            // 
            // PositionBox
            // 
            this.PositionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionBox.Location = new System.Drawing.Point(60, 586);
            this.PositionBox.Name = "PositionBox";
            this.PositionBox.Size = new System.Drawing.Size(237, 45);
            this.PositionBox.TabIndex = 2;
            // 
            // SetupPositionButton
            // 
            this.SetupPositionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetupPositionButton.Location = new System.Drawing.Point(63, 644);
            this.SetupPositionButton.Name = "SetupPositionButton";
            this.SetupPositionButton.Size = new System.Drawing.Size(212, 67);
            this.SetupPositionButton.TabIndex = 3;
            this.SetupPositionButton.TabStop = false;
            this.SetupPositionButton.Text = "Go!";
            this.SetupPositionButton.UseVisualStyleBackColor = true;
            this.SetupPositionButton.Click += new System.EventHandler(this.SetupPositionButton_Click);
            // 
            // RunLabel
            // 
            this.RunLabel.AutoSize = true;
            this.RunLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunLabel.Location = new System.Drawing.Point(380, 465);
            this.RunLabel.Name = "RunLabel";
            this.RunLabel.Size = new System.Drawing.Size(339, 39);
            this.RunLabel.TabIndex = 4;
            this.RunLabel.Text = "Enter Position Range";
            // 
            // RangeBox
            // 
            this.RangeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeBox.Location = new System.Drawing.Point(387, 523);
            this.RangeBox.Name = "RangeBox";
            this.RangeBox.Size = new System.Drawing.Size(332, 36);
            this.RangeBox.TabIndex = 5;
            // 
            // RunRandomButton
            // 
            this.RunRandomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunRandomButton.Location = new System.Drawing.Point(387, 569);
            this.RunRandomButton.Name = "RunRandomButton";
            this.RunRandomButton.Size = new System.Drawing.Size(332, 53);
            this.RunRandomButton.TabIndex = 6;
            this.RunRandomButton.TabStop = false;
            this.RunRandomButton.Text = "Run Random";
            this.RunRandomButton.UseVisualStyleBackColor = true;
            this.RunRandomButton.Click += new System.EventHandler(this.RunRandomButton_Click);
            // 
            // SingleCycleButton
            // 
            this.SingleCycleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingleCycleButton.Location = new System.Drawing.Point(387, 628);
            this.SingleCycleButton.Name = "SingleCycleButton";
            this.SingleCycleButton.Size = new System.Drawing.Size(332, 54);
            this.SingleCycleButton.TabIndex = 7;
            this.SingleCycleButton.TabStop = false;
            this.SingleCycleButton.Text = "Run Single Cycle";
            this.SingleCycleButton.UseVisualStyleBackColor = true;
            this.SingleCycleButton.Click += new System.EventHandler(this.SingleCycleButton_Click);
            // 
            // AlgLabel
            // 
            this.AlgLabel.AutoSize = true;
            this.AlgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgLabel.Location = new System.Drawing.Point(23, 405);
            this.AlgLabel.Name = "AlgLabel";
            this.AlgLabel.Size = new System.Drawing.Size(48, 29);
            this.AlgLabel.TabIndex = 8;
            this.AlgLabel.Text = "Alg";
            this.AlgLabel.Visible = false;
            // 
            // AlgorithmBox
            // 
            this.AlgorithmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmBox.Location = new System.Drawing.Point(96, 405);
            this.AlgorithmBox.Name = "AlgorithmBox";
            this.AlgorithmBox.Size = new System.Drawing.Size(542, 30);
            this.AlgorithmBox.TabIndex = 9;
            this.AlgorithmBox.Visible = false;
            // 
            // ChangeAlgorithmButton
            // 
            this.ChangeAlgorithmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeAlgorithmButton.Location = new System.Drawing.Point(644, 397);
            this.ChangeAlgorithmButton.Name = "ChangeAlgorithmButton";
            this.ChangeAlgorithmButton.Size = new System.Drawing.Size(126, 45);
            this.ChangeAlgorithmButton.TabIndex = 10;
            this.ChangeAlgorithmButton.TabStop = false;
            this.ChangeAlgorithmButton.Text = "Change";
            this.ChangeAlgorithmButton.UseVisualStyleBackColor = true;
            this.ChangeAlgorithmButton.Visible = false;
            this.ChangeAlgorithmButton.Click += new System.EventHandler(this.ChangeAlgorithmButton_Click);
            // 
            // AlgSetSelector
            // 
            this.AlgSetSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgSetSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgSetSelector.FormattingEnabled = true;
            this.AlgSetSelector.Location = new System.Drawing.Point(63, 465);
            this.AlgSetSelector.Name = "AlgSetSelector";
            this.AlgSetSelector.Size = new System.Drawing.Size(234, 46);
            this.AlgSetSelector.TabIndex = 11;
            this.AlgSetSelector.SelectedValueChanged += new System.EventHandler(this.AlgSetSelector_SelectedValueChanged);
            this.AlgSetSelector.TextChanged += new System.EventHandler(this.AlgSetSelector_TextChanged);
            // 
            // AddSubsetButton
            // 
            this.AddSubsetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSubsetButton.Location = new System.Drawing.Point(583, 29);
            this.AddSubsetButton.Name = "AddSubsetButton";
            this.AddSubsetButton.Size = new System.Drawing.Size(187, 34);
            this.AddSubsetButton.TabIndex = 12;
            this.AddSubsetButton.Text = "Add Subset";
            this.AddSubsetButton.UseVisualStyleBackColor = true;
            this.AddSubsetButton.Click += new System.EventHandler(this.AddSubsetButton_Click);
            // 
            // ViewSubsetsButton
            // 
            this.ViewSubsetsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewSubsetsButton.Location = new System.Drawing.Point(583, 86);
            this.ViewSubsetsButton.Name = "ViewSubsetsButton";
            this.ViewSubsetsButton.Size = new System.Drawing.Size(187, 34);
            this.ViewSubsetsButton.TabIndex = 13;
            this.ViewSubsetsButton.Text = "View Subests";
            this.ViewSubsetsButton.UseVisualStyleBackColor = true;
            this.ViewSubsetsButton.Click += new System.EventHandler(this.ViewSubsetsButton_Click);
            // 
            // ConstructPostionButton
            // 
            this.ConstructPostionButton.Location = new System.Drawing.Point(13, 24);
            this.ConstructPostionButton.Name = "ConstructPostionButton";
            this.ConstructPostionButton.Size = new System.Drawing.Size(123, 58);
            this.ConstructPostionButton.TabIndex = 14;
            this.ConstructPostionButton.Text = "Construct Position";
            this.ConstructPostionButton.UseVisualStyleBackColor = true;
            this.ConstructPostionButton.Click += new System.EventHandler(this.ConstructPostionButton_Click);
            // 
            // RunFixedButton
            // 
            this.RunFixedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunFixedButton.Location = new System.Drawing.Point(387, 688);
            this.RunFixedButton.Name = "RunFixedButton";
            this.RunFixedButton.Size = new System.Drawing.Size(251, 53);
            this.RunFixedButton.TabIndex = 15;
            this.RunFixedButton.TabStop = false;
            this.RunFixedButton.Text = "Run Fixed";
            this.RunFixedButton.UseVisualStyleBackColor = true;
            this.RunFixedButton.Click += new System.EventHandler(this.RunFixedButton_Click);
            // 
            // RunFixedBox
            // 
            this.RunFixedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunFixedBox.Location = new System.Drawing.Point(644, 692);
            this.RunFixedBox.Name = "RunFixedBox";
            this.RunFixedBox.Size = new System.Drawing.Size(75, 45);
            this.RunFixedBox.TabIndex = 16;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.RunFixedBox);
            this.Controls.Add(this.RunFixedButton);
            this.Controls.Add(this.ConstructPostionButton);
            this.Controls.Add(this.ViewSubsetsButton);
            this.Controls.Add(this.AddSubsetButton);
            this.Controls.Add(this.AlgSetSelector);
            this.Controls.Add(this.ChangeAlgorithmButton);
            this.Controls.Add(this.AlgorithmBox);
            this.Controls.Add(this.AlgLabel);
            this.Controls.Add(this.SingleCycleButton);
            this.Controls.Add(this.RunRandomButton);
            this.Controls.Add(this.RangeBox);
            this.Controls.Add(this.RunLabel);
            this.Controls.Add(this.SetupPositionButton);
            this.Controls.Add(this.PositionBox);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.SampleCubeView);
            this.Location = new System.Drawing.Point(150, 100);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SampleCubeView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SampleCubeView;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.TextBox PositionBox;
        private System.Windows.Forms.Button SetupPositionButton;
        private System.Windows.Forms.Label RunLabel;
        private System.Windows.Forms.TextBox RangeBox;
        private System.Windows.Forms.Button RunRandomButton;
        private System.Windows.Forms.Button SingleCycleButton;
        private System.Windows.Forms.Label AlgLabel;
        private System.Windows.Forms.TextBox AlgorithmBox;
        private System.Windows.Forms.Button ChangeAlgorithmButton;
        private System.Windows.Forms.ComboBox AlgSetSelector;
        private System.Windows.Forms.Button AddSubsetButton;
        private System.Windows.Forms.Button ViewSubsetsButton;
        private System.Windows.Forms.Button ConstructPostionButton;
        private System.Windows.Forms.Button RunFixedButton;
        private System.Windows.Forms.TextBox RunFixedBox;
    }
}

