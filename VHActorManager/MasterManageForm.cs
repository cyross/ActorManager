using System.Diagnostics;
using System.IO;
using VHActorManager.Master;
using VHActorManager.WebService;

namespace VHActorManager
{
    public partial class MasterManageForm : Form
    {
        private const string SERVER_RUNNING = "起動中";
        private const string SERVER_STOPPING = "停止中";
        private const string VEGAS_SCRIPT_DIRNAME = "Vegas Script Menu";
        private const string VEGAS_EXT_DIRNAME = "Vegas Application Extensions";

        private readonly User user;
        private readonly ActorMaster actorMaster;
        private readonly ColorMaster colorMaster;
        private readonly VoiceEngineMaster voiceEngineMaster;
        private readonly WebServer webServer;

        public MasterManageForm()
        {
            user = User.Instance();
            user.Load();

            actorMaster = ActorMaster.Instance();
            actorMaster.Load();

            colorMaster = ColorMaster.Instance();
            colorMaster.Load();

            voiceEngineMaster = VoiceEngineMaster.Instance();
            voiceEngineMaster.Load();

            webServer = new WebServer(user);

            InitializeComponent();

            ServerStartButton.Enabled = true;
            ServerStopButton.Enabled = false;
            ServerStatusBox.Text = SERVER_STOPPING;

            PortBox.Text = user.Server.Port.ToString();
            OpenBrowserOnStartCheck.Checked = user.Server.OpenBrowser;
            VSYAMLEnableCheck.Checked = user.VegasScriptYAML.Enable;
            VegasScriptFileDirBox.Text = GetDir(user.VegasScriptYAML.ScriptPath, VEGAS_SCRIPT_DIRNAME);
            VegasExtFileDirBox.Text = GetDir(user.VegasScriptYAML.ExtPath, VEGAS_EXT_DIRNAME);
        }

        private static string GetDir(string dir, string defaultDirName)
        {
            if (dir != "") { return dir; }

            return Utility.CombineFilePath(Utility.GetDocumentFolderPath(), defaultDirName);
        }

        private void StartServer()
        {
            if (webServer.IsRunning) { return; } // 二重起動を避ける

            UpdateUserMaster();

            webServer.Start();
            ServerStartButton.Enabled = false;
            ServerStopButton.Enabled = true;
            ServerStatusBox.Text = SERVER_RUNNING;
            BaseUrlBox.Text = webServer.BaseUrl;
        }

        private void StopServer()
        {
            if (!webServer.IsRunning) { return; } // 停止エラーを避ける

            webServer.Stop();
            ServerStartButton.Enabled = true;
            ServerStopButton.Enabled = false;
            ServerStatusBox.Text = SERVER_STOPPING;
            BaseUrlBox.Text = "";
        }

        private void UpdateUserMaster()
        {
            user.Server.Port = int.Parse(PortBox.Text);
            user.Server.OpenBrowser = OpenBrowserOnStartCheck.Checked;
            user.VegasScriptYAML.Enable = VSYAMLEnableCheck.Checked;
            user.VegasScriptYAML.ScriptPath = VegasScriptFileDirBox.Text;
            user.VegasScriptYAML.ExtPath = VegasExtFileDirBox.Text;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            StopServer();

            Application.Exit();
        }

        private void VegasScriptFileDirButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.InitialDirectory = VegasScriptFileDirBox.Text;
            OpenFileDialog.FileName = ActorMaster.YAML_FILENAME;

            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) { return; }

            VegasScriptFileDirBox.Text = Utility.GetDirectory(OpenFileDialog.FileName);
        }

        private void VegasExtFileDirButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.InitialDirectory = VegasExtFileDirBox.Text;
            OpenFileDialog.FileName = ActorMaster.YAML_FILENAME;

            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) { return; }

            VegasExtFileDirBox.Text = Utility.GetDirectory(OpenFileDialog.FileName);
        }

        private void SaveUserYAMLButton_Click(object sender, EventArgs e)
        {
            UpdateUserMaster();

            user.Save();
        }

        private void ServerStartButton_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void ServerStopButton_Click(object sender, EventArgs e)
        {
            StopServer();
        }
    }
}