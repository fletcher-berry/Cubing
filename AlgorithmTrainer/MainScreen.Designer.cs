namespace AlgorithmTrainer
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
            this.RunSequentialButton = new System.Windows.Forms.Button();
            this.SubsetSelector = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ToRangeButton = new System.Windows.Forms.Button();
            this.GroupSelector = new System.Windows.Forms.ListBox();
            this.SubgroupSelector = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ViewSelectedButton = new System.Windows.Forms.Button();
            this.RangeBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CustomSubsetSelector = new System.Windows.Forms.ListBox();
            this.RecentSubsetSelector = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SampleCubeView)).BeginInit();
            this.SuspendLayout();
            // 
            // SampleCubeView
            // 
            this.SampleCubeView.Location = new System.Drawing.Point(142, 52);
            this.SampleCubeView.Name = "SampleCubeView";
            this.SampleCubeView.Size = new System.Drawing.Size(421, 389);
            this.SampleCubeView.TabIndex = 0;
            this.SampleCubeView.TabStop = false;
            this.SampleCubeView.Paint += new System.Windows.Forms.PaintEventHandler(this.SampleCubeView_Paint);
            // 
            // PositionLabel
            // 
            this.PositionLabel.AutoSize = true;
            this.PositionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionLabel.Location = new System.Drawing.Point(19, 530);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(179, 29);
            this.PositionLabel.TabIndex = 1;
            this.PositionLabel.Text = "Set Up Position";
            // 
            // PositionBox
            // 
            this.PositionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionBox.Location = new System.Drawing.Point(204, 530);
            this.PositionBox.Name = "PositionBox";
            this.PositionBox.Size = new System.Drawing.Size(146, 38);
            this.PositionBox.TabIndex = 2;
            // 
            // SetupPositionButton
            // 
            this.SetupPositionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetupPositionButton.Location = new System.Drawing.Point(390, 530);
            this.SetupPositionButton.Name = "SetupPositionButton";
            this.SetupPositionButton.Size = new System.Drawing.Size(100, 40);
            this.SetupPositionButton.TabIndex = 3;
            this.SetupPositionButton.TabStop = false;
            this.SetupPositionButton.Text = "Go!";
            this.SetupPositionButton.UseVisualStyleBackColor = true;
            this.SetupPositionButton.Click += new System.EventHandler(this.SetupPositionButton_Click);
            // 
            // RunRandomButton
            // 
            this.RunRandomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunRandomButton.Location = new System.Drawing.Point(867, 651);
            this.RunRandomButton.Name = "RunRandomButton";
            this.RunRandomButton.Size = new System.Drawing.Size(255, 41);
            this.RunRandomButton.TabIndex = 6;
            this.RunRandomButton.TabStop = false;
            this.RunRandomButton.Text = "Run Random";
            this.RunRandomButton.UseVisualStyleBackColor = true;
            this.RunRandomButton.Click += new System.EventHandler(this.RunRandomButton_Click);
            // 
            // SingleCycleButton
            // 
            this.SingleCycleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SingleCycleButton.Location = new System.Drawing.Point(1143, 651);
            this.SingleCycleButton.Name = "SingleCycleButton";
            this.SingleCycleButton.Size = new System.Drawing.Size(255, 42);
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
            this.AlgLabel.Location = new System.Drawing.Point(20, 473);
            this.AlgLabel.Name = "AlgLabel";
            this.AlgLabel.Size = new System.Drawing.Size(48, 29);
            this.AlgLabel.TabIndex = 8;
            this.AlgLabel.Text = "Alg";
            this.AlgLabel.Visible = false;
            // 
            // AlgorithmBox
            // 
            this.AlgorithmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlgorithmBox.Location = new System.Drawing.Point(93, 473);
            this.AlgorithmBox.Name = "AlgorithmBox";
            this.AlgorithmBox.Size = new System.Drawing.Size(542, 30);
            this.AlgorithmBox.TabIndex = 9;
            this.AlgorithmBox.Visible = false;
            // 
            // ChangeAlgorithmButton
            // 
            this.ChangeAlgorithmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeAlgorithmButton.Location = new System.Drawing.Point(641, 465);
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
            this.AlgSetSelector.Location = new System.Drawing.Point(256, 10);
            this.AlgSetSelector.Name = "AlgSetSelector";
            this.AlgSetSelector.Size = new System.Drawing.Size(234, 46);
            this.AlgSetSelector.TabIndex = 11;
            this.AlgSetSelector.SelectedValueChanged += new System.EventHandler(this.AlgSetSelector_SelectedValueChanged);
            // 
            // AddSubsetButton
            // 
            this.AddSubsetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSubsetButton.Location = new System.Drawing.Point(1073, 506);
            this.AddSubsetButton.Name = "AddSubsetButton";
            this.AddSubsetButton.Size = new System.Drawing.Size(240, 34);
            this.AddSubsetButton.TabIndex = 12;
            this.AddSubsetButton.Text = "Create custom subset";
            this.AddSubsetButton.UseVisualStyleBackColor = true;
            this.AddSubsetButton.Click += new System.EventHandler(this.AddSubsetButton_Click);
            // 
            // ViewSubsetsButton
            // 
            this.ViewSubsetsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewSubsetsButton.Location = new System.Drawing.Point(1256, 298);
            this.ViewSubsetsButton.Name = "ViewSubsetsButton";
            this.ViewSubsetsButton.Size = new System.Drawing.Size(202, 34);
            this.ViewSubsetsButton.TabIndex = 13;
            this.ViewSubsetsButton.Text = "View custom Subsets";
            this.ViewSubsetsButton.UseVisualStyleBackColor = true;
            this.ViewSubsetsButton.Click += new System.EventHandler(this.ViewSubsetsButton_Click);
            // 
            // ConstructPostionButton
            // 
            this.ConstructPostionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConstructPostionButton.Location = new System.Drawing.Point(24, 604);
            this.ConstructPostionButton.Name = "ConstructPostionButton";
            this.ConstructPostionButton.Size = new System.Drawing.Size(208, 40);
            this.ConstructPostionButton.TabIndex = 14;
            this.ConstructPostionButton.Text = "Construct Position";
            this.ConstructPostionButton.UseVisualStyleBackColor = true;
            this.ConstructPostionButton.Click += new System.EventHandler(this.ConstructPostionButton_Click);
            // 
            // RunFixedButton
            // 
            this.RunFixedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunFixedButton.Location = new System.Drawing.Point(867, 698);
            this.RunFixedButton.Name = "RunFixedButton";
            this.RunFixedButton.Size = new System.Drawing.Size(174, 46);
            this.RunFixedButton.TabIndex = 15;
            this.RunFixedButton.TabStop = false;
            this.RunFixedButton.Text = "Run Fixed";
            this.RunFixedButton.UseVisualStyleBackColor = true;
            this.RunFixedButton.Click += new System.EventHandler(this.RunFixedButton_Click);
            // 
            // RunFixedBox
            // 
            this.RunFixedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunFixedBox.Location = new System.Drawing.Point(1047, 698);
            this.RunFixedBox.Name = "RunFixedBox";
            this.RunFixedBox.Size = new System.Drawing.Size(75, 45);
            this.RunFixedBox.TabIndex = 16;
            // 
            // RunSequentialButton
            // 
            this.RunSequentialButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunSequentialButton.Location = new System.Drawing.Point(1143, 701);
            this.RunSequentialButton.Name = "RunSequentialButton";
            this.RunSequentialButton.Size = new System.Drawing.Size(255, 43);
            this.RunSequentialButton.TabIndex = 19;
            this.RunSequentialButton.Text = "Run Sequential";
            this.RunSequentialButton.UseVisualStyleBackColor = true;
            this.RunSequentialButton.Click += new System.EventHandler(this.RunSequentialButton_Click);
            // 
            // SubsetSelector
            // 
            this.SubsetSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubsetSelector.FormattingEnabled = true;
            this.SubsetSelector.ItemHeight = 22;
            this.SubsetSelector.Location = new System.Drawing.Point(1066, 93);
            this.SubsetSelector.Name = "SubsetSelector";
            this.SubsetSelector.Size = new System.Drawing.Size(173, 202);
            this.SubsetSelector.TabIndex = 20;
            this.SubsetSelector.SelectedValueChanged += new System.EventHandler(this.SubsetSelector_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(711, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 29);
            this.label1.TabIndex = 21;
            this.label1.Text = "Group:";
            // 
            // ToRangeButton
            // 
            this.ToRangeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToRangeButton.Location = new System.Drawing.Point(1186, 394);
            this.ToRangeButton.Name = "ToRangeButton";
            this.ToRangeButton.Size = new System.Drawing.Size(168, 34);
            this.ToRangeButton.TabIndex = 22;
            this.ToRangeButton.Text = "Add to input";
            this.ToRangeButton.UseVisualStyleBackColor = true;
            this.ToRangeButton.Click += new System.EventHandler(this.ToRangeButton_Click);
            // 
            // GroupSelector
            // 
            this.GroupSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupSelector.FormattingEnabled = true;
            this.GroupSelector.ItemHeight = 22;
            this.GroupSelector.Location = new System.Drawing.Point(685, 93);
            this.GroupSelector.Name = "GroupSelector";
            this.GroupSelector.Size = new System.Drawing.Size(173, 202);
            this.GroupSelector.TabIndex = 23;
            this.GroupSelector.SelectedValueChanged += new System.EventHandler(this.GroupSelector_SelectedValueChanged);
            // 
            // SubgroupSelector
            // 
            this.SubgroupSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubgroupSelector.FormattingEnabled = true;
            this.SubgroupSelector.ItemHeight = 22;
            this.SubgroupSelector.Location = new System.Drawing.Point(878, 93);
            this.SubgroupSelector.Name = "SubgroupSelector";
            this.SubgroupSelector.Size = new System.Drawing.Size(173, 202);
            this.SubgroupSelector.TabIndex = 25;
            this.SubgroupSelector.SelectedValueChanged += new System.EventHandler(this.SubgroupSelector_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(891, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 29);
            this.label2.TabIndex = 24;
            this.label2.Text = "Subgroup:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1089, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 29);
            this.label3.TabIndex = 26;
            this.label3.Text = "Subset:";
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.Location = new System.Drawing.Point(868, 506);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(96, 34);
            this.ClearButton.TabIndex = 27;
            this.ClearButton.Text = "clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ViewSelectedButton
            // 
            this.ViewSelectedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewSelectedButton.Location = new System.Drawing.Point(970, 506);
            this.ViewSelectedButton.Name = "ViewSelectedButton";
            this.ViewSelectedButton.Size = new System.Drawing.Size(97, 34);
            this.ViewSelectedButton.TabIndex = 29;
            this.ViewSelectedButton.TabStop = false;
            this.ViewSelectedButton.Text = "View";
            this.ViewSelectedButton.UseVisualStyleBackColor = true;
            this.ViewSelectedButton.Click += new System.EventHandler(this.ViewSelectedButton_Click);
            // 
            // RangeBox
            // 
            this.RangeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeBox.Location = new System.Drawing.Point(868, 546);
            this.RangeBox.Name = "RangeBox";
            this.RangeBox.Size = new System.Drawing.Size(574, 98);
            this.RangeBox.TabIndex = 30;
            this.RangeBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(796, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 29);
            this.label4.TabIndex = 31;
            this.label4.Text = "Algs:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1264, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 29);
            this.label5.TabIndex = 33;
            this.label5.Text = "Custom Subsets:";
            // 
            // CustomSubsetSelector
            // 
            this.CustomSubsetSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomSubsetSelector.FormattingEnabled = true;
            this.CustomSubsetSelector.ItemHeight = 22;
            this.CustomSubsetSelector.Location = new System.Drawing.Point(1269, 93);
            this.CustomSubsetSelector.Name = "CustomSubsetSelector";
            this.CustomSubsetSelector.Size = new System.Drawing.Size(173, 202);
            this.CustomSubsetSelector.TabIndex = 32;
            this.CustomSubsetSelector.SelectedValueChanged += new System.EventHandler(this.CustomSubsetSelector_SelectedValueChanged);
            // 
            // RecentSubsetSelector
            // 
            this.RecentSubsetSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecentSubsetSelector.FormattingEnabled = true;
            this.RecentSubsetSelector.ItemHeight = 22;
            this.RecentSubsetSelector.Location = new System.Drawing.Point(789, 332);
            this.RecentSubsetSelector.Name = "RecentSubsetSelector";
            this.RecentSubsetSelector.Size = new System.Drawing.Size(364, 158);
            this.RecentSubsetSelector.TabIndex = 35;
            this.RecentSubsetSelector.SelectedValueChanged += new System.EventHandler(this.RecentSubsetSelector_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(784, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 29);
            this.label6.TabIndex = 34;
            this.label6.Text = "Recent:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(776, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(439, 29);
            this.label7.TabIndex = 36;
            this.label7.Text = "Select a subset, add it to input, and Run!";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 753);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RecentSubsetSelector);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CustomSubsetSelector);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RangeBox);
            this.Controls.Add(this.ViewSelectedButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SubgroupSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GroupSelector);
            this.Controls.Add(this.ToRangeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SubsetSelector);
            this.Controls.Add(this.RunSequentialButton);
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
            this.Controls.Add(this.SetupPositionButton);
            this.Controls.Add(this.PositionBox);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.SampleCubeView);
            this.Location = new System.Drawing.Point(150, 100);
            this.Name = "MainScreen";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SampleCubeView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SampleCubeView;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.TextBox PositionBox;
        private System.Windows.Forms.Button SetupPositionButton;
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
        private System.Windows.Forms.Button RunSequentialButton;
        private System.Windows.Forms.ListBox SubsetSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ToRangeButton;
        private System.Windows.Forms.ListBox GroupSelector;
        private System.Windows.Forms.ListBox SubgroupSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ViewSelectedButton;
        private System.Windows.Forms.RichTextBox RangeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox CustomSubsetSelector;
        private System.Windows.Forms.ListBox RecentSubsetSelector;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

