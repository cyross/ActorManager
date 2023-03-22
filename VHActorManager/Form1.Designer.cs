namespace VHActorManager
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
            this.QuitButton = new System.Windows.Forms.Button();
            this.ServerStartButton = new System.Windows.Forms.Button();
            this.ServerStopButton = new System.Windows.Forms.Button();
            this.VSYAMLEnableCheck = new System.Windows.Forms.CheckBox();
            this.VSYAMLFilePathBox = new System.Windows.Forms.TextBox();
            this.VSYAMLFilePathButton = new System.Windows.Forms.Button();
            this.PortLabel = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.MasterYAMLPathButton = new System.Windows.Forms.Button();
            this.MasterYAMLPathBox = new System.Windows.Forms.TextBox();
            this.MasterYAMLPathLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveUserYAMLButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.Crimson;
            this.QuitButton.FlatAppearance.BorderSize = 0;
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QuitButton.ForeColor = System.Drawing.Color.White;
            this.QuitButton.Location = new System.Drawing.Point(742, 176);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(46, 28);
            this.QuitButton.TabIndex = 0;
            this.QuitButton.Text = "終了";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // ServerStartButton
            // 
            this.ServerStartButton.BackColor = System.Drawing.Color.DarkGreen;
            this.ServerStartButton.FlatAppearance.BorderSize = 0;
            this.ServerStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerStartButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ServerStartButton.ForeColor = System.Drawing.Color.White;
            this.ServerStartButton.Location = new System.Drawing.Point(281, 176);
            this.ServerStartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ServerStartButton.Name = "ServerStartButton";
            this.ServerStartButton.Size = new System.Drawing.Size(98, 28);
            this.ServerStartButton.TabIndex = 1;
            this.ServerStartButton.Text = "サーバー起動";
            this.ServerStartButton.UseVisualStyleBackColor = false;
            // 
            // ServerStopButton
            // 
            this.ServerStopButton.BackColor = System.Drawing.Color.Gold;
            this.ServerStopButton.FlatAppearance.BorderSize = 0;
            this.ServerStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerStopButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ServerStopButton.ForeColor = System.Drawing.Color.Black;
            this.ServerStopButton.Location = new System.Drawing.Point(385, 176);
            this.ServerStopButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ServerStopButton.Name = "ServerStopButton";
            this.ServerStopButton.Size = new System.Drawing.Size(98, 28);
            this.ServerStopButton.TabIndex = 2;
            this.ServerStopButton.Text = "サーバー停止";
            this.ServerStopButton.UseVisualStyleBackColor = false;
            // 
            // VSYAMLEnableCheck
            // 
            this.VSYAMLEnableCheck.AutoSize = true;
            this.VSYAMLEnableCheck.BackColor = System.Drawing.Color.Transparent;
            this.VSYAMLEnableCheck.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VSYAMLEnableCheck.Location = new System.Drawing.Point(6, 25);
            this.VSYAMLEnableCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VSYAMLEnableCheck.Name = "VSYAMLEnableCheck";
            this.VSYAMLEnableCheck.Size = new System.Drawing.Size(51, 22);
            this.VSYAMLEnableCheck.TabIndex = 3;
            this.VSYAMLEnableCheck.Text = "反映";
            this.VSYAMLEnableCheck.UseVisualStyleBackColor = false;
            // 
            // VSYAMLFilePathBox
            // 
            this.VSYAMLFilePathBox.BackColor = System.Drawing.Color.Azure;
            this.VSYAMLFilePathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VSYAMLFilePathBox.Location = new System.Drawing.Point(6, 54);
            this.VSYAMLFilePathBox.Name = "VSYAMLFilePathBox";
            this.VSYAMLFilePathBox.Size = new System.Drawing.Size(731, 18);
            this.VSYAMLFilePathBox.TabIndex = 5;
            // 
            // VSYAMLFilePathButton
            // 
            this.VSYAMLFilePathButton.BackColor = System.Drawing.Color.White;
            this.VSYAMLFilePathButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.VSYAMLFilePathButton.FlatAppearance.BorderSize = 2;
            this.VSYAMLFilePathButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.VSYAMLFilePathButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.VSYAMLFilePathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VSYAMLFilePathButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VSYAMLFilePathButton.ForeColor = System.Drawing.Color.Black;
            this.VSYAMLFilePathButton.Location = new System.Drawing.Point(743, 49);
            this.VSYAMLFilePathButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VSYAMLFilePathButton.Name = "VSYAMLFilePathButton";
            this.VSYAMLFilePathButton.Size = new System.Drawing.Size(37, 28);
            this.VSYAMLFilePathButton.TabIndex = 6;
            this.VSYAMLFilePathButton.Text = "...";
            this.VSYAMLFilePathButton.UseVisualStyleBackColor = false;
            this.VSYAMLFilePathButton.Click += new System.EventHandler(this.VSYAMLFilePathButton_Click);
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(2, 60);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(102, 18);
            this.PortLabel.TabIndex = 7;
            this.PortLabel.Text = "[必須]ポート番号";
            // 
            // PortBox
            // 
            this.PortBox.BackColor = System.Drawing.Color.Azure;
            this.PortBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PortBox.Location = new System.Drawing.Point(110, 60);
            this.PortBox.MaxLength = 6;
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(51, 18);
            this.PortBox.TabIndex = 8;
            this.PortBox.Text = "3000";
            this.PortBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MasterYAMLPathButton
            // 
            this.MasterYAMLPathButton.BackColor = System.Drawing.Color.White;
            this.MasterYAMLPathButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.MasterYAMLPathButton.FlatAppearance.BorderSize = 2;
            this.MasterYAMLPathButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.MasterYAMLPathButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MasterYAMLPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MasterYAMLPathButton.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MasterYAMLPathButton.ForeColor = System.Drawing.Color.Black;
            this.MasterYAMLPathButton.Location = new System.Drawing.Point(751, 25);
            this.MasterYAMLPathButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MasterYAMLPathButton.Name = "MasterYAMLPathButton";
            this.MasterYAMLPathButton.Size = new System.Drawing.Size(37, 28);
            this.MasterYAMLPathButton.TabIndex = 11;
            this.MasterYAMLPathButton.Text = "...";
            this.MasterYAMLPathButton.UseVisualStyleBackColor = false;
            this.MasterYAMLPathButton.Click += new System.EventHandler(this.MasterYAMLPathButton_Click);
            // 
            // MasterYAMLPathBox
            // 
            this.MasterYAMLPathBox.BackColor = System.Drawing.Color.Azure;
            this.MasterYAMLPathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MasterYAMLPathBox.Location = new System.Drawing.Point(2, 30);
            this.MasterYAMLPathBox.Name = "MasterYAMLPathBox";
            this.MasterYAMLPathBox.Size = new System.Drawing.Size(743, 18);
            this.MasterYAMLPathBox.TabIndex = 10;
            // 
            // MasterYAMLPathLabel
            // 
            this.MasterYAMLPathLabel.AutoSize = true;
            this.MasterYAMLPathLabel.Location = new System.Drawing.Point(2, 9);
            this.MasterYAMLPathLabel.Name = "MasterYAMLPathLabel";
            this.MasterYAMLPathLabel.Size = new System.Drawing.Size(207, 18);
            this.MasterYAMLPathLabel.TabIndex = 9;
            this.MasterYAMLPathLabel.Text = "[必須]マスターYAMLファイルのパス";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VSYAMLEnableCheck);
            this.groupBox1.Controls.Add(this.VSYAMLFilePathBox);
            this.groupBox1.Controls.Add(this.VSYAMLFilePathButton);
            this.groupBox1.Location = new System.Drawing.Point(2, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 85);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VEGASスクリプトのYAMLファイル";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // SaveUserYAMLButton
            // 
            this.SaveUserYAMLButton.BackColor = System.Drawing.Color.DarkCyan;
            this.SaveUserYAMLButton.FlatAppearance.BorderSize = 0;
            this.SaveUserYAMLButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveUserYAMLButton.ForeColor = System.Drawing.Color.White;
            this.SaveUserYAMLButton.Location = new System.Drawing.Point(2, 176);
            this.SaveUserYAMLButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveUserYAMLButton.Name = "SaveUserYAMLButton";
            this.SaveUserYAMLButton.Size = new System.Drawing.Size(46, 28);
            this.SaveUserYAMLButton.TabIndex = 13;
            this.SaveUserYAMLButton.Text = "保存";
            this.SaveUserYAMLButton.UseVisualStyleBackColor = false;
            this.SaveUserYAMLButton.Click += new System.EventHandler(this.SaveUserYAMLButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(797, 212);
            this.Controls.Add(this.SaveUserYAMLButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MasterYAMLPathButton);
            this.Controls.Add(this.MasterYAMLPathBox);
            this.Controls.Add(this.MasterYAMLPathLabel);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.ServerStopButton);
            this.Controls.Add(this.ServerStartButton);
            this.Controls.Add(this.QuitButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "メイン";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button QuitButton;
        private Button ServerStartButton;
        private Button ServerStopButton;
        private CheckBox VSYAMLEnableCheck;
        private TextBox VSYAMLFilePathBox;
        private Button VSYAMLFilePathButton;
        private Label PortLabel;
        private TextBox PortBox;
        private Button MasterYAMLPathButton;
        private TextBox MasterYAMLPathBox;
        private Label MasterYAMLPathLabel;
        private GroupBox groupBox1;
        private OpenFileDialog OpenFileDialog;
        private Button SaveUserYAMLButton;
    }
}