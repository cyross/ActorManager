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
            QuitButton = new Button();
            ServerStartButton = new Button();
            ServerStopButton = new Button();
            VSYAMLEnableCheck = new CheckBox();
            VSYAMLFilePathBox = new TextBox();
            VSYAMLFilePathButton = new Button();
            PortLabel = new Label();
            PortBox = new TextBox();
            groupBox1 = new GroupBox();
            OpenFileDialog = new OpenFileDialog();
            SaveUserYAMLButton = new Button();
            ServerStatusBox = new TextBox();
            BaseUrlBox = new TextBox();
            OpenBrowserOnStartCheck = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // QuitButton
            // 
            QuitButton.BackColor = Color.Crimson;
            QuitButton.FlatAppearance.BorderSize = 0;
            QuitButton.FlatStyle = FlatStyle.Flat;
            QuitButton.Font = new Font("メイリオ", 9F, FontStyle.Bold, GraphicsUnit.Point);
            QuitButton.ForeColor = Color.White;
            QuitButton.Location = new Point(745, 125);
            QuitButton.Margin = new Padding(3, 4, 3, 4);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(46, 28);
            QuitButton.TabIndex = 0;
            QuitButton.Text = "終了";
            QuitButton.UseVisualStyleBackColor = false;
            QuitButton.Click += QuitButton_Click;
            // 
            // ServerStartButton
            // 
            ServerStartButton.BackColor = Color.DarkGreen;
            ServerStartButton.FlatAppearance.BorderSize = 0;
            ServerStartButton.FlatStyle = FlatStyle.Flat;
            ServerStartButton.Font = new Font("メイリオ", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ServerStartButton.ForeColor = Color.White;
            ServerStartButton.Location = new Point(72, 125);
            ServerStartButton.Margin = new Padding(3, 4, 3, 4);
            ServerStartButton.Name = "ServerStartButton";
            ServerStartButton.Size = new Size(98, 28);
            ServerStartButton.TabIndex = 1;
            ServerStartButton.Text = "サーバー起動";
            ServerStartButton.UseVisualStyleBackColor = false;
            ServerStartButton.Click += ServerStartButton_Click;
            // 
            // ServerStopButton
            // 
            ServerStopButton.BackColor = Color.Gold;
            ServerStopButton.FlatAppearance.BorderSize = 0;
            ServerStopButton.FlatStyle = FlatStyle.Flat;
            ServerStopButton.Font = new Font("メイリオ", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ServerStopButton.ForeColor = Color.Black;
            ServerStopButton.Location = new Point(176, 125);
            ServerStopButton.Margin = new Padding(3, 4, 3, 4);
            ServerStopButton.Name = "ServerStopButton";
            ServerStopButton.Size = new Size(98, 28);
            ServerStopButton.TabIndex = 2;
            ServerStopButton.Text = "サーバー停止";
            ServerStopButton.UseVisualStyleBackColor = false;
            ServerStopButton.Click += ServerStopButton_Click;
            // 
            // VSYAMLEnableCheck
            // 
            VSYAMLEnableCheck.AutoSize = true;
            VSYAMLEnableCheck.BackColor = Color.Transparent;
            VSYAMLEnableCheck.Font = new Font("メイリオ", 9F, FontStyle.Regular, GraphicsUnit.Point);
            VSYAMLEnableCheck.Location = new Point(6, 25);
            VSYAMLEnableCheck.Margin = new Padding(3, 4, 3, 4);
            VSYAMLEnableCheck.Name = "VSYAMLEnableCheck";
            VSYAMLEnableCheck.Size = new Size(51, 22);
            VSYAMLEnableCheck.TabIndex = 3;
            VSYAMLEnableCheck.Text = "反映";
            VSYAMLEnableCheck.UseVisualStyleBackColor = false;
            // 
            // VSYAMLFilePathBox
            // 
            VSYAMLFilePathBox.BackColor = Color.Azure;
            VSYAMLFilePathBox.BorderStyle = BorderStyle.None;
            VSYAMLFilePathBox.Location = new Point(6, 54);
            VSYAMLFilePathBox.Name = "VSYAMLFilePathBox";
            VSYAMLFilePathBox.Size = new Size(731, 18);
            VSYAMLFilePathBox.TabIndex = 5;
            // 
            // VSYAMLFilePathButton
            // 
            VSYAMLFilePathButton.BackColor = Color.White;
            VSYAMLFilePathButton.FlatAppearance.BorderColor = Color.FromArgb(255, 192, 192);
            VSYAMLFilePathButton.FlatAppearance.BorderSize = 2;
            VSYAMLFilePathButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            VSYAMLFilePathButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            VSYAMLFilePathButton.FlatStyle = FlatStyle.Flat;
            VSYAMLFilePathButton.Font = new Font("メイリオ", 9F, FontStyle.Bold, GraphicsUnit.Point);
            VSYAMLFilePathButton.ForeColor = Color.Black;
            VSYAMLFilePathButton.Location = new Point(743, 49);
            VSYAMLFilePathButton.Margin = new Padding(3, 4, 3, 4);
            VSYAMLFilePathButton.Name = "VSYAMLFilePathButton";
            VSYAMLFilePathButton.Size = new Size(37, 28);
            VSYAMLFilePathButton.TabIndex = 6;
            VSYAMLFilePathButton.Text = "...";
            VSYAMLFilePathButton.UseVisualStyleBackColor = false;
            VSYAMLFilePathButton.Click += VSYAMLFilePathButton_Click;
            // 
            // PortLabel
            // 
            PortLabel.AutoSize = true;
            PortLabel.Location = new Point(5, 9);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(187, 18);
            PortLabel.TabIndex = 7;
            PortLabel.Text = "[必須]Webサーバーのポート番号";
            // 
            // PortBox
            // 
            PortBox.BackColor = Color.Azure;
            PortBox.BorderStyle = BorderStyle.None;
            PortBox.Location = new Point(198, 9);
            PortBox.MaxLength = 6;
            PortBox.Name = "PortBox";
            PortBox.Size = new Size(51, 18);
            PortBox.TabIndex = 8;
            PortBox.Text = "3000";
            PortBox.TextAlign = HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(VSYAMLEnableCheck);
            groupBox1.Controls.Add(VSYAMLFilePathBox);
            groupBox1.Controls.Add(VSYAMLFilePathButton);
            groupBox1.Location = new Point(8, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(786, 85);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "VEGASスクリプトのYAMLファイル";
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "openFileDialog1";
            // 
            // SaveUserYAMLButton
            // 
            SaveUserYAMLButton.BackColor = Color.DarkCyan;
            SaveUserYAMLButton.FlatAppearance.BorderSize = 0;
            SaveUserYAMLButton.FlatStyle = FlatStyle.Flat;
            SaveUserYAMLButton.ForeColor = Color.White;
            SaveUserYAMLButton.Location = new Point(5, 125);
            SaveUserYAMLButton.Margin = new Padding(3, 4, 3, 4);
            SaveUserYAMLButton.Name = "SaveUserYAMLButton";
            SaveUserYAMLButton.Size = new Size(46, 28);
            SaveUserYAMLButton.TabIndex = 13;
            SaveUserYAMLButton.Text = "保存";
            SaveUserYAMLButton.UseVisualStyleBackColor = false;
            SaveUserYAMLButton.Click += SaveUserYAMLButton_Click;
            // 
            // ServerStatusBox
            // 
            ServerStatusBox.BackColor = Color.FromArgb(192, 255, 192);
            ServerStatusBox.BorderStyle = BorderStyle.None;
            ServerStatusBox.Location = new Point(290, 130);
            ServerStatusBox.Name = "ServerStatusBox";
            ServerStatusBox.Size = new Size(56, 18);
            ServerStatusBox.TabIndex = 14;
            ServerStatusBox.Text = "停止中";
            ServerStatusBox.TextAlign = HorizontalAlignment.Center;
            // 
            // BaseUrlBox
            // 
            BaseUrlBox.BorderStyle = BorderStyle.FixedSingle;
            BaseUrlBox.Location = new Point(352, 127);
            BaseUrlBox.Name = "BaseUrlBox";
            BaseUrlBox.Size = new Size(374, 25);
            BaseUrlBox.TabIndex = 15;
            // 
            // OpenBrowserOnStartCheck
            // 
            OpenBrowserOnStartCheck.AutoSize = true;
            OpenBrowserOnStartCheck.Location = new Point(290, 8);
            OpenBrowserOnStartCheck.Name = "OpenBrowserOnStartCheck";
            OpenBrowserOnStartCheck.Size = new Size(207, 22);
            OpenBrowserOnStartCheck.TabIndex = 16;
            OpenBrowserOnStartCheck.Text = "サーバー開始時にブラウザを開く";
            OpenBrowserOnStartCheck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(797, 160);
            Controls.Add(OpenBrowserOnStartCheck);
            Controls.Add(BaseUrlBox);
            Controls.Add(ServerStatusBox);
            Controls.Add(SaveUserYAMLButton);
            Controls.Add(groupBox1);
            Controls.Add(PortBox);
            Controls.Add(PortLabel);
            Controls.Add(ServerStopButton);
            Controls.Add(ServerStartButton);
            Controls.Add(QuitButton);
            DoubleBuffered = true;
            Font = new Font("メイリオ", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "メイン";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private GroupBox groupBox1;
        private OpenFileDialog OpenFileDialog;
        private Button SaveUserYAMLButton;
        private TextBox ServerStatusBox;
        private TextBox BaseUrlBox;
        private CheckBox OpenBrowserOnStartCheck;
    }
}