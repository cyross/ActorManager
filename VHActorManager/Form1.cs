using VHActorManager.Master;
using VHActorManager.WebService;

namespace VHActorManager
{
    public partial class Form1 : Form
    {
        private const string SERVER_RUNNING = "起動中";
        private const string SERVER_STOPPING = "停止中";

        private readonly User user;
        private readonly ActorMaster actorMaster;
        private readonly ColorMaster colorMaster;
        private readonly VoiceEngineMaster voiceEngineMaster;
        private readonly WebServer webServer;

        public Form1()
        {
            user = new();
            user.Load();

            actorMaster = new();
            actorMaster.Load();

            colorMaster = new();
            colorMaster.Load();

            voiceEngineMaster = new();
            voiceEngineMaster.Load();

            webServer = new WebServer(user);

            InitializeComponent();

            ServerStartButton.Enabled = true;
            ServerStopButton.Enabled = false;
            ServerStatusBox.Text = SERVER_STOPPING;

            PortBox.Text = user.Server.Port.ToString();
            OpenBrowserOnStartCheck.Checked = user.Server.OpenBrowser;
            VSYAMLEnableCheck.Checked = user.VHYaml.Enable;
            VSYAMLFilePathBox.Text = user.VHYaml.Path;
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
            user.VHYaml.Enable = VSYAMLEnableCheck.Checked;
            user.VHYaml.Path = VSYAMLFilePathBox.Text;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            StopServer();

            Application.Exit();
        }

        private void VSYAMLFilePathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.FileName = VSYAMLFilePathBox.Text;

            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel) { return; }

            VSYAMLFilePathBox.Text = OpenFileDialog.FileName;
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