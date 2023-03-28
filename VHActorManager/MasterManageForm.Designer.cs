namespace VHActorManager
{
    partial class MasterManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterManageForm));
            QuitButton = new Button();
            ServerStartButton = new Button();
            ServerStopButton = new Button();
            VSYAMLEnableCheck = new CheckBox();
            VegasScriptFileDirBox = new TextBox();
            VegasScriptFileDirButton = new Button();
            PortLabel = new Label();
            PortBox = new TextBox();
            groupBox1 = new GroupBox();
            VegasExtFileDirLabel = new Label();
            VegasScriptFileDirLabel = new Label();
            VegasExtFileDirBox = new TextBox();
            VegasExtFileDirButton = new Button();
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
            QuitButton.Location = new Point(748, 130);
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
            ServerStartButton.Location = new Point(136, 130);
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
            ServerStopButton.Location = new Point(240, 130);
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
            VSYAMLEnableCheck.Location = new Point(6, 16);
            VSYAMLEnableCheck.Margin = new Padding(3, 4, 3, 4);
            VSYAMLEnableCheck.Name = "VSYAMLEnableCheck";
            VSYAMLEnableCheck.Size = new Size(51, 22);
            VSYAMLEnableCheck.TabIndex = 3;
            VSYAMLEnableCheck.Text = "反映";
            VSYAMLEnableCheck.UseVisualStyleBackColor = false;
            // 
            // VegasScriptFileDirBox
            // 
            VegasScriptFileDirBox.BackColor = Color.Azure;
            VegasScriptFileDirBox.BorderStyle = BorderStyle.None;
            VegasScriptFileDirBox.Location = new Point(197, 42);
            VegasScriptFileDirBox.Name = "VegasScriptFileDirBox";
            VegasScriptFileDirBox.Size = new Size(540, 18);
            VegasScriptFileDirBox.TabIndex = 5;
            // 
            // VegasScriptFileDirButton
            // 
            VegasScriptFileDirButton.BackColor = Color.White;
            VegasScriptFileDirButton.FlatAppearance.BorderColor = Color.FromArgb(255, 192, 192);
            VegasScriptFileDirButton.FlatAppearance.BorderSize = 2;
            VegasScriptFileDirButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            VegasScriptFileDirButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            VegasScriptFileDirButton.FlatStyle = FlatStyle.Flat;
            VegasScriptFileDirButton.Font = new Font("メイリオ", 4F, FontStyle.Bold, GraphicsUnit.Point);
            VegasScriptFileDirButton.ForeColor = Color.Black;
            VegasScriptFileDirButton.Image = (Image)resources.GetObject("VegasScriptFileDirButton.Image");
            VegasScriptFileDirButton.Location = new Point(743, 42);
            VegasScriptFileDirButton.Margin = new Padding(3, 4, 3, 4);
            VegasScriptFileDirButton.Name = "VegasScriptFileDirButton";
            VegasScriptFileDirButton.Size = new Size(36, 20);
            VegasScriptFileDirButton.TabIndex = 6;
            VegasScriptFileDirButton.Text = "...";
            VegasScriptFileDirButton.UseVisualStyleBackColor = false;
            VegasScriptFileDirButton.Click += VegasScriptFileDirButton_Click;
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
            groupBox1.Controls.Add(VegasExtFileDirLabel);
            groupBox1.Controls.Add(VegasScriptFileDirLabel);
            groupBox1.Controls.Add(VSYAMLEnableCheck);
            groupBox1.Controls.Add(VegasExtFileDirBox);
            groupBox1.Controls.Add(VegasScriptFileDirBox);
            groupBox1.Controls.Add(VegasExtFileDirButton);
            groupBox1.Controls.Add(VegasScriptFileDirButton);
            groupBox1.Location = new Point(8, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(786, 90);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "VEGASスクリプトのYAMLファイル";
            // 
            // VegasExtFileDirLabel
            // 
            VegasExtFileDirLabel.AutoSize = true;
            VegasExtFileDirLabel.Location = new Point(42, 66);
            VegasExtFileDirLabel.Name = "VegasExtFileDirLabel";
            VegasExtFileDirLabel.Size = new Size(156, 18);
            VegasExtFileDirLabel.TabIndex = 8;
            VegasExtFileDirLabel.Text = "VEGAS拡張のディレクトリ";
            // 
            // VegasScriptFileDirLabel
            // 
            VegasScriptFileDirLabel.AutoSize = true;
            VegasScriptFileDirLabel.Location = new Point(6, 42);
            VegasScriptFileDirLabel.Name = "VegasScriptFileDirLabel";
            VegasScriptFileDirLabel.Size = new Size(192, 18);
            VegasScriptFileDirLabel.TabIndex = 7;
            VegasScriptFileDirLabel.Text = "VEGASスクリプトのディレクトリ";
            // 
            // VegasExtFileDirBox
            // 
            VegasExtFileDirBox.BackColor = Color.Azure;
            VegasExtFileDirBox.BorderStyle = BorderStyle.None;
            VegasExtFileDirBox.Location = new Point(197, 66);
            VegasExtFileDirBox.Name = "VegasExtFileDirBox";
            VegasExtFileDirBox.Size = new Size(540, 18);
            VegasExtFileDirBox.TabIndex = 5;
            // 
            // VegasExtFileDirButton
            // 
            VegasExtFileDirButton.BackColor = Color.White;
            VegasExtFileDirButton.FlatAppearance.BorderColor = Color.FromArgb(255, 192, 192);
            VegasExtFileDirButton.FlatAppearance.BorderSize = 2;
            VegasExtFileDirButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 64, 0);
            VegasExtFileDirButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
            VegasExtFileDirButton.FlatStyle = FlatStyle.Flat;
            VegasExtFileDirButton.Font = new Font("メイリオ", 4F, FontStyle.Bold, GraphicsUnit.Point);
            VegasExtFileDirButton.ForeColor = Color.Black;
            VegasExtFileDirButton.Image = (Image)resources.GetObject("VegasExtFileDirButton.Image");
            VegasExtFileDirButton.Location = new Point(743, 64);
            VegasExtFileDirButton.Margin = new Padding(3, 4, 3, 4);
            VegasExtFileDirButton.Name = "VegasExtFileDirButton";
            VegasExtFileDirButton.Size = new Size(36, 20);
            VegasExtFileDirButton.TabIndex = 6;
            VegasExtFileDirButton.Text = "...";
            VegasExtFileDirButton.UseVisualStyleBackColor = false;
            VegasExtFileDirButton.Click += VegasExtFileDirButton_Click;
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
            SaveUserYAMLButton.Location = new Point(8, 130);
            SaveUserYAMLButton.Margin = new Padding(3, 4, 3, 4);
            SaveUserYAMLButton.Name = "SaveUserYAMLButton";
            SaveUserYAMLButton.Size = new Size(93, 28);
            SaveUserYAMLButton.TabIndex = 13;
            SaveUserYAMLButton.Text = "設定を保存";
            SaveUserYAMLButton.UseVisualStyleBackColor = false;
            SaveUserYAMLButton.Click += SaveUserYAMLButton_Click;
            // 
            // ServerStatusBox
            // 
            ServerStatusBox.BackColor = Color.FromArgb(192, 255, 192);
            ServerStatusBox.BorderStyle = BorderStyle.None;
            ServerStatusBox.Location = new Point(358, 135);
            ServerStatusBox.Name = "ServerStatusBox";
            ServerStatusBox.Size = new Size(56, 18);
            ServerStatusBox.TabIndex = 14;
            ServerStatusBox.Text = "停止中";
            ServerStatusBox.TextAlign = HorizontalAlignment.Center;
            // 
            // BaseUrlBox
            // 
            BaseUrlBox.BorderStyle = BorderStyle.FixedSingle;
            BaseUrlBox.Location = new Point(420, 132);
            BaseUrlBox.Name = "BaseUrlBox";
            BaseUrlBox.Size = new Size(309, 25);
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
            // MasterManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(797, 164);
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
            Name = "MasterManageForm";
            Text = "マスタ管理システム";
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
        private TextBox VegasScriptFileDirBox;
        private Button VegasScriptFileDirButton;
        private Label PortLabel;
        private TextBox PortBox;
        private GroupBox groupBox1;
        private OpenFileDialog OpenFileDialog;
        private Button SaveUserYAMLButton;
        private TextBox ServerStatusBox;
        private TextBox BaseUrlBox;
        private CheckBox OpenBrowserOnStartCheck;
        private TextBox VegasExtFileDirBox;
        private Button VegasExtFileDirButton;
        private Label VegasExtFileDirLabel;
        private Label VegasScriptFileDirLabel;
    }
}