
namespace TRSecretTester
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dataFolderTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.levelComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.laraEntityPosRadioButton = new System.Windows.Forms.RadioButton();
            this.laraCustomPosRadioButton = new System.Windows.Forms.RadioButton();
            this.xyzLabel = new System.Windows.Forms.Label();
            this.laraPosTextBox = new System.Windows.Forms.TextBox();
            this.roomLabel = new System.Windows.Forms.Label();
            this.laraRoomSpinner = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.doneLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.entityPosSpinner = new System.Windows.Forms.NumericUpDown();
            this.laraDefaultPosButton = new System.Windows.Forms.RadioButton();
            this.limitEntitiesCheck = new System.Windows.Forms.CheckBox();
            this.maxEntitiesSpinner = new System.Windows.Forms.NumericUpDown();
            this.keyItemCheck = new System.Windows.Forms.CheckBox();
            this.openDoorsCheck = new System.Windows.Forms.CheckBox();
            this.puzzlesCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.laraRoomSpinner)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entityPosSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxEntitiesSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Folder";
            // 
            // dataFolderTextBox
            // 
            this.dataFolderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataFolderTextBox.Location = new System.Drawing.Point(80, 12);
            this.dataFolderTextBox.Name = "dataFolderTextBox";
            this.dataFolderTextBox.Size = new System.Drawing.Size(369, 20);
            this.dataFolderTextBox.TabIndex = 0;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(460, 11);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "&Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Level";
            // 
            // levelComboBox
            // 
            this.levelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelComboBox.FormattingEnabled = true;
            this.levelComboBox.Location = new System.Drawing.Point(80, 43);
            this.levelComboBox.Name = "levelComboBox";
            this.levelComboBox.Size = new System.Drawing.Size(202, 21);
            this.levelComboBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Lara";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Options";
            // 
            // laraEntityPosRadioButton
            // 
            this.laraEntityPosRadioButton.AutoSize = true;
            this.laraEntityPosRadioButton.Location = new System.Drawing.Point(0, 28);
            this.laraEntityPosRadioButton.Name = "laraEntityPosRadioButton";
            this.laraEntityPosRadioButton.Size = new System.Drawing.Size(136, 17);
            this.laraEntityPosRadioButton.TabIndex = 1;
            this.laraEntityPosRadioButton.Text = "Same position as entity ";
            this.laraEntityPosRadioButton.UseVisualStyleBackColor = true;
            this.laraEntityPosRadioButton.CheckedChanged += new System.EventHandler(this.LaraRadioButton_CheckedChanged);
            // 
            // laraCustomPosRadioButton
            // 
            this.laraCustomPosRadioButton.AutoSize = true;
            this.laraCustomPosRadioButton.Location = new System.Drawing.Point(0, 52);
            this.laraCustomPosRadioButton.Name = "laraCustomPosRadioButton";
            this.laraCustomPosRadioButton.Size = new System.Drawing.Size(92, 17);
            this.laraCustomPosRadioButton.TabIndex = 3;
            this.laraCustomPosRadioButton.Text = "Set position to";
            this.laraCustomPosRadioButton.UseVisualStyleBackColor = true;
            this.laraCustomPosRadioButton.CheckedChanged += new System.EventHandler(this.LaraRadioButton_CheckedChanged);
            // 
            // xyzLabel
            // 
            this.xyzLabel.AutoSize = true;
            this.xyzLabel.Enabled = false;
            this.xyzLabel.Location = new System.Drawing.Point(21, 77);
            this.xyzLabel.Name = "xyzLabel";
            this.xyzLabel.Size = new System.Drawing.Size(40, 13);
            this.xyzLabel.TabIndex = 16;
            this.xyzLabel.Text = "X, Y, Z";
            // 
            // laraPosTextBox
            // 
            this.laraPosTextBox.Enabled = false;
            this.laraPosTextBox.Location = new System.Drawing.Point(83, 73);
            this.laraPosTextBox.Name = "laraPosTextBox";
            this.laraPosTextBox.Size = new System.Drawing.Size(195, 20);
            this.laraPosTextBox.TabIndex = 4;
            // 
            // roomLabel
            // 
            this.roomLabel.AutoSize = true;
            this.roomLabel.Enabled = false;
            this.roomLabel.Location = new System.Drawing.Point(21, 99);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(35, 13);
            this.roomLabel.TabIndex = 18;
            this.roomLabel.Text = "Room";
            // 
            // laraRoomSpinner
            // 
            this.laraRoomSpinner.Enabled = false;
            this.laraRoomSpinner.Location = new System.Drawing.Point(83, 97);
            this.laraRoomSpinner.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.laraRoomSpinner.Name = "laraRoomSpinner";
            this.laraRoomSpinner.Size = new System.Drawing.Size(90, 20);
            this.laraRoomSpinner.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(460, 253);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 21);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // doneLabel
            // 
            this.doneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.doneLabel.AutoSize = true;
            this.doneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneLabel.ForeColor = System.Drawing.Color.Green;
            this.doneLabel.Location = new System.Drawing.Point(475, 230);
            this.doneLabel.Name = "doneLabel";
            this.doneLabel.Size = new System.Drawing.Size(41, 13);
            this.doneLabel.TabIndex = 21;
            this.doneLabel.Text = "Done!";
            this.doneLabel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.entityPosSpinner);
            this.panel1.Controls.Add(this.laraDefaultPosButton);
            this.panel1.Controls.Add(this.laraEntityPosRadioButton);
            this.panel1.Controls.Add(this.laraCustomPosRadioButton);
            this.panel1.Controls.Add(this.xyzLabel);
            this.panel1.Controls.Add(this.laraRoomSpinner);
            this.panel1.Controls.Add(this.laraPosTextBox);
            this.panel1.Controls.Add(this.roomLabel);
            this.panel1.Location = new System.Drawing.Point(80, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 119);
            this.panel1.TabIndex = 22;
            // 
            // entityPosSpinner
            // 
            this.entityPosSpinner.Enabled = false;
            this.entityPosSpinner.Location = new System.Drawing.Point(132, 28);
            this.entityPosSpinner.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.entityPosSpinner.Name = "entityPosSpinner";
            this.entityPosSpinner.Size = new System.Drawing.Size(65, 20);
            this.entityPosSpinner.TabIndex = 2;
            // 
            // laraDefaultPosButton
            // 
            this.laraDefaultPosButton.AutoSize = true;
            this.laraDefaultPosButton.Checked = true;
            this.laraDefaultPosButton.Location = new System.Drawing.Point(0, 4);
            this.laraDefaultPosButton.Name = "laraDefaultPosButton";
            this.laraDefaultPosButton.Size = new System.Drawing.Size(98, 17);
            this.laraDefaultPosButton.TabIndex = 0;
            this.laraDefaultPosButton.TabStop = true;
            this.laraDefaultPosButton.Text = "Default position";
            this.laraDefaultPosButton.UseVisualStyleBackColor = true;
            this.laraDefaultPosButton.CheckedChanged += new System.EventHandler(this.LaraRadioButton_CheckedChanged);
            // 
            // limitEntitiesCheck
            // 
            this.limitEntitiesCheck.AutoSize = true;
            this.limitEntitiesCheck.Checked = true;
            this.limitEntitiesCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.limitEntitiesCheck.Location = new System.Drawing.Point(80, 75);
            this.limitEntitiesCheck.Name = "limitEntitiesCheck";
            this.limitEntitiesCheck.Size = new System.Drawing.Size(135, 17);
            this.limitEntitiesCheck.TabIndex = 3;
            this.limitEntitiesCheck.Text = "Ensure entity count <= ";
            this.limitEntitiesCheck.UseVisualStyleBackColor = true;
            this.limitEntitiesCheck.CheckedChanged += new System.EventHandler(this.LimitEntitiesCheck_CheckedChanged);
            // 
            // maxEntitiesSpinner
            // 
            this.maxEntitiesSpinner.Location = new System.Drawing.Point(217, 75);
            this.maxEntitiesSpinner.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxEntitiesSpinner.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxEntitiesSpinner.Name = "maxEntitiesSpinner";
            this.maxEntitiesSpinner.Size = new System.Drawing.Size(65, 20);
            this.maxEntitiesSpinner.TabIndex = 4;
            this.maxEntitiesSpinner.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // keyItemCheck
            // 
            this.keyItemCheck.AutoSize = true;
            this.keyItemCheck.Location = new System.Drawing.Point(80, 99);
            this.keyItemCheck.Name = "keyItemCheck";
            this.keyItemCheck.Size = new System.Drawing.Size(136, 17);
            this.keyItemCheck.TabIndex = 5;
            this.keyItemCheck.Text = "Move key items to Lara";
            this.keyItemCheck.UseVisualStyleBackColor = true;
            // 
            // openDoorsCheck
            // 
            this.openDoorsCheck.AutoSize = true;
            this.openDoorsCheck.Location = new System.Drawing.Point(80, 123);
            this.openDoorsCheck.Name = "openDoorsCheck";
            this.openDoorsCheck.Size = new System.Drawing.Size(94, 17);
            this.openDoorsCheck.TabIndex = 6;
            this.openDoorsCheck.Text = "Open all doors";
            this.openDoorsCheck.UseVisualStyleBackColor = true;
            // 
            // puzzlesCheck
            // 
            this.puzzlesCheck.AutoSize = true;
            this.puzzlesCheck.Location = new System.Drawing.Point(217, 99);
            this.puzzlesCheck.Name = "puzzlesCheck";
            this.puzzlesCheck.Size = new System.Drawing.Size(149, 17);
            this.puzzlesCheck.TabIndex = 23;
            this.puzzlesCheck.Text = "Move puzzle items to Lara";
            this.puzzlesCheck.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(547, 287);
            this.Controls.Add(this.puzzlesCheck);
            this.Controls.Add(this.openDoorsCheck);
            this.Controls.Add(this.keyItemCheck);
            this.Controls.Add(this.maxEntitiesSpinner);
            this.Controls.Add(this.limitEntitiesCheck);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.doneLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.levelComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.dataFolderTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TR Secret Tester";
            ((System.ComponentModel.ISupportInitialize)(this.laraRoomSpinner)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entityPosSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxEntitiesSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dataFolderTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox levelComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton laraEntityPosRadioButton;
        private System.Windows.Forms.RadioButton laraCustomPosRadioButton;
        private System.Windows.Forms.Label xyzLabel;
        private System.Windows.Forms.TextBox laraPosTextBox;
        private System.Windows.Forms.Label roomLabel;
        private System.Windows.Forms.NumericUpDown laraRoomSpinner;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label doneLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton laraDefaultPosButton;
        private System.Windows.Forms.NumericUpDown entityPosSpinner;
        private System.Windows.Forms.CheckBox limitEntitiesCheck;
        private System.Windows.Forms.NumericUpDown maxEntitiesSpinner;
        private System.Windows.Forms.CheckBox keyItemCheck;
        private System.Windows.Forms.CheckBox openDoorsCheck;
        private System.Windows.Forms.CheckBox puzzlesCheck;
    }
}

